using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Pong
{
    [System.Serializable]
    public class GameUI
    {
        [SerializeField] private Text scoreField = default;
        [SerializeField] private string scoreTemplate = "{0} - {1}";
        [Space]
        [SerializeField] private Text winField = default;

        public void ShowWin(string playerName)
        {
            winField.text = $"{playerName} player win!";
            winField.enabled = true;
        }

        public void HideWin()
        {
            winField.enabled = false;
        }

        public void ShowScore(int leftScore, int rightScore)
        {
            scoreField.text = string.Format(scoreTemplate, leftScore, rightScore);
        }
    }
}