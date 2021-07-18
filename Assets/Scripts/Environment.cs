using UnityEngine;

public class Environment : MonoBehaviour
{
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        Vector3 playerPosition = _player.transform.position;
        Vector3 environmentPos = gameObject.transform.position;
        
        if (playerPosition.x > (environmentPos.x + 90))
        {
            
            var posX = transform.position.x + 180;
            gameObject.transform.position = new Vector3(posX, 0, 0);
        }
    }
}
