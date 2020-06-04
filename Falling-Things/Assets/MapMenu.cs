using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapMenu : MonoBehaviour
{
    public void PlayMap(int numMap)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + numMap);
    }

    public void RandomMap()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + Random.Range(1,5)); // 4 карты получается 
    }
}
