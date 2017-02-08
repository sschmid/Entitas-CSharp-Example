using Entitas;

public sealed class InitFinishLineSystem : IInitializeSystem {

    readonly GameContext _context;

    public InitFinishLineSystem(Contexts contexts) {
        _context = contexts.game;
    }

    public void Initialize() {
		var e = _context.CreateEntity();
		e.isFinishLine = true;
		e.AddAsset("Finish Line");
		e.AddPosition(9f, 7f, 0);
    }
}
