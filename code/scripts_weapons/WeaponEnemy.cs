using UnityEngine;
using System.Collections;

namespace Eses.ObjectPooling
{

    // Copyright Sami S.

    // use of any kind without a written permission 
    // from the author is not allowed.

    // DO NOT:
    // Fork, clone, copy or use in any shape or form.

    public class WeaponEnemy : MonoBehaviour
    {

        [Header("Settings")]
        [SerializeField] float shotDelayMax = 2f;
        [SerializeField] float shotDelay;
        [SerializeField] Transform[] bulletSources;

        [Header("Settings pooling")]
        [SerializeField] string bulletPoolerName;

        // local
        Pool bulletPooler;


        void Start()
        {
            bulletPooler = GameObject.Find(bulletPoolerName).GetComponent<Pool>();
        }


        void Update()
        {
            if (shotDelay > 0f)
            {
                shotDelay -= Time.deltaTime;
            }

            if (shotDelay <= 0f)
            {
                shotDelay = shotDelayMax;
                ShootBullet();
            }
        }


        void ShootBullet()
        {
            foreach (Transform bSource in bulletSources)
            {
                // Get bullet from pool
                GameObject bullet = bulletPooler.SpawnObject();

                if (bullet != null)
                {
                    Vector3 dir = bSource.position - transform.position;
                    bullet.GetComponent<Bullet>().Setup(bSource, Quaternion.identity, dir);
                }
            }

        }

    }

}