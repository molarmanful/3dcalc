using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
  public GameObject player;

  void OnMouseDown()
  {
    StartCoroutine("Move", Vector3.zero);
  }

  public IEnumerator Move(Vector3 pos)
  {
    player.GetComponent<CharController>().enabled = false;
    player.transform.position = pos;
    yield return new WaitForEndOfFrame();
    player.GetComponent<CharController>().enabled = true;
  }
}
