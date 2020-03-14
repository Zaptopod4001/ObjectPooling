using UnityEngine;
using System.Collections;

namespace Eses.ObjectPooling
{

    // Copyright Sami S.

    // use of any kind without a written permission 
    // from the author is not allowed.

    // DO NOT:
    // Fork, clone, copy or use in any shape or form.

    public class Enemy : MonoBehaviour, IPoolable
    {

        [Header("Settings")]
        [SerializeField] Vector2 moveDir = Vector2.down;
        [SerializeField] float speed = 2f;
        [SerializeField] string explosionPoolName;

        // local
        Pool explosionPool;


        void Awake()
        {
            explosionPool = GameObject.Find(explosionPoolName).GetComponent<Pool>();
        }


        public void Setup(Vector2 position, Vector3 dir)
        {
            moveDir = dir;
            this.transform.position = position;
            this.gameObject.SetActive(true);
        }

        void SpawnExplosion()
        {
            Debug.Log("SpawnExplosion");
            var exp = explosionPool.SpawnObject();
            exp.gameObject.SetActive(true);
            exp.transform.position = transform.position;
        }


        void Update()
        {
            this.transform.Translate(moveDir * Time.deltaTime * speed);
        }



        // Triggers ------

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Bullet")
            {
                Debug.Log("Bullet hit enemy");
                SpawnExplosion();
                Despawn();
            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Area"))
            {
                Despawn();
            }
        }



        // Pooling -------

        public void Despawn()
        {
            Debug.Log("Despawn");
            this.transform.position = Vector3.zero;
            this.gameObject.SetActive(false);
        }

    }

}
