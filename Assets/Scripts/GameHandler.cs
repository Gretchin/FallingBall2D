using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
  GameObject player;

  GameObject nextLevelButton;
  GameObject loseText;

  bool isSimulated = false;

  public bool IsSimulated()
  {
    return isSimulated;
  }

  public void StartSimulation()
  {
    if (player != null)
    {
      isSimulated = true;
      player.GetComponent<Rigidbody2D>().simulated = isSimulated;

    }
    // нужно запретить перетаскивание
  }

  public void ResetLevel()
  {
    Scene scene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(scene.name);
  }

  public void Win()
  {
    if (player != null)
    {
      isSimulated = false;
      player.GetComponent<Rigidbody2D>().simulated = isSimulated;
      // разрешить перетаскивание
    }

    if (nextLevelButton != null)
    {
      nextLevelButton.SetActive(true);
    }

    // Сохранить прогресс
  }
  public void Lose()
  {
    nextLevelButton = GameObject.Find("NextLevelButton");
    if (loseText != null)
    {
      loseText.SetActive(true);
    }
    isSimulated = false;
  }

  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    nextLevelButton = GameObject.Find("NextLevelButton");
    if (nextLevelButton != null)
    {
      nextLevelButton.SetActive(false);
    }

    loseText = GameObject.Find("LoseText");
    if (loseText != null)
    {
      loseText.SetActive(false);
    }
  }
}
