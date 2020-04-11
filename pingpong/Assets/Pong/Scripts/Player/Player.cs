using UnityEngine;
using System.Collections;

namespace Pong.Player
{
    public class Player
    {
        public delegate void DamagedDelegate(Player player);
        public event DamagedDelegate OnDamaged;
        public Roket Roket { get; private set; }
        public int Damage { get; private set; }

        private PlayerSetup setup;

        public Player(PlayerSetup setup)
        {
            this.setup = setup;
            Roket = GameObject.Instantiate(setup.Roket, setup.RoketPoint);
            setup.Gate.OnCollisionBall += () =>
            {
                Damage = Mathf.Max(Damage + 1, 0);
                OnDamaged?.Invoke(this);
            };
        }
    }
}
