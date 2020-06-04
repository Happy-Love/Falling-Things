using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public float speed;
    public Vector2 dir;
    public int damage;
    private void FixedUpdate()
    {
        transform.Translate(speed * dir * Time.fixedDeltaTime, Space.World);
    }
}
