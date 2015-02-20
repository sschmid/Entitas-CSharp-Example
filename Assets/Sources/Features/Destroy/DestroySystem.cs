using Entitas;

public class DestroySystem : IExecuteSystem, ISetPool {
    Pool _pool;
    Group _group;

    public void SetPool(Pool pool) {
        _pool = pool;
        _group = pool.GetGroup(Matcher.Destroy);
    }

    public void Execute() {
        foreach (var e in _group.GetEntities()) {
            _pool.DestroyEntity(e);
        }
    }
}

