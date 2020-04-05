using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Player.PlayerSetup firstPlayer = default;
        [SerializeField] private Player.PlayerSetup secondPlayer = default;

        [SerializeField] private Ball ballPrefab = default;
        [SerializeField] private Transform ballPoint = default;
        [SerializeField] private Transform ballRespawnTime = default;
        [SerializeField] private int pointsToWin = 5;

        private Player.Player[] players = new Player.Player[2];
        private Ball ball = default;

        private void Start()
        {
            players[0] = new Player.Player(firstPlayer);
            players[1] = new Player.Player(secondPlayer);
            foreach (var p in players) p.OnDamaged += PlayerDamaged;

            ball = Instantiate(ballPrefab, ballPoint);
            
            ball.Spawn();
            ball.StartMove(Vector2.right);
        }

        private void Update()
        {
            var acceleration = Input.GetAxis("Vertical");
            if (acceleration > 0) players[0].Roket.MoveUp(Time.deltaTime);
            else if (acceleration < 0) players[0].Roket.MoveDown(Time.deltaTime);
        }

        private void PlayerDamaged(Player.Player player)
        {
            ball.Destroy();
            if (player.Points == pointsToWin) return;
            StartCoroutine(BallRespawn(player == players[0] ? Vector2.right : Vector2.left));
        }

        private IEnumerator BallRespawn(Vector2 dir)
        {
            yield return new WaitForSeconds(1f);
            ball.Spawn();
            ball.StartMove(dir);
        }
    }
}
