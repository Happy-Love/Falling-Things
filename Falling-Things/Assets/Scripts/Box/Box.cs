using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 3 типа коробок
public enum BoxType
{
    Fire=1,
    Frost=2,
    Poison=3
}
public class Box : MonoBehaviour
{
    private int hp;
    private BoxType type;
}
