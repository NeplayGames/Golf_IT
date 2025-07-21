using UnityEngine;

namespace NeplayGames.GolfIt
{
    public class DirectionHelper : MonoBehaviour
    {
        [field: SerializeField] public Transform initializePoint { get; private set; }
        [SerializeField] private float rotationSpeed = 90f; // degrees per second

        private Quaternion leftRotation;
        private Quaternion rightRotation;
        private Quaternion currentTarget;
        private bool goingRight = true;
        public bool playBall{ private get; set; } = false;
        void Start()
        {
            float initialY = transform.eulerAngles.y;

            // Compute the left and right rotation targets based on the initial rotation
            leftRotation = Quaternion.Euler(0f, initialY - 90f, 0f);
            rightRotation = Quaternion.Euler(0f, initialY + 90f, 0f);

            // Start by going left
            currentTarget = leftRotation;
            goingRight = true; // After going left, we go right
        }

        void Update()
        {
            if (playBall) return;
            // Rotate toward current target
            transform.rotation = Quaternion.RotateTowards(transform.rotation, currentTarget, rotationSpeed * Time.deltaTime);

            // Check if we've reached the target rotation
            if (Quaternion.Angle(transform.rotation, currentTarget) < 0.1f)
            {
                // Toggle direction
                goingRight = !goingRight;
                currentTarget = goingRight ? rightRotation : leftRotation;
            }
        }
    }
}
