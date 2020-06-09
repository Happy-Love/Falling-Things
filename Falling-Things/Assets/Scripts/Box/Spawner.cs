using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected Transform spawnPos;
    [System.Serializable]
    public class Loot {
        public string Name;
        public GameObject item;
        public int dropRarity;
    }
    public List<Loot> LootTable=new List<Loot>();
    private int DropChance;

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
            
        }
    }
    // 
    protected virtual void Spawn()
    {
        spawnPos.position = new Vector3(Random.Range(screenBounds.x * -1, screenBounds.x), spawnPos.position.y);
        DropLoot();
    }
    public  void DropLoot()
    {
        DropChance = Random.Range(0, 101);
        int calc_DropChance = Random.Range(0, 101);
        if (calc_DropChance > DropChance)
        {
          
            return;
        }
        if (calc_DropChance <= DropChance)
        {
            int itemWeight = 0;
            for (int i = 0; i < LootTable.Count; i++)
            {
                itemWeight += LootTable[i].dropRarity;
            }
            

            int randomValue = Random.Range(0, itemWeight);
            for (int j = 0; j < LootTable.Count; j++)
            {
                if (randomValue <= LootTable[j].dropRarity)
                {
                    Instantiate(LootTable[j].item, spawnPos.position, Quaternion.identity);
                    return;
                }
                randomValue -= LootTable[j].dropRarity;
             
            }
        }
    }
}
