using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{

  Text levelNumberText;
  LevelHandler levelHandler;

  void Start()
  {
    levelHandler = GameObject.FindWithTag("LevelController").GetComponent<LevelHandler>();
    levelNumberText = GameObject.Find("LevelNumberText").GetComponent<Text>();
  }

  void Update()
  {
    levelNumberText.text = levelHandler.getCurrentLevel().ToString();
  }

  public void Exit() { Application.Quit(); }
}
