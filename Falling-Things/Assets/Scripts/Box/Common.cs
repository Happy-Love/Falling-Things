using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Common : Base
{
    public float DeleteTime;
    public LayerMask whatIsGround;
    void Start()
    {
        Destroy(gameObject, DeleteTime);
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterPlayer characterPlayer = collision.GetComponent<CharacterPlayer>();
        if (characterPlayer != null)
        {
            characterPlayer.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}