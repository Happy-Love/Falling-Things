using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Base
{
    public GameObject HealEffect;
    [SerializeField] private float heal = 10f;
    [SerializeField] private float DeleteTime;
    void Start()
    {
        Destroy(gameObject, DeleteTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character characterPlayer = collision.GetComponent<Character>();
        if (characterPlayer != null)
        {
            characterPlayer.TakeHeal(heal);
            GameObject heal_e = Instantiate(HealEffect, transform.position, transform.rotation);
            Destroy(heal_e, .5f);
            Destroy(gameObject);
        }
    }
}
