using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform SpawnPos;
    public GameObject[] Boxes;
    public float TimeSpawn;
    public float min_x = -3.6f;
    public float max_x = 3.6f;
    

    void Start()
    {
        StartCoroutine(SpawnCD());
    }

    void Repeat() 
    {
        SpawnPos.position=new Vector3(Random.Range(min_x,max_x), SpawnPos.position.y);
        StartCoroutine(SpawnCD());
    }

    IEnumerator SpawnCD() 
    {
        yield return new WaitForSeconds(TimeSpawn);
        Instantiate(Boxes[Random.Range(0,4)], SpawnPos.position, Quaternion.identity);
        Repeat();
    }
}
