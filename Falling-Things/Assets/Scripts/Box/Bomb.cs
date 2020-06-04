using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bomb : Base
{
    public GameObject Explosion;
    
    public float delay = 2f;
    float countdown;
  
    public float force;
    public float checkRadiusExplosion;

    public LayerMask whatIsGround;
    public LayerMask playerMask;


    void Start()
    { 
        countdown = delay;
    }
    void Explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, checkRadiusExplosion, playerMask);
        foreach (var item in objects)
        {
            Vector2 direction = item.transform.position - transform.position;
            item.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
        GameObject explos = Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(explos, .5f);
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        CharacterPlayer characterPlayer = collision.collider.GetComponent<CharacterPlayer>();
        if (characterPlayer != null)
        {
            characterPlayer.TakeDamage(damage);
            Explode();
        }
        TilemapCollider2D tilemap = collision.collider.GetComponent<TilemapCollider2D>();
        if (tilemap != null)
        {
            Invoke("Explode", countdown);
        }
    }
    private void OnDrawGizmos()
    {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, checkRadiusExplosion);    
    }
}
