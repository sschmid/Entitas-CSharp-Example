using Entitas;
using UnityEngine;

public sealed class CreateOpponentsSystem : IInitializeSystem {
    readonly Context _context;

    public CreateOpponentsSystem(Contexts contexts) {
        _context = contexts.game;
    }

    public void Initialize() {
        const string resourceName = "Opponent";
        for(int i = 1; i < 10; i++) {
            var speed = Random.value * 0.02f;
            _context.CreateEntity()
                .AddResource(resourceName)
                .AddPosition(i + i, 0, 0)
                .AddMove(speed, speed);
        }
    }
}
