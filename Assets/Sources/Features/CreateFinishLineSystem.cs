using Entitas;

public class CreateFinishLineSystem : IInitializeSystem, ISetPool {
    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Initialize() {
        _pool.CreateEntity()
            .IsFinishLine(true)
            .AddResource("Finish Line")
            .AddPosition(9f, 7f, 0);
    }
}

