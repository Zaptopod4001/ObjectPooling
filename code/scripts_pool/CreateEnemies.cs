using UnityEngine;
using System.Collections;

namespace Eses.ObjectPooling
{

    // Copyright Sami S.

    // use of any kind without a written permission 
    // from the author is not allowed.

    // DO NOT:
    // Fork, clone, copy or use in any shape or form.

    public class CreateEnemies : MonoBehaviour
    {

        [Header("Settings")]
        [SerializeField] float spawnDelayMax = 4f;
        [SerializeField] Pool enemyPooler;
        [SerializeField] BoxCollider2D col2D;

        // local
        float spawnDelay;

        void Update()
        {
            spawnDelay += Time.deltaTime;

            // Shoot
            if (spawnDelay >= spawnDelayMax)
            {
                SpawnEnemies();
                spawnDelay = 0;
            }
        }


        void SpawnEnemies()
        {
            var enemy = enemyPooler.SpawnObject();

            var bounds = col2D.bounds;
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = bounds.max.y;

            enemy.GetComponent<Enemy>().Setup(new Vector2(x, y), Vector3.up);
        }

    }

}