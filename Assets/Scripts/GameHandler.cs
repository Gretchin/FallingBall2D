using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
  GameObject player;
  Vector3 playerPosition;

  GameObject nextLevelButton;
  GameObject loseText;

  LevelHandler levelHandler;

  bool isSimulated = false;

  public bool IsSimulated()
  {
    return isSimulated;
  }

  void Start()
  {
    levelHandler = GameObject.FindWithTag("LevelController").GetComponent<LevelHandler>();
    player = GameObject.FindGameObjectWithTag("Player");
    playerPosition = player.transform.position;

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

  public void StartSimulation()
  {
    if (player != null && !isSimulated)
    {

      if (loseText != null)
      {
        loseText.SetActive(false);
      }
      player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
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

  public void NextLevel()
  {
    levelHandler.PlayNextLevel();
  }

  public void Win()
  {
    if (player != null)
    {
      isSimulated = false;
      player.GetComponent<Rigidbody2D>().simulated = isSimulated;
    }

    if (levelHandler.currentLevelIsLast())
    {
      loseText.GetComponent<Text>().text = "Ура! Все вирусы побеждены, теперь ЛШ точно состоится =)";
      loseText.SetActive(true);
    }
    else if (nextLevelButton != null)
    {
      nextLevelButton.SetActive(true);
    }
    levelHandler.IncreaseMaxLevel();
  }
  public void Lose()
  {
    if (loseText != null)
    {
      loseText.SetActive(true);
    }
    isSimulated = false;
    player.GetComponent<Rigidbody2D>().simulated = isSimulated;
    player.transform.SetPositionAndRotation(playerPosition, Quaternion.identity);
  }
}
