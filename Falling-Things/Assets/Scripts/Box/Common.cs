﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Common : Base
{
    public float DeleteTime;
    [SerializeField] private float damage;
    void Start()
    {
        Destroy(gameObject, DeleteTime);
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