using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase : MonoBehaviour
{
  public GameObject player;
  public GameObject cam;
  public List<GameObject> toggles = new List<GameObject>();
  public float flySpeed = 10f;
  public bool isOn = false;

  CharacterController cc;
  CharController ccc;
  Look look;
  Vector3 startPos;
  float startSpeed;
  Vector2 mLook;

  void Start()
  {
    cc = player.GetComponent<CharacterController>();
    ccc = player.GetComponent<CharController>();
    startSpeed = ccc.speed;
    look = cam.GetComponent<Look>();
  }

  void OnMouseDown()
  {
    isOn = !isOn;

    foreach (GameObject toggle in toggles)
    {
      toggle.SetActive(!toggle.activeInHierarchy);
    }

    Alter();
  }

  void Alter()
  {
    if (isOn)
    {
      startPos = player.transform.position;
      mLook = look.mLook;
      ccc.speed = flySpeed;
    }
    else
    {
      cc.enabled = false;
      player.transform.position = startPos;
      cam.GetComponent<Look>().mLook = mLook;
      ccc.speed = startSpeed;
      cc.enabled = true;
    }
  }
}
