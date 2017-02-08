using Entitas;

public sealed class CreateFinishLineSystem : IInitializeSystem {

    readonly Context _context;

    public CreateFinishLineSystem(Contexts contexts) {
        _context = contexts.game;
    }

    public void Initialize() {
		var e = _context.CreateEntity();
		e.isFinishLine = true;
		e.AddAsset("Finish Line");
		e.AddPosition(9f, 7f, 0);
    }
}
