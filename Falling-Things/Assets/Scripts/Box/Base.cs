using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public float Speed;
    public Vector2 Dir;
    public int Damage;

    //Fix for any time
    protected virtual void FixedUpdate()
    {
        transform.Translate(Speed * Dir * Time.fixedDeltaTime, Space.World);
    }
}
