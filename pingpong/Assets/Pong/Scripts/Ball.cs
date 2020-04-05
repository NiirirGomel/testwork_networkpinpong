using UnityEngine;
using System.Collections;

namespace Pong
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball : MonoBehaviour
    {
        public float Speed = 5f;

        [SerializeField] private GameObject hideOnDestroy;
        [SerializeField] private ParticleSystem destruction;

        private Rigidbody2D body = default;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            body.velocity = body.velocity.normalized * Speed;
        }

        public void Spawn()
        {
            transform.position = Vector2.zero;
            hideOnDestroy.SetActive(true);
        }

        public void StartMove(Vector2 dir)
        {
            body.velocity = dir * Speed;
        }

        public void Destroy()
        {
            hideOnDestroy.SetActive(false);
            body.velocity = Vector2.zero;
            destruction.Play();
        }
    }
}
