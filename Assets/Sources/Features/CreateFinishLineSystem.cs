using Entitas;

public sealed class CreateFinishLineSystem : IInitializeSystem {
    readonly Context _context;

    public CreateFinishLineSystem(Contexts contexts) {
        _context = contexts.game;
    }

    public void Initialize() {
        _context.CreateEntity()
            .IsFinishLine(true)
            .AddResource("Finish Line")
            .AddPosition(9f, 7f, 0);
    }
}
