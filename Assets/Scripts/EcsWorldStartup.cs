using System;
using System.Collections;
using System.Collections.Generic;
using CameraMovable;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
using Player;
using Input;
using Text;

public sealed class EcsWorldStartup : MonoBehaviour
{
    private EcsWorld world;
    private EcsSystems systems;

    private void Start()
    {
        world = new EcsWorld();
        systems = new EcsSystems(world);

        systems.ConvertScene();
            
        AddSystems();
        AddInjections();
        AddOneFrames();
        
        systems.Init();
    }

    private void AddInjections()
    {
        systems
            .Add(new MovementSystem())
            .Add(new InputSystem())
            .Add(new CoinReceivingSystem())
            .Add(new TextSystem())
            .Add(new CameraMovableSystem());
    }

    private void AddOneFrames()
    {
        
    }

    private void AddSystems()
    {
        
    }

    private void Update()
    {
        systems.Run();
    }

    private void OnDestroy()
    {
        if (systems == null) return;
        
        systems.Destroy();
        systems = null;
        
        world.Destroy();
        world = null;
    }
}
