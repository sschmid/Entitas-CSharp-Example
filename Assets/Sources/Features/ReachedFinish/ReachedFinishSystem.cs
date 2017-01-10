using System.Collections.Generic;
using Entitas;

public sealed class ReachedFinishSystem : ReactiveSystem {

	Context _context;

    public ReachedFinishSystem(Contexts contexts) : base(contexts.game) {
        _context = contexts.game;
    }

    protected override Collector GetTrigger(Context context) {
        return context.CreateCollector(GameMatcher.Position);
    }

    protected override bool Filter(Entity entity) {
        return entity.hasPosition;
    }

    protected override void Execute(List<Entity> entities) {
        var finishLinePosY = _context.finishLineEntity.position.y;
        foreach(var e in entities) {
            if(e.position.y > finishLinePosY) {
                e.isDestroy = true;
            }
        }
    }
}

