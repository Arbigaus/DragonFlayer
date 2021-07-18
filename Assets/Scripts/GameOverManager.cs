using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        DeathPlayer();
    }
    
    void DeathPlayer()
    {
        player.GetComponent<Animator>().Play("Death");
    }
    
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
