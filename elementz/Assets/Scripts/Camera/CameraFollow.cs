using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elementz.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        protected void LateUpdate()
        {
            Vector3 desiredPosition = m_targetTransform.position + m_offset;

            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref m_velocity, m_smoothSpeed);
            transform.position = smoothedPosition;
            transform.LookAt(m_lookAt);

            float horizontal2 = Input.GetAxis("Horizontal2");
            float vertical2 = Input.GetAxis("Vertical2");

            m_angleX += horizontal2 * Time.deltaTime * m_rotationSpeed;
            m_angleY += vertical2 * Time.deltaTime * m_rotationSpeed;

            transform.RotateAround(m_lookAt.position, Vector3.up, m_angleX);
            transform.RotateAround(m_lookAt.position, Vector3.right, m_angleY);
        }

        [SerializeField]
        public Transform m_targetTransform;

        [SerializeField]
        public Transform m_lookAt;

        [SerializeField]
        public float m_smoothSpeed;

        [SerializeField]
        public Vector3 m_offset;

        [SerializeField]
        public float m_rotationSpeed;

        private Vector3 m_velocity;

        private float m_angleX;
        private float m_angleY;
    }
}
