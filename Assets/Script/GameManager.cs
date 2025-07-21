using System;
using NeplayGames.GolfIt.Ball;
using NUnit.Framework;
using UnityEngine;
namespace NeplayGames.GolfIt
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject ball;

        [SerializeField] private DirectionHelper directionHelper;
        private BallController ballController;
        private bool playBall = false;
        void OnMovement()
        {
            if (!playBall)
            {
                InitizeBall();
            }
            else
            {
                ballController.ChangeDirection();
            }
        }

        private void InitizeBall()
        {
            ballController = Instantiate(ball, directionHelper.initializePoint.position,
                                directionHelper.transform.rotation).GetComponent<BallController>();
            playBall = true;
            directionHelper.playBall = true;
        }

        private void OnValidate()
        {
            Assert.IsNotNull(ball, $"{nameof(ball)} cannot be null in name");
            Assert.IsNotNull(directionHelper, $"{nameof(directionHelper)} cannot be null in name");
        }
    }
}