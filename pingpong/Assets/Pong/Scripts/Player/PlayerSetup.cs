using UnityEngine;
using System.Collections;

namespace Pong.Player
{
    [System.Serializable]
    public class PlayerSetup
    {
        public Gate Gate = default;
        public Roket Roket = default;
        public Transform RoketPoint = default;
    }

}