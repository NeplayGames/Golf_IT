using System;
using UnityEngine;

namespace NeplayGames.GolfIt.Ball
{
    public class BallController : MonoBehaviour
    {
        [SerializeField, Range(1, 30)] private float speed = 3f;

        private Quaternion leftRotation;
        private Quaternion rightRotation;
        private bool goingRight = true;
        private float baseY;
        void Start()
        {
            float dot = Vector3.Dot(transform.forward, Vector3.right);
            goingRight = dot >= 0f;
            baseY = transform.eulerAngles.y;

            // Set the two endpoints relative to the starting Y rotation
            leftRotation = Quaternion.Euler(0f, baseY, 0f);
            rightRotation = Quaternion.Euler(0f, -baseY, 0f);
            
        }
        void Update()
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        void OnCollisionEnter(Collision collision)
        {
        }

        public void ChangeDirection()
        {
            goingRight = !goingRight;
            transform.rotation = goingRight ? rightRotation : leftRotation;
        }
    }

}
