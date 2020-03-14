using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Eses.ObjectPooling
{

    // Copyright Sami S.

    // use of any kind without a written permission 
    // from the author is not allowed.

    // DO NOT:
    // Fork, clone, copy or use in any shape or form.

    public class Pool : MonoBehaviour
    {

        [Header("Settings")]
        [SerializeField] GameObject objectToPool;
        [SerializeField] int poolSize = 20;

        [Header("Pool")]
        [SerializeField] List<GameObject> pool;

        void Start()
        {
            CreatePool();
        }



        // Pool ---------

        void CreatePool()
        {
            pool = new List<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                var pooled = CreatePoolItem();

                pool.Add(pooled);
            }
        }


        GameObject CreatePoolItem()
        {
            GameObject pooled = Instantiate(objectToPool) as GameObject;
            pooled.gameObject.SetActive(false);
            pooled.transform.SetParent(this.transform);
            return pooled;
        }



        // Spawn ----------

        public GameObject SpawnObject()
        {
            for (int i = 0; i < poolSize; i++)
            {
                if (!pool[i].activeSelf)
                {
                    return pool[i];
                }
            }

            // no free available 
            // create new
            var newItem = CreatePoolItem();
            pool.Add(newItem);

            return newItem;
        }

    }

}