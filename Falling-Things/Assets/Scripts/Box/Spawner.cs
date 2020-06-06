using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform spawnPos;
    [SerializeField] private GameObject[] boxes;
    [SerializeField] private float timeSpawn;
    [SerializeField] private float min_x = -3.6f;
    [SerializeField] private float max_x = 3.6f;
    

    void Start()
    {
        StartCoroutine(SpawnCD());
    }

  

    IEnumerator SpawnCD() 
    {
        while (true)
        {
            yield return new WaitForSeconds(timeSpawn);
            var screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            spawnPos.position = new Vector3(Random.Range(screenBounds.x*-1, screenBounds.x), spawnPos.position.y);
            Instantiate(boxes[Random.Range(0, 4)], spawnPos.position, Quaternion.identity);   
        }
    }
}
