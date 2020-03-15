using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
  public float speed = 10f;
  public List<Rigidbody> pushables;
  public float power = 2f;

  CharacterController ch;
  Phase phase;
  float translate;
  float strafe;
  float fly;

  void Start()
  {
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    ch = GetComponent<CharacterController>();
    phase = Object.FindObjectOfType<Phase>();
  }

  void Update()
  {
    translate = Input.GetAxis("Vertical") * speed * Time.deltaTime;
    fly = phase.isOn ? Input.GetAxis("Jump") * speed * Time.deltaTime : -1;
    strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
    ch.Move(transform.TransformDirection(new Vector3(strafe, fly, translate)));

    if (Input.GetKeyDown("escape"))
    {
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
    }
    else if (Input.GetMouseButtonDown(0) && Cursor.lockState == CursorLockMode.None)
    {
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
    }
  }

  void OnControllerColliderHit(ControllerColliderHit hit)
  {
    Rigidbody body = hit.collider.attachedRigidbody;
    if (pushables.Contains(body))
    {
      Vector3 force = hit.controller.velocity * power;
      body.AddForceAtPosition(force, hit.point);
    }
  }
}
