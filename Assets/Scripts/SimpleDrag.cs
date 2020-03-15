using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDrag : MonoBehaviour
{
  public float sens = .3f;
  public bool lockAngVel = false;

  Vector3 sPoint;
  Vector3 offset;
  Rigidbody rb;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
    if (lockAngVel)
    {
      rb.maxAngularVelocity = 0;
    }
  }

  void OnMouseDown()
  {
    sPoint = Camera.main.WorldToScreenPoint(transform.position);
    offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, sPoint.z));
  }

  void OnMouseDrag()
  {
    Vector3 cursPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, sPoint.z);
    Vector3 targetPos = Camera.main.ScreenToWorldPoint(cursPoint) + offset;
    rb.velocity = 1f / Time.fixedDeltaTime * (targetPos - transform.position) * Mathf.Pow(sens, 90f * Time.fixedDeltaTime);
  }
}
