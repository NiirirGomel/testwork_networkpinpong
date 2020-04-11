using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pong
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Player.PlayerSetup firstPlayer = default;
        [SerializeField] private Player.PlayerSetup secondPlayer = default;
        [Space]
        [SerializeField] private Player.PlayerController firstPlayerController = default;
        [SerializeField] private Player.PlayerController secondPlayerController = default;
        [Space]
        [SerializeField] private Ball ballPrefab = default;
        [SerializeField] private Transform ballPoint = default;
        [SerializeField] private float ballRespawnTime = 3f;
        [SerializeField] private int pointsToWin = 5;
        [Space]
        [SerializeField] private GameUI ui = default;


        private Player.Player[] players = new Player.Player[2];
        private Ball ball = default;

        private void Start()
        {
            firstPlayerController.Player = players[0] = new Player.Player(firstPlayer);
            secondPlayerController.Player = players[1] = new Player.Player(secondPlayer);
            foreach (var p in players) p.OnDamaged += PlayerDamaged;

            ui.HideWin();
            ui.ShowScore(players[1].Damage, players[0].Damage);

            ball = Instantiate(ballPrefab, ballPoint);
            
            ball.Spawn();
            ball.StartMove(Vector2.right);
        }

        private void PlayerDamaged(Player.Player player)
        {
            ball.Destroy();
            ui.ShowScore(players[1].Damage, players[0].Damage);
            if (player.Damage == pointsToWin)
            {
                ui.ShowWin(player == players[0] ? "Right" : "Left");
                return;
            }
            StartCoroutine(BallRespawn(player == players[0] ? Vector2.right : Vector2.left));
        }

        private IEnumerator BallRespawn(Vector2 dir)
        {
            yield return new WaitForSeconds(ballRespawnTime);
            ball.Spawn();
            ball.StartMove(dir);
        }
    }
}
