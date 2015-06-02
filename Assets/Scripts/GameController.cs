using UnityEngine;
using Entitas;
using Entitas.Unity.VisualDebugging;

public class GameController : MonoBehaviour {

    Systems _systems;

    void Start() {
        Random.seed = 42;

        #if (UNITY_EDITOR)
        var pool = new DebugPool(CoreComponentIds.TotalComponents, "Core Pool");
        #else
        var pool = new Pool(CoreComponentIds.TotalComponents);
        #endif

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
            .Add(pool.CreateSystem<CreatePlayerSystem>())
            .Add(pool.CreateSystem<CreateOpponentsSystem>())
            .Add(pool.CreateSystem<CreateFinishLineSystem>())

            .Add(pool.CreateSystem<RemoveViewSystem>())
            .Add(pool.CreateSystem<AddViewSystem>())

            .Add(pool.CreateSystem<InputSystem>())
            .Add(pool.CreateSystem<AccelerateSystem>())
            .Add(pool.CreateSystem<MoveSystem>())
            .Add(pool.CreateSystem<ReachedFinishSystem>())
            .Add(pool.CreateSystem<RenderPositionSystem>())

            .Add(pool.CreateSystem<DestroySystem>());
    }
}
