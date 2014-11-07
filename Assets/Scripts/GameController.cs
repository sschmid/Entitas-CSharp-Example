using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {
    IEntitySystem[] _systems;

    void Start() {
        var repo = new EntityRepository(ComponentIds.TotalComponents);
        createSystems(repo);
        createCubes(repo);
        createFinishLine(repo);
    }

    void createSystems(EntityRepository repo) {
        _systems = new [] {
            repo.CreateSystem<RenderSpawnSystem>(),
            repo.CreateSystem<MoveSystem>(),
            repo.CreateSystem<ReachedFinishSystem>(),
            repo.CreateSystem<RenderPositionSystem>(),
            repo.CreateSystem<RenderDespawnSystem>()
        };
    }

    void createCubes(EntityRepository repo) {
        const string resourceName = "Cube";
        for (int i = 0; i < 10; i++) {
            var e = repo.CreateEntity();
            e.AddResource(resourceName);
            e.AddPosition(i, 0, 0);
            e.isMovable = true;
        }
    }

    void createFinishLine(EntityRepository repo) {
        repo.isFinishLine = true;
        var finishLine = repo.finishLineEntity;
        finishLine.AddResource("Finish Line");
        finishLine.AddPosition(4.5f, 3.5f, 0);
    }

    void Update() {
        foreach (var system in _systems) {
            system.Execute();
        }
    }
}
