using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Base
{
    public int LootClicks=5;
    public int coins=1000;
    public float DeleteTime=10f;
    public Animator Animator;
    [SerializeField] private float damage;
    void Start()
    {
        Destroy(gameObject, DeleteTime);
    }
    public void OnMouseDown()
    {
        if (LootClicks == 0)
        {
            Animator.SetBool("IsOpen", true);
            Character character = FindObjectOfType<Character>();
            if (character != null)
            {
                character.TakeCoins(coins);
            }
            Destroy(gameObject,2f);
        }
        else {
            LootClicks -= 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character characterPlayer = collision.GetComponent<Character>();
        if (characterPlayer != null)
        {
            characterPlayer.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
