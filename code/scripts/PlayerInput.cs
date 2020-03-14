using UnityEngine;
using System.Collections;

namespace Eses.ObjectPooling
{

    // Copyright Sami S.

    // use of any kind without a written permission 
    // from the author is not allowed.

    // DO NOT:
    // Fork, clone, copy or use in any shape or form.

    public class PlayerInput : MonoBehaviour
    {

        [Header("Settings")]
        [SerializeField] float speed = 1f;

        void Update()
        {
            var inputX = Input.GetAxisRaw("Horizontal");
            var inputY = Input.GetAxisRaw("Vertical");
            var movement = Vector3.right * inputX + Vector3.up * inputY;

            this.transform.Translate(movement * speed * Time.deltaTime);
        }

    }

}