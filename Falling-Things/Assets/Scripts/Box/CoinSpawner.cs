using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Spawner
{
    [SerializeField] private CharacterController2D character;
      
    private void Awake() {
        character = GetComponent<CharacterController2D>();
        //(m_JumpForce * m_JumpForce / m_Rigidbody2D.mass * m_Rigidbody2D.mass) / (2 * g)
    }
    protected override void Spawn()
    {
        
        spawnPos.position = new Vector3(Random.Range(screenBounds.x * -1, screenBounds.x), Random.Range(1.2f,8f));
        DropLoot();
    }

}
