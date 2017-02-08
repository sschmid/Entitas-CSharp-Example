using System.Collections.Generic;
using Entitas;

public sealed class AccelerateSystem : ReactiveSystem {

	Group _group;

    public AccelerateSystem(Contexts contexts) : base(contexts.input) {
        _group = contexts.game.GetGroup(Matcher.AllOf(GameMatcher.Acceleratable, GameMatcher.Move));
    }

    protected override Collector GetTrigger(Context context) {
        return context.CreateCollector(InputMatcher.Accelerating, GroupEvent.AddedOrRemoved);
    }

    protected override bool Filter(Entity entity) {
        return true;
    }

    protected override void Execute(List<Entity> entities) {
        var accelerate = entities.SingleEntity().isAccelerating;
        foreach(var e in _group.GetEntities()) {
            var move = e.move;
            var speed = accelerate ? move.maxSpeed : 0;
            e.ReplaceMove(speed, move.maxSpeed);
        }
    }
}
