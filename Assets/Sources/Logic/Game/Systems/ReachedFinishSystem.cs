using System.Collections.Generic;
using Entitas;

public sealed class ReachedFinishSystem : ReactiveSystem<GameEntity> {

	GameContext _context;

    public ReachedFinishSystem(Contexts contexts) : base(contexts.game) {
        _context = contexts.game;
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Position);
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasPosition;
    }

    protected override void Execute(List<GameEntity> entities) {
        var finishLinePosY = _context.finishLineEntity.position.y;
        foreach(var e in entities) {
            if(e.position.y > finishLinePosY) {
                e.isDestroyed = true;
            }
        }
    }
}

