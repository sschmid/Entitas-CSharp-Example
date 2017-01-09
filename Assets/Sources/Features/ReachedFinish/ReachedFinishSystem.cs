using System.Collections.Generic;
using Entitas;

public sealed class ReachedFinishSystem : ISetPool, IReactiveSystem {

    public TriggerOnEvent trigger { get { return GameMatcher.Position.OnEntityAdded(); } }

    Context _pool;

    public void SetPool(Context pool) {
        _pool = pool;
    }

    public void Execute(List<Entity> entities) {
        var finishLinePosY = _pool.finishLineEntity.position.y;
        foreach(var e in entities) {
            if(e.position.y > finishLinePosY) {
                e.isDestroy = true;
            }
        }
    }
}

