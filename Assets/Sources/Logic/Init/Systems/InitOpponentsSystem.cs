using Entitas;
using UnityEngine;

public sealed class InitOpponentsSystem : IInitializeSystem {

    readonly Context _context;

    public InitOpponentsSystem(Contexts contexts) {
        _context = contexts.game;
    }

    public void Initialize() {
        const string resourceName = "Opponent";
        for(int i = 1; i < 10; i++) {
            var speed = Random.value * 0.02f;
            var e = _context.CreateEntity();
            e.AddAsset(resourceName);
            e.AddPosition(i + i, 0, 0);
            e.AddMove(speed, speed);
        }
    }
}
