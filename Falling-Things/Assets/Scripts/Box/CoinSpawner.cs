using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Spawner
{
    [SerializeField] private Character character;
      
    private void Awake() {
        character = GetComponent<Character>();   
    }
    protected override void Spawn()
    {
        spawnPos.position = new Vector3(Random.Range(screenBounds.x * -1, screenBounds.x), Random.Range(1f,2f));
    }

}
