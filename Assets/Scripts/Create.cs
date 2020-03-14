using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
  public GameObject cube;
  public GameObject parent;
  public Transform floor;
  public Drag drag;

  Phase phase;
  string[] keys = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "+", "-", "*", "/", "^", "(", ")"};
  int index = 0;

  void Start()
  {
    phase = Object.FindObjectOfType<Phase>();
  }

  void Update()
  {
    if (phase.isOn)
    {
      if (Input.GetKeyDown("c"))
      {
        foreach (Transform child in parent.transform)
        {
          if (!child.GetComponent<Switch>())
          {
            Destroy(child.gameObject);
          }
        }
      }

      if (Input.GetMouseButtonDown(1))
      {
        New(GetKey());
      }

      if (Input.GetAxis("Mouse ScrollWheel") < 0f)
      {
        index++;
        print(GetKey());
      }

      if (Input.GetAxis("Mouse ScrollWheel") > 0f)
      {
        index--;
        print(GetKey());
      }
    }
  }

  void New(string name)
  {
    GameObject created = Instantiate(cube, parent.transform);
    created.name = name;
    RaycastHit hit;
    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 5f))
    {
      if(hit.transform == floor)
      {
        created.transform.position = drag.SnapPos(hit.point);
      }
      else
      {
        created.transform.position = drag.SnapPos(hit.point) + hit.normal;
      }
    }
    else
    {
      created.transform.position = drag.SnapPos(transform.position + transform.forward * 5f);
    }
  }

  public string GetKey()
  {
    index = (int)Mathf.Repeat(index, keys.Length);
    return keys[index];
  }
}
