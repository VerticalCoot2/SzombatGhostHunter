using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Muhahahahahahahaha")]
    [SerializeField] private float shootTime = 0.3f;
    [SerializeField] Transform firePoint;
    private float lastShootTime = 0;

    private GvrReticlePointer aimCross;

    private void FixedUpdate()
    {
        if (lastShootTime > Time.time - shootTime) return;
        var target = aimCross.CurrentRaycastResult;
        if(target.gameObject)
        {
            if(target.gameObject.tag == "Enemy")
            {
                Fire();
                lastShootTime = Time.time;
            }
        }
    }

    void Fire()
    {
        var projectile = ObjectPool.Instance.GetBullet();
        projectile.transform.position = firePoint.position;
        projectile.transform.rotation = Quaternion.Euler(90, 0, 0);
        projectile.gameObject.SetActive(true);
        projectile.GetComponent<Rigidbody>().velocity = Vector3.zero;
        projectile.GetComponent<Rigidbody>().AddForce(Bullet.bulletSpeed * firePoint.transform.forward);
    }
}
