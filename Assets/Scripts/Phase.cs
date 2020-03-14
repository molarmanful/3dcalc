using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase : MonoBehaviour
{
  public GameObject player;
  public GameObject cam;
  public List<GameObject> toggles = new List<GameObject>();
  public float flySpeed = 10f;
  public bool isOn = false;
  [ColorUsage(true, true)]
  public Color color = Vector4.zero;
  [ColorUsage(true, true)]
  public Color hoverColor = Vector4.zero;
  [ColorUsage(true, true)]
  public Color newColor = Color.blue * 2;
  [ColorUsage(true, true)]
  public Color hoverNewColor = Color.blue * 3;

  CharacterController cc;
  CharController ccc;
  Renderer rd;
  Look look;
  Vector3 startPos;
  float startSpeed;
  Vector2 mLook;
  Color curColor;

  void Start()
  {
    cc = player.GetComponent<CharacterController>();
    ccc = player.GetComponent<CharController>();
    rd = GetComponent<Renderer>();
    startSpeed = ccc.speed;
    look = cam.GetComponent<Look>();
  }

  void OnMouseEnter()
  {
    rd.material.SetColor("_Fresnel", isOn ? hoverNewColor : hoverColor);
  }

  void OnMouseExit()
  {
    rd.material.SetColor("_Fresnel", curColor);
  }

  void OnMouseDown()
  {
    isOn = !isOn;

    foreach (GameObject toggle in toggles)
    {
      toggle.SetActive(!toggle.activeInHierarchy);
    }

    Alter();
  }

  void Alter()
  {
    if (isOn)
    {
      startPos = player.transform.position;
      mLook = look.mLook;
      ccc.speed = flySpeed;
      curColor = newColor;
      rd.material.SetColor("_Fresnel", newColor);
    }
    else
    {
      cc.enabled = false;
      player.transform.position = startPos;
      cam.GetComponent<Look>().mLook = mLook;
      ccc.speed = startSpeed;
      cc.enabled = true;
      curColor = color;
      rd.material.SetColor("_Fresnel", color);
    }
  }
}
