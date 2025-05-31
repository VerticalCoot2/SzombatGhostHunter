using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public Bullet bulletPrefab;
    private Queue<Bullet> bullets = new Queue<Bullet>();

    public static ObjectPool Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public Bullet GetBullet()
    {
        if(bullets.Count == 0)
        {
            Bullet projectile = Instantiate(bulletPrefab);
            projectile.gameObject.SetActive(false);
            bullets.Enqueue(projectile);
        }
        return bullets.Dequeue();
    }

    public void ReturnToPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullets.Enqueue(bullet);
    }
}
