using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   private GameObject _player;

   private void Start()
   {
      _player = GameObject.FindWithTag("Player");
   }

   private void Update()
   {
      Vector3 playerPosition = _player.transform.position;
      Vector3 enemyPosition = gameObject.transform.position;
        
      if (playerPosition.x > (enemyPosition.x + 90))
      {
          Destroy(gameObject);
      }
   }
}
