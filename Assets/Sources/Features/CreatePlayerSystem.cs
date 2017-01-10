using Entitas;

public sealed class CreatePlayerSystem : IInitializeSystem {

    Context _context;

    public CreatePlayerSystem(Contexts contexts) {
        _context = contexts.game;
    }

    public void Initialize() {
        _context.CreateEntity()
            .AddResource("Player")
            .AddPosition(0, 0, 0)
            .AddMove(0, 0.025f)
            .IsAcceleratable(true);
    }
}
