using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
  public float sens = 5f;
  public Vector2 mLook;

  GameObject character;

  void Start()
  {
    character = transform.parent.gameObject;
  }

  void Update()
  {
    if(Cursor.lockState == CursorLockMode.Locked)
    {
      Vector2 mDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
      mDelta = Vector2.Scale(mDelta, new Vector2(sens, sens));
      mLook += mDelta;
      mLook.y = Mathf.Clamp(mLook.y, -90, 90);
      character.transform.localRotation = Quaternion.AngleAxis(mLook.x, character.transform.up);
      transform.localRotation = Quaternion.AngleAxis(-mLook.y, Vector3.right);
    }
  }
}
