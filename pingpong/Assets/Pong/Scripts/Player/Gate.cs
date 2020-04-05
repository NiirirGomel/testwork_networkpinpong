using UnityEngine;
using System.Collections;

namespace Pong.Player
{
    [RequireComponent(typeof(Collider2D))]
    public class Gate : MonoBehaviour
    {
        public delegate void ActionDelegate();
        public event ActionDelegate OnCollisionBall;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<Ball>(out var ball))
                OnCollisionBall?.Invoke();
        }
    }
}
