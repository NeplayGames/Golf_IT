using TMPro;
using UnityEngine;
namespace NeplayGames.GolfIt
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI gameOverText;
        [SerializeField] private TextMeshProUGUI totalHitText;

        public void SetGameOverText(bool gameWon)
        {
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = gameWon ? "Game Won" : "Game Loss";
        }

        public void SetTotalHitText(int totalHit)
        {
            gameOverText.gameObject.SetActive(false);
            totalHitText.text = $"Total Hit : {totalHit}";
        }
    }
}