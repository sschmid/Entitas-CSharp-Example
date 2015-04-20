using UnityEngine;
using Entitas;
using Entitas.Unity.VisualDebugging;

public class GameController : MonoBehaviour {

    Pool _pool;
    IStartSystem[] _startSystems;
    IExecuteSystem[] _executeSystems;

    void Start() {
        Random.seed = 42;

        #if (UNITY_EDITOR)
        _pool = new DebugPool(CoreComponentIds.TotalComponents);
        #else
        _pool = new Pool(CoreComponentIds.TotalComponents);
        #endif

        createStartSystems();
        createExecuteSystems();

        startSystems();
    }

    void createStartSystems() {
        _startSystems = new [] {
            _pool.CreateStartSystem<CreatePlayerSystem>(),
            _pool.CreateStartSystem<CreateOpponentsSystem>(),
            _pool.CreateStartSystem<CreateFinishLineSystem>()
        };
    }

    void createExecuteSystems() {
        _executeSystems = new [] {
            _pool.CreateExecuteSystem<RemoveViewSystem>(),
            _pool.CreateExecuteSystem<AddViewSystem>(),
            
            _pool.CreateExecuteSystem<InputSystem>(),

            _pool.CreateExecuteSystem<AccelerateSystem>(),
            _pool.CreateExecuteSystem<MoveSystem>(),
            _pool.CreateExecuteSystem<ReachedFinishSystem>(),

            _pool.CreateExecuteSystem<RenderPositionSystem>(),

            _pool.CreateExecuteSystem<DestroySystem>(),
        };
    }

    void startSystems() {
        foreach (var system in _startSystems) {
            system.Start();
        }
    }

    void Update() {
        foreach (var system in _executeSystems) {
            system.Execute();
        }
    }
}
