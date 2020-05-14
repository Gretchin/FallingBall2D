using UnityEngine;

public class DisabledOnTouch : MonoBehaviour
{
  void Update()
  {
    if (Input.touchCount > 0)
    {
      gameObject.SetActive(false);
    }
  }
}
