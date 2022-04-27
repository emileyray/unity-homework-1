using Leopotam.Ecs;
using UnityEngine;

namespace Player
{
    sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerMovableComponent> movableFilter = null;

        public void Run()
        {
            foreach (var i in movableFilter)
            {
                ref var movableComponent = ref movableFilter.Get1(i);
                int direction = movableComponent.directionIndex;
                float speed = movableComponent.speed;
                
                movableComponent.playerMovement.Move(direction, speed);
            }
        }
    }
}