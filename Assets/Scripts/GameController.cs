using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {
    IEntitySystem[] _systems;

    void Start() {
        var repo = new EntityRepository(ComponentIds.TotalComponents);
        Random.seed = 42;
        createSystems(repo);
        createPlayer(repo);
        createOpponents(repo);
        createFinishLine(repo);
    }

    void createSystems(EntityRepository repo) {
        _systems = new [] {
            repo.CreateSystem<InputSystem>(),
            repo.CreateSystem<ProcessInputSystem>(),

            repo.CreateSystem<MoveSystem>(),
            repo.CreateSystem<ReachedFinishSystem>(),

            repo.CreateSystem<RenderSpawnSystem>(),
            repo.CreateSystem<RenderPositionSystem>(),
            repo.CreateSystem<RenderDespawnSystem>(),

            repo.CreateSystem<DestroySystem>()
        };
    }

    void createPlayer(EntityRepository repo) {
        var e = repo.CreateEntity();
        e.AddResource("Player");
        e.AddPosition(0, 0, 0);
        e.AddMove(0, 0.02f);
        e.isInputControlled = true;
    }

    void createOpponents(EntityRepository repo) {
        const string resourceName = "Opponent";
        for (int i = 1; i < 10; i++) {
            var e = repo.CreateEntity();
            e.AddResource(resourceName);
            e.AddPosition(i, 0, 0);
            var speed = Random.value * 0.01f;
            e.AddMove(speed, speed);
        }
    }

    void createFinishLine(EntityRepository repo) {
        var finishLine = repo.CreateEntity();
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
