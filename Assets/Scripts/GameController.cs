using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {

    Pool _pool;
    IExecuteSystem[] _systems;

    void Start() {
        Random.seed = 42;
        _pool = new Pool(ComponentIds.TotalComponents);
        createSystems();
        createPlayer();
        createOpponents();
        createFinishLine();
    }

    void createSystems() {
        _pool.CreateSystem<RenderDespawnSystem>();

        _systems = new [] {
            _pool.CreateSystem<InputSystem>(),

            _pool.CreateSystem<AccelerateSystem>(),
            _pool.CreateSystem<MoveSystem>(),
            _pool.CreateSystem<ReachedFinishSystem>(),

            _pool.CreateSystem<RenderSpawnSystem>(),
            _pool.CreateSystem<RenderPositionSystem>(),

            _pool.CreateSystem<DestroySystem>(),
        };
    }

    void createPlayer() {
        var e = _pool.CreateEntity();
        e.AddResource("Player");
        e.AddPosition(0, 0, 0);
        e.AddMove(0, 0.025f);
        e.isAcceleratable = true;
    }

    void createOpponents() {
        const string resourceName = "Opponent";
        for (int i = 1; i < 10; i++) {
            var e = _pool.CreateEntity();
            e.AddResource(resourceName);
            e.AddPosition(i, 0, 0);
            var speed = Random.value * 0.02f;
            e.AddMove(speed, speed);
        }
    }

    void createFinishLine() {
        var finishLine = _pool.CreateEntity();
        finishLine.isFinishLine = true;
        finishLine.AddResource("Finish Line");
        finishLine.AddPosition(4.5f, 3.5f, 0);
    }

    void Update() {
        foreach (var system in _systems) {
            system.Execute();
        }
    }
}
