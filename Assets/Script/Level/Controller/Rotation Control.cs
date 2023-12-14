using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Level.Controller
{
    public class RotationControl : MonoBehaviour
    {
        private Vector3 pointA;
        private Vector3 pointB;

        public float rotationSpeed = 5f;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.pointB   = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                this.pointB.z = this.transform.position.z; 
            }

            if (Input.GetMouseButton(0))
            {
                // Lấy vị trí của con trỏ chuột
                var pointC = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pointC.z = this.transform.position.z; 

                // Tính vector AB và AC
                var vectorAb = this.pointB - this.transform.position;
                var vectorAc = pointC - this.transform.position;

                // Tính góc alpha
                var angle = Vector2.SignedAngle(vectorAb, vectorAc);

                // Xoay đối tượng
                this.transform.Rotate(Vector3.forward * angle * this.rotationSpeed * Time.deltaTime);

                
                this.pointB = pointC;
            }
        }
    }
}

