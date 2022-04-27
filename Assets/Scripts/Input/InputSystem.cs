using Leopotam.Ecs;
using UnityEngine;
using Player;

namespace Input
{
    sealed class InputSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerMovableComponent> movableFilter = null;
        public void Run()
        {
            foreach (var i in movableFilter)
            {
                ref var movableComponent = ref movableFilter.Get1(i);
                ref int direction = ref movableComponent.directionIndex;
                
                if (UnityEngine.Input.GetMouseButtonDown(0))
                {
                    direction = direction == 0 ? 1 : 0;
                }
            }
        }
    }
}