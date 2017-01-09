using Entitas;

public sealed class CreatePlayerSystem : ISetPool, IInitializeSystem {

    Context _pool;

    public void SetPool(Context pool) {
        _pool = pool;
    }

    public void Initialize() {
        _pool.CreateEntity()
            .AddResource("Player")
            .AddPosition(0, 0, 0)
            .AddMove(0, 0.025f)
            .IsAcceleratable(true);
    }
}
