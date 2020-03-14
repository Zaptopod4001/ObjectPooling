using UnityEngine;
using System.Collections;

namespace Eses.ObjectPooling
{

    // Copyright Sami S.

    // use of any kind without a written permission 
    // from the author is not allowed.

    // DO NOT:
    // Fork, clone, copy or use in any shape or form.

    public class PlayerCollision : MonoBehaviour
    {
        
        [Header("Settings")]
        [SerializeField] bool noCollide;

        void Restart()
        {
            this.gameObject.SetActive(false);
        }

        void Spawn()
        {
            this.gameObject.transform.position = Vector3.zero;
            this.gameObject.SetActive(true);
        }



        // Triggers -----

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "BulletEnemy" && !noCollide)
            {
                Restart();
                Invoke("Spawn", 1f);
            }
        }

    }

}