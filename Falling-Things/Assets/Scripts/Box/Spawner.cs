using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected Transform spawnPos;
    [SerializeField] private GameObject[] objects;
    [SerializeField] private float timeSpawn;
    
    // Camera Settings
    protected Vector2 screenBounds;
    
    void Start()
    {
        StartCoroutine(Respawn());
    }
    IEnumerator Respawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeSpawn);
            screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            Spawn();
            Instantiate(objects[Random.Range(0, objects.Length)], spawnPos.position, Quaternion.identity);
        }
    }
    // 
    protected virtual void Spawn()
    {
        spawnPos.position = new Vector3(Random.Range(screenBounds.x * -1, screenBounds.x), spawnPos.position.y);
    }
}
