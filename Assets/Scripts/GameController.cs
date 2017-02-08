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
            .Add(new InitSystems(contexts))

            // Input
            .Add(new InputSystem(contexts))

            // Update
            .Add(new GameSystems(contexts))

            // Render
            .Add(new ViewSystems(contexts))

            // Destroy
            .Add(new DestroySystem(contexts));
    }
}
