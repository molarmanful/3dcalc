using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Drag : MonoBehaviour
{
  Vector3 sPoint;
  Vector3 offset;
  Rigidbody rb;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
    rb.isKinematic = true;
    rb.maxAngularVelocity = 30f;
  }

  void OnMouseDown()
  {
    sPoint = Camera.main.WorldToScreenPoint(transform.position);
    offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, sPoint.z));
    rb.isKinematic = false;
  }

  void OnMouseDrag()
  {
    Vector3 cursPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, sPoint.z);
    Vector3 targetPos = Camera.main.ScreenToWorldPoint(cursPoint) + offset;
    rb.velocity = 1f / Time.fixedDeltaTime * (targetPos - transform.position) * Mathf.Pow(.5f, 90f * Time.fixedDeltaTime);
  }

  void OnMouseUp()
  {
    transform.position = SnapPos(transform.position);
    rb.velocity = Vector3.zero;
    rb.isKinematic = true;
  }

  public Vector3 SnapPos(Vector3 pos, float n = 1)
  {
    pos *= n;
    pos.x = Mathf.Round(pos.x);
    pos.y = Mathf.Round(pos.y);
    pos.z = Mathf.Round(pos.z);
    return pos / n;
  }
}
