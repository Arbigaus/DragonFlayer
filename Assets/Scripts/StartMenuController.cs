using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour
{
   public Text score;
   public SaveData saveData;

   private void Start()
   {
      GetSavedScore();
   }

   public void ChangeScene(string sceneName)
   {
      SceneManager.LoadScene(sceneName);
   }

   private void GetSavedScore()
   {
      saveData.LoadFile();
      score.text = "Record: " + saveData.currentScore;
   }
}
