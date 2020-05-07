using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{

  public void Play()
  {
    Debug.Log("Play pressed");
    SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
  }

  public void Exit()
  {
    Debug.Log("Exit pressed");
    Application.Quit();
  }
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
