using System.Collections;
using UnityEngine;

public class Finish : MonoBehaviour
{
  Rigidbody2D rb;
  GameHandler gameHandler;
  Camera cam;
  Vector3 prevPos;
  int numberOfFramesPlayerDontMove = 0;
  int maxNumberOfFramesToLose = 500;

  void Start()
  {
    gameHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>();
    cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    rb = GetComponent<Rigidbody2D>();
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Finish")
    {
      if (gameHandler)
      {
        gameHandler.Win();
        StartCoroutine(SlowScale(other.gameObject.transform.position));
      }
    }
  }

  void Update()
  {
    if (!gameHandler)
    {
      return;
    }
    Vector3 point = cam.WorldToViewportPoint(transform.position);
    if (gameHandler.IsSimulated())
    {
      float asd = Vector3.Distance(prevPos, point);
      if (Vector3.Distance(prevPos, point) < 0.0003)
      {
        numberOfFramesPlayerDontMove++;
      }
      else
      {
        numberOfFramesPlayerDontMove = 0;
      }
    }
    prevPos = point;
    if (point.y < 0f || point.y > 1f || point.x > 1f || point.x < 0f || numberOfFramesPlayerDontMove > maxNumberOfFramesToLose)
    {
      numberOfFramesPlayerDontMove = 0;
      gameHandler.Lose();
    }
  }

  IEnumerator SlowScale(Vector3 position)
  {
    for (float q = 1f; q > 0f; q -= .05f)
    {
      transform.localScale = new Vector3(q, q, q);
      transform.position += (position - transform.position) * (1 - q);
      yield return new WaitForSeconds(.05f);
    }
    Destroy(gameObject);
  }
}
