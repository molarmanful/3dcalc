using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using B83.ExpressionParser;

public class Switch : MonoBehaviour
{
  public string res = "";
  public GameObject player;

  ExpressionParser Parser = new ExpressionParser();

  void Update()
  {
    List<Transform> children = new List<Transform>();
    foreach (Transform child in transform.parent)
    {
      if (child.transform != transform)
      {
        child.GetComponent<FollowSwitch>().isOn = false;
        children.Add(child);
      }
    }

    children = children.OrderBy(x => Vector3.Distance(x.transform.position, transform.position)).ToList();

    foreach (Transform child in children)
    {
      if (child.transform != transform && Mathf.Approximately(Vector3.Distance(child.transform.position, transform.position), 1f))
      {
        try
        {
          res = Parser.Evaluate(child.GetComponent<FollowSwitch>().Relay()).ToString();
        }
        catch
        {
          res = "ERROR";
        }
        return;
      }
    }

    res = "";
  }
}