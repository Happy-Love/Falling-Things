using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    protected float Speed;
    protected Vector2 Dir;
    //Fix for any time
    protected virtual void FixedUpdate()
    {
        transform.Translate(Speed * Dir * Time.fixedDeltaTime, Space.World);
    }
}
