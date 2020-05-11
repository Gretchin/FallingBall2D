using UnityEngine;

public class Finish : MonoBehaviour
{
  Rigidbody2D rb;
  GameHandler gameHandler;
  Camera cam;
  int numberOfFramesPlayerDontMove = 0;
  int maxNumberOfFramesToLose = 100;

  public GameObject finish;

  void Start()
  {
    gameHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>();
    cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    rb = GetComponent<Rigidbody2D>();
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject == finish)
    {
      if (gameHandler)
      {
        gameHandler.Win();
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
      if (rb.velocity == Vector2.zero)
      {
        numberOfFramesPlayerDontMove++;
      }
      else
      {
        numberOfFramesPlayerDontMove = 0;
      }
    }
    if (point.y < 0f || point.y > 1f || point.x > 1f || point.x < 0f || numberOfFramesPlayerDontMove > maxNumberOfFramesToLose)
    {
      gameHandler.Lose();
      Destroy(gameObject);
    }
  }
}
