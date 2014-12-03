using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {
    EntityRepository _repo;

    IEntitySystem[] _systems;

    void Start() {
        Random.seed = 42;
        _repo = new EntityRepository(ComponentIds.TotalComponents);
        createSystems();
        createPlayer();
        createOpponents();
        createFinishLine();
    }

    void createSystems() {
        _systems = new [] {
            _repo.CreateSystem<InputSystem>(),

            _repo.CreateSystem<AccelerateSystem>(),
            _repo.CreateSystem<MoveSystem>(),
            _repo.CreateSystem<ReachedFinishSystem>(),

            _repo.CreateSystem<RenderSpawnSystem>(),
            _repo.CreateSystem<RenderPositionSystem>(),

            _repo.CreateSystem<DestroySystem>(),
            _repo.CreateSystem<RenderDespawnSystem>()
        };
    }

    void createPlayer() {
        var e = _repo.CreateEntity();
        e.AddResource("Player");
        e.AddPosition(0, 0, 0);
        e.AddMove(0, 0.025f);
        e.isAcceleratable = true;
    }

    void createOpponents() {
        const string resourceName = "Opponent";
        for (int i = 1; i < 10; i++) {
            var e = _repo.CreateEntity();
            e.AddResource(resourceName);
            e.AddPosition(i, 0, 0);
            var speed = Random.value * 0.02f;
            e.AddMove(speed, speed);
        }
    }

    void createFinishLine() {
        var finishLine = _repo.CreateEntity();
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
