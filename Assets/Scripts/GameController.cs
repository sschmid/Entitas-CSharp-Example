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
        var systems = new Systems();
        systems.Add(pool.CreateSystem<CreatePlayerSystem>());
        systems.Add(pool.CreateSystem<CreateOpponentsSystem>());
        systems.Add(pool.CreateSystem<CreateFinishLineSystem>());

        systems.Add(pool.CreateSystem<RemoveViewSystem>());
        systems.Add(pool.CreateSystem<AddViewSystem>());

        systems.Add(pool.CreateSystem<InputSystem>());
        systems.Add(pool.CreateSystem<AccelerateSystem>());
        systems.Add(pool.CreateSystem<MoveSystem>());
        systems.Add(pool.CreateSystem<ReachedFinishSystem>());
        systems.Add(pool.CreateSystem<RenderPositionSystem>());

        systems.Add(pool.CreateSystem<DestroySystem>());
        return systems;
    }
}
