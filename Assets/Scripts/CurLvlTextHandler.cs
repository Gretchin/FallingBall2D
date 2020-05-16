using UnityEngine;
using UnityEngine.UI;

public class CurLvlTextHandler : MonoBehaviour
{
  void Awake()
  {
    LevelHandler levelHandler = GameObject.FindWithTag("LevelController").GetComponent<LevelHandler>();
    Text levelNumberText = gameObject.GetComponent<Text>();
    levelNumberText.text = levelHandler.getCurrentLevel().ToString();
  }
}
