using Entitas;

public class CreatePlayerSystem : IStartSystem, ISetPool {
    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Start() {
        var e = _pool.CreateEntity();
        e.AddResource("Player");
        e.AddPosition(0, 0, 0);
        e.AddMove(0, 0.025f);
        e.isAcceleratable = true;
    }
}

