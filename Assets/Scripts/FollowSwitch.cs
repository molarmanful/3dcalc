using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FollowSwitch : MonoBehaviour
{
  Renderer rd;
  public bool isOn = false;

  void Start()
  {
    rd = GetComponent<Renderer>();
  }

  void Update()
  {
    if (isOn)
    {
      rd.material.SetColor("_Fresnel", Color.cyan * 2f);
    }
    else
    {
      rd.material.SetColor("_Fresnel", Color.red);
    }
  }

  public string Relay()
  {
    isOn = true;
    List<Transform> children = new List<Transform>();
    foreach (Transform child in transform.parent)
    {
      if (child.transform != transform && !child.GetComponent<Switch>())
      {
        children.Add(child);
      }
    }

    children = children.OrderBy(x => Vector3.Distance(x.transform.position, transform.position)).ToList();

    foreach (Transform child in children)
    {
      if (child.transform != transform && !child.GetComponent<Switch>() && Mathf.Approximately(Vector3.Distance(child.transform.position, transform.position), 1f) && !child.GetComponent<FollowSwitch>().isOn)
      {
        return child.GetComponent<FollowSwitch>().Relay() + name;
      }
    }

    return name;
  }
}