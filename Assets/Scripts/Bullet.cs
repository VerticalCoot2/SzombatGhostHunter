using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static float bulletSpeed = 1000;
    private static int bulletDamage = 100;

    public static int Damage { get { return bulletDamage; } set { bulletDamage = value; } }
}
