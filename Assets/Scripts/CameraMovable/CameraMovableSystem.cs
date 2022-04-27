using Leopotam.Ecs;
using Player;
using UnityEngine;

namespace CameraMovable
{
    sealed class CameraMovableSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerMovableComponent> playerMovableFilter = null;
        private readonly EcsFilter<CameraMovableComponent> cameraMovableFilter = null;
        
        private Vector3 _offsetFromFollowToCamera;
        private float _initY;
        
        
        public void Init()
        {
            foreach (var i in cameraMovableFilter)
            {
                foreach (var j in playerMovableFilter)
                {
                    ref var cameraMovableComponent = ref cameraMovableFilter.Get1(i);
                    ref var playerMovableComponent = ref playerMovableFilter.Get1(j);

                    Transform playerTransform = playerMovableComponent.playerMovement.transform;
                    Transform cameraTransform = cameraMovableComponent.cameraFollow.transform;

                    _offsetFromFollowToCamera = cameraTransform.position - playerTransform.position;
                    _initY = cameraTransform.position.y;
                }
            }

        }
        
        public void Run()
        {
            foreach (var i in cameraMovableFilter)
            {
                foreach (var j in playerMovableFilter)
                {
                    ref var cameraMovableComponent = ref cameraMovableFilter.Get1(i);
                    ref var playerMovableComponent = ref playerMovableFilter.Get1(i);

                    Transform playerTransform = playerMovableComponent.playerMovement.transform;

                    Vector3 position = playerTransform.position + _offsetFromFollowToCamera;
                    position.y = _initY;

                    cameraMovableComponent.cameraFollow.SetPosition(position);
                }
            }
        }
    }
}