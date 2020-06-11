using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] protected float Speed;
    [SerializeField] protected Vector2 Dir;
    //Fix for any time
    protected virtual void FixedUpdate()
    {
        transform.Translate(Speed * Dir * Time.fixedDeltaTime, Space.World);
    }
    public void SetSpeed(float speed)
    {
        Speed = speed;
    }
}
