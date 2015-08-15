using System.Collections.Generic;
using Entitas;

public class DestroySystem : IReactiveSystem, ISetPool {

    public IMatcher trigger { get { return CoreMatcher.Destroy; } }

    public GroupEventType eventType { get { return GroupEventType.OnEntityAdded; } }

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            _pool.DestroyEntity(e);
        }
    }
}

