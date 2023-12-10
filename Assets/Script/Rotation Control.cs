using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class RotationControl : MonoBehaviour
    {
        public float rotationSpeed = 5f;

        private Vector3 lastMousePosition;

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                this.RotateObjectsInLevel();
            }
            this.lastMousePosition = Input.mousePosition;
        }

        private void RotateObjectsInLevel()
        {
            var mouseDeltaY       = Input.mousePosition.y - this.lastMousePosition.y;
            var rotationDirection = (mouseDeltaY > 0) ? 1 : -1;

            this.transform.Rotate(Vector3.forward * rotationDirection * this.rotationSpeed * Time.deltaTime);

            foreach (Transform child in this.transform)
            {
                if (child.GetComponent<Rigidbody2D>() == null)
                {
                    child.Rotate(Vector3.forward * rotationDirection * this.rotationSpeed * Time.deltaTime);
                }
            }
        }
    }
}

