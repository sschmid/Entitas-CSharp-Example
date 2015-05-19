using Entitas;

public class CreatePlayerSystem : IStartSystem, ISetPool {
    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Start() {
        _pool.CreateEntity()
            .AddResource("Player")
            .AddPosition(0, 0, 0)
            .AddMove(0, 0.025f)
            .IsAcceleratable(true);
    }
}

