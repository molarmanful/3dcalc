using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
  public float speed = 10f;
  public Phase ph;

  CharacterController ch;
  float translate;
  float strafe;
  float fly;

  void Start()
  {
    Cursor.lockState = CursorLockMode.Locked;
    ch = GetComponent<CharacterController>();
  }

  void Update()
  {
    translate = Input.GetAxis("Vertical") * speed * Time.deltaTime;
    fly = ph.isOn ? Input.GetAxis("Jump") * speed * Time.deltaTime : 0;
    strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
    ch.Move(transform.TransformDirection(new Vector3(strafe, fly, translate)));

    if (Input.GetKeyDown("escape"))
    {
      Cursor.lockState = CursorLockMode.None;
    }
    else if (Input.GetMouseButtonDown(0) && Cursor.lockState == CursorLockMode.None)
    {
      Cursor.lockState = CursorLockMode.Locked;
    }
  }
}
