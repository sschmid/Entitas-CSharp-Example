using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {

    Systems _systems;

    void Start() {
        Random.InitState(42);

        var contexts = Contexts.sharedInstance;
        contexts.SetAllContexts();

        _systems = createSystems(contexts);
        _systems.Initialize();
    }

    void Update() {
        _systems.Execute();
    }

    Systems createSystems(Contexts contexts) {
        return new Feature("Systems")

            // Initialize
            .Add(new CreatePlayerSystem(contexts))
            .Add(new CreateOpponentsSystem(contexts))
            .Add(new CreateFinishLineSystem(contexts))

            // Input
            .Add(new InputSystem(contexts))

            // Update
            .Add(new AccelerateSystem(contexts))
            .Add(new MoveSystem(contexts))
            .Add(new ReachedFinishSystem(contexts))

            // Render
            .Add(new RemoveViewSystem(contexts))
            .Add(new AddViewSystem(contexts))
            .Add(new RenderPositionSystem(contexts))

            // Destroy
            .Add(new DestroySystem(contexts));
    }
}
