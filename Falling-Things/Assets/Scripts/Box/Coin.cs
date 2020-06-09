using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coins;
    [SerializeField] private float deleteTime;
    private void Start()
    {
        Destroy(gameObject, deleteTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character characterPlayer = collision.GetComponent<Character>();
        if (characterPlayer != null)
        {
            characterPlayer.TakeCoins(coins);
            Destroy(gameObject);
        }
    }
}
