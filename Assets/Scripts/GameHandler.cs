using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
  GameObject player;
  Vector3 startPlayerPosition;

  GameObject nextLevelButton;
  GameObject gameOverUiElement;

  LevelHandler levelHandler;

  bool isSimulated = false;

  public bool IsSimulated()
  {
    return isSimulated;
  }

  private void ChangeSimulationState(bool newState)
  {
    isSimulated = newState;
    player.GetComponent<Rigidbody2D>().simulated = newState;
    GameObject buttonComponent = GameObject.FindWithTag("PlayButton");
    if (buttonComponent != null)
    {
      buttonComponent.GetComponent<Button>().interactable = !newState;
    }
  }

  void Start()
  {
    levelHandler = GameObject.FindWithTag("LevelController").GetComponent<LevelHandler>();
    player = GameObject.FindGameObjectWithTag("Player");
    startPlayerPosition = player.transform.position;

    nextLevelButton = GameObject.FindWithTag("NextLevelButton");
    nextLevelButton?.SetActive(false);

    gameOverUiElement = GameObject.FindWithTag("GameOver");
    gameOverUiElement?.SetActive(false);
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
  }

  public void StartSimulation()
  {
    if (player != null && !isSimulated)
    {

      if (gameOverUiElement != null)
      {
        gameOverUiElement.SetActive(false);
      }
      player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
      ChangeSimulationState(true);
    }
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
      ChangeSimulationState(false);
    }

    if (levelHandler.currentLevelIsLast())
    {
      gameOverUiElement.GetComponentInChildren<Text>().text = "Ура! Все вирусы побеждены, теперь ЛШ точно состоится =)";
      gameOverUiElement.SetActive(true);
    }
    else
    {
      nextLevelButton?.SetActive(true);
    }
    levelHandler.IncreaseMaxLevel();
  }
  public void Lose()
  {
    gameOverUiElement?.SetActive(true);
    ChangeSimulationState(false);
    player.transform.SetPositionAndRotation(startPlayerPosition, Quaternion.identity);
  }
}
