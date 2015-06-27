using UnityEngine;
using Entitas;
using Entitas.Unity.VisualDebugging;

public class GameController : MonoBehaviour {

    Systems _systems;

    void Start() {
        Random.seed = 42;

        var pool = Pools.core;
        _systems = createSystems(pool);
        _systems.Start();
    }

    void Update() {
        _systems.Execute();
    }

    Systems createSystems(Pool pool) {
        #if (UNITY_EDITOR)
        return new DebugSystems()
        #else
        return new Systems()
        #endif
            .Add(pool.CreateCreatePlayerSystem())
            .Add(pool.CreateCreateOpponentsSystem())
            .Add(pool.CreateCreateFinishLineSystem())

            .Add(pool.CreateRemoveViewSystem())
            .Add(pool.CreateAddViewSystem())

            .Add(pool.CreateInputSystem())
            .Add(pool.CreateAccelerateSystem())
            .Add(pool.CreateMoveSystem())
            .Add(pool.CreateReachedFinishSystem())
            .Add(pool.CreateRenderPositionSystem())

            .Add(pool.CreateDestroySystem());
    }
}
