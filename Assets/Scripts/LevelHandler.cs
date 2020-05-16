using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
  string menuSceneName = "MenuScene";
  string maxLevelKey = "MaxLevel";

  public int MaxReachableLevel = 5;

  int maxLevel = 1;
  int currentLevel = 1;


  void Start()
  {
    int loadedMaxLevel = PlayerPrefs.GetInt(maxLevelKey);

    UpdateMaxLevel(loadedMaxLevel);
    UpdateCurrentLevel(maxLevel);
    DontDestroyOnLoad(this);
  }


  public int getCurrentLevel() { return currentLevel; }
  public bool currentLevelIsLast() { return currentLevel == MaxReachableLevel; }
  public void LevelPlus() { UpdateCurrentLevel(currentLevel + 1); }
  public void LevelMinus() { UpdateCurrentLevel(currentLevel - 1); }

  public void UpdateCurrentLevel(int newCurrentLevel)
  {
    if (newCurrentLevel <= maxLevel && newCurrentLevel > 0)
    {
      currentLevel = newCurrentLevel;

      Text levelNumberText = GameObject.FindWithTag("LevelNumberText")?.GetComponent<Text>();
      if (levelNumberText != null)
      {
        levelNumberText.text = newCurrentLevel.ToString();
      }
    }
  }

  public void IncreaseMaxLevel() { UpdateMaxLevel(currentLevel + 1); }

  public void UpdateMaxLevel(int newMaxLevel)
  {
    if (newMaxLevel > maxLevel && newMaxLevel <= MaxReachableLevel)
    {
      maxLevel = newMaxLevel;

      if (currentLevel != newMaxLevel)
      {
        PlayerPrefs.SetInt(maxLevelKey, newMaxLevel);
        PlayerPrefs.Save();
      }
    }
  }

  public void Play()
  {
    SceneManager.LoadScene("Game" + currentLevel, LoadSceneMode.Single);
  }

  public void PlayNextLevel()
  {
    UpdateCurrentLevel(currentLevel + 1);
    Play();
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      GoBack();
    }
  }


  public void GoBack()
  {
    if (SceneManager.GetActiveScene().name == menuSceneName)
    {
      Application.Quit();
      return;
    }
    SceneManager.LoadScene(menuSceneName, LoadSceneMode.Single);
  }
}
