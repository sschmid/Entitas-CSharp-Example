using Entitas;

public sealed class InitPlayerSystem : IInitializeSystem {

    GameContext _context;

    public InitPlayerSystem(Contexts contexts) {
        _context = contexts.game;
    }

    public void Initialize() {
        var e = _context.CreateEntity();
        e.AddAsset("Player");
        e.AddPosition(0, 0, 0);
        e.AddMove(0, 0.025f);
        e.isAcceleratable = true;
    }
}
