using System;
using NeplayGames.GolfIt.Ball;
using NUnit.Framework;
using UnityEngine;
namespace NeplayGames.GolfIt
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject ball;
        [SerializeField] private UIManager uIManager;
        [SerializeField] private DirectionHelper directionHelper;
        private BallController ballController;
        private int totalHit = 0;

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
            ballController.GameOver += GameOver;
            ballController.GotHit += BallHit;
            BallHit();
        }

        private void BallHit()
        {
            totalHit++;
            uIManager.SetTotalHitText(totalHit);
        }

        private void GameOver(bool gameOver)
        {
            Destroy(ballController.gameObject);
            uIManager.SetGameOverText(gameOver);
            playBall = false;
            totalHit = 0;
            directionHelper.playBall = false;
        }

        private void OnValidate()
        {
            Assert.IsNotNull(ball, $"{nameof(ball)} cannot be null in name");
            Assert.IsNotNull(directionHelper, $"{nameof(directionHelper)} cannot be null in name");
        }
    }
}