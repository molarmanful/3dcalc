using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyTextBehavior : MonoBehaviour
{
  public Create cr;

  TextMeshPro tm;

  void Start()
  {
    tm = GetComponent<TextMeshPro>();
  }

  void Update()
  {
    tm.text = cr.GetKey();
  }
}