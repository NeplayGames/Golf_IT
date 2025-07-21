using System;
using UnityEngine;

namespace NeplayGames.GolfIt.Ball
{
    public class BallController : MonoBehaviour
    {
        [SerializeField, Range(1, 30)] private float speed = 3f;

        private Quaternion initialRotation;
        private Quaternion opositeRotation;
        private bool changeInitialDirection = false;
        private float baseY;
        public event Action<bool> GameOver; 
        public event Action GotHit; 
        void Start()
        {
            baseY = transform.eulerAngles.y;
            // Set the two endpoints relative to the starting Y rotation
            initialRotation = Quaternion.Euler(0f, baseY, 0f);
            opositeRotation = Quaternion.Euler(0f, -baseY, 0f);
            
        }
        void Update()
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Obstacle"))
            {
                GameOver?.Invoke(false);
            }
            if (collision.collider.CompareTag("Hole"))
            {
                GameOver?.Invoke(true);
            }
        }

        public void ChangeDirection()
        {
            changeInitialDirection = !changeInitialDirection;
            GotHit?.Invoke();
            transform.rotation = changeInitialDirection ? opositeRotation : initialRotation;
        }
    }

}
