using UnityEngine;
using System.Collections;

namespace Pong
{
    public class Roket : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        [Header("Border")]
        [SerializeField] private float maxTop = 4.5f;
        [SerializeField] private float maxDown = 4.5f;

        private new Transform transform = default;
        private Vector3 nextPos = default;

        private void Awake()
        {
            transform = base.transform;
            nextPos = transform.localPosition;
        }

        public void MoveUp(float deltaTime) => Move(1, deltaTime);

        public void MoveDown(float deltaTime) => Move(-1, deltaTime);

        private void Move(float dir, float deltaTime)
        {
            nextPos.y = Mathf.Clamp(nextPos.y + dir * speed * deltaTime, -maxDown, maxTop);
            transform.localPosition = nextPos;
        }
    }
}
