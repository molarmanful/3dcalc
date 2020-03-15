using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
  public float speed = 1f;
  public float dist = .5f;

  Rigidbody rb;
  bool open = false;
  Vector3 endPos;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
    endPos = transform.position;
  }

  void Update()
  {
    if (transform.position != endPos)
    {
      iTween.MoveTo(gameObject, endPos, speed);
    }
  }

  void OnMouseDown()
  {
    open = !open;
    endPos.z += open ? dist : -dist;
  }
}
