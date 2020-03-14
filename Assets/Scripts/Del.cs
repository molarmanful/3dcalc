using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Del : MonoBehaviour
{
  Phase phase;

  void Start()
  {
    phase = Object.FindObjectOfType<Phase>();
  }

  void OnMouseOver()
  {
    if (Input.GetMouseButtonDown(2) && phase.isOn)
    {
      Destroy(gameObject);
    }
  }
}
