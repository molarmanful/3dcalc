using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Name : MonoBehaviour
{
  void Start()
  {
    foreach(Transform child in transform)
    {
      child.GetChild(0).GetComponent<TextMeshPro>().text = name;
    }
  }
}
