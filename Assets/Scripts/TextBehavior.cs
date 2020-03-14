using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBehavior : MonoBehaviour
{
  public Transform facer;
  public Switch sw;

  TextMeshPro tm;

  void Start()
  {
    tm = GetComponent<TextMeshPro>();
  }

  void Update()
  {
    transform.LookAt(2 * transform.position - facer.position);
    tm.text = sw.res;
  }
}
