using UnityEngine;

namespace Pong.Player
{
    public class PlayerController : MonoBehaviour
    {
        public Player Player { get; set; }

        [SerializeField] private string MoveAxisName = "Vertical";

        private void Update()
        {
            if (Player == null) return;
            var acceleration = Input.GetAxis(MoveAxisName);
            if (acceleration > 0) Player.Roket.MoveUp(Time.deltaTime);
            else if (acceleration < 0) Player.Roket.MoveDown(Time.deltaTime);
        }
    }
}
