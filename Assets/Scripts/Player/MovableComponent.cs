using System;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Player
{
    [Serializable]
    public struct PlayerMovableComponent
    {
        public PlayerMovement playerMovement;
        public float speed;
        public int directionIndex;
    }
}