using Entitas;

public sealed class CreateFinishLineSystem : ISetPool, IInitializeSystem {

    Context _pool;

    public void SetPool(Context pool) {
        _pool = pool;
    }

    public void Initialize() {
        _pool.CreateEntity()
            .IsFinishLine(true)
            .AddResource("Finish Line")
            .AddPosition(9f, 7f, 0);
    }
}
