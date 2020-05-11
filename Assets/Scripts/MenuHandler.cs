using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{

  public void Play()
  {
    //сделать выбор уровня и загрузку этого уровня
    SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
  }

  public void Exit() { Application.Quit(); }
}
