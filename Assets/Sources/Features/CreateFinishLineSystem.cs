using Entitas;

public class CreateFinishLineSystem : IStartSystem, ISetPool{
    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Start() {
        var finishLine = _pool.CreateEntity();
        finishLine.isFinishLine = true;
        finishLine.AddResource("Finish Line");
        finishLine.AddPosition(4.5f, 3.5f, 0);
    }
}

