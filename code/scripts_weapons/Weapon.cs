using UnityEngine;
using System.Collections;

namespace Eses.ObjectPooling
{

    // Copyright Sami S.

    // use of any kind without a written permission 
    // from the author is not allowed.

    // DO NOT:
    // Fork, clone, copy or use in any shape or form.

    public class Weapon : MonoBehaviour
    {

        [Header("Settings")]
        [SerializeField] float shotDelayMax = 0.5f;
        [SerializeField] float shotDelay;

        [Header("Settings pooling")]
        [SerializeField] Pool bulletPool;
        [SerializeField] Transform bulletSource;


        void Update()
        {
            if (shotDelay > 0f)
                shotDelay -= Time.deltaTime;


            // Shoot
            if (shotDelay <= 0f && Input.GetKey(KeyCode.Space))
            {
                shotDelay = shotDelayMax;

                ShootBullet();
            }
        }


        void ShootBullet()
        {
            // Get bullet from pool
            GameObject bullet = bulletPool.SpawnObject();

            if (bullet != null)
            {
                bullet.GetComponent<Bullet>().Setup(bulletSource, bulletSource.rotation, Vector3.up);
            }
        }

    }

}