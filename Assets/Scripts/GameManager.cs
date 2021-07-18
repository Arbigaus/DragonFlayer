using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    private GameObject _player;

    public Text record;
    public SaveData saveData;
    
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        StartCoroutine(SpawnEnemies());
        GetRecord();
    }

    private IEnumerator SpawnEnemies()
    {
        var rand = Random.Range(0, 3);
        
        GameObject enemyToSpawn = enemy1;
        if (rand < 1)
        {
            enemyToSpawn = enemy2;
        }
        
        var randY = Random.Range(-1, 7);
        var x = _player.transform.position.x + 80;
     
        Instantiate(enemyToSpawn, new Vector3(x, randY, 0), Quaternion.Euler(new Vector3(0, -90, 0)));

        var time = Random.Range(0.3f, 1f);
        yield return new WaitForSeconds(time);
        
        yield return SpawnEnemies();
    }

    private void GetRecord()
    {
        saveData.LoadFile();
        record.text = "Record: " + saveData.currentScore;
    }
}
