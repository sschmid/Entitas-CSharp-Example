using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {

    Systems _systems;

    void Start() {
        Random.InitState(42);

        var pools = Pools.sharedInstance;
        pools.SetAllPools();

        _systems = createSystems(pools.game);
        _systems.Initialize();
    }

    void Update() {
        _systems.Execute();
    }

    Systems createSystems(Pool pool) {
        return new Feature("Systems")

            // Initialize
            .Add(pool.CreateSystem(new CreatePlayerSystem()))
            .Add(pool.CreateSystem(new CreateOpponentsSystem()))
            .Add(pool.CreateSystem(new CreateFinishLineSystem()))

            // Input
            .Add(pool.CreateSystem(new InputSystem()))

            // Update
            .Add(pool.CreateSystem(new AccelerateSystem()))
            .Add(pool.CreateSystem(new MoveSystem()))
            .Add(pool.CreateSystem(new ReachedFinishSystem()))

            // Render
            .Add(pool.CreateSystem(new RemoveViewSystem()))
            .Add(pool.CreateSystem(new AddViewSystem()))
            .Add(pool.CreateSystem(new RenderPositionSystem()))

            // Destroy
            .Add(pool.CreateSystem(new DestroySystem()));
    }
}
