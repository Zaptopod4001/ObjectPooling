using UnityEngine;
using System.Collections;

namespace Eses.ObjectPooling
{

    // Copyright Sami S.

    // use of any kind without a written permission 
    // from the author is not allowed.

    // DO NOT:
    // Fork, clone, copy or use in any shape or form.

    public class Bullet : MonoBehaviour, IPoolable
    {

        [Header("Settings")]
        [SerializeField] float speed;
        [SerializeField] Vector3 bulletDir;
        [SerializeField] string areaTag = "Area";


        void Update()
        {
            this.transform.Translate(bulletDir * Time.deltaTime * speed);
        }


        // Spawning -------

        public void Setup(Transform tra, Quaternion rot, Vector3 dir)
        {
            bulletDir = dir;
            this.transform.position = tra.position;
            this.transform.rotation = rot;
            this.gameObject.SetActive(true);
        }


        // Triggers ------

        void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals(areaTag))
            {
                Despawn();
            }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag != areaTag)
                Despawn();
        }


        // Pooling --------

        public void Despawn()
        {
            this.gameObject.SetActive(false);
            this.transform.position = Vector3.zero;
        }

    }

}