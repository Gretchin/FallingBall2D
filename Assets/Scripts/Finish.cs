using UnityEngine;

public class Finish : MonoBehaviour
{
  public GameObject finish;

  void Start()
  {
    Debug.Log("FISIN");

  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject == finish)
    {
      Debug.Log("trigger");
    }
  }
}
