using UnityEngine;

namespace NeplayGames.GolfIt.Ball
{
    public class BallController : MonoBehaviour
    {
        [SerializeField, Range(1, 30)] private float speed = 3f;
        void Update()
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        void OnCollisionEnter(Collision collision)
        {
            print("Game over");
        }
    }

}
