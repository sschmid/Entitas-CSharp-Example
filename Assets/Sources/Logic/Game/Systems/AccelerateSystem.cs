using System.Collections.Generic;
using Entitas;

public sealed class AccelerateSystem : ReactiveSystem<InputEntity> {

	IGroup<GameEntity> _group;

    public AccelerateSystem(Contexts contexts) : base(contexts.input) {
        _group = contexts.game.GetGroup(Matcher<GameEntity>.AllOf(GameMatcher.Acceleratable, GameMatcher.Move));
    }

    protected override Collector<InputEntity> GetTrigger(IContext<InputEntity> context) {
        return context.CreateCollector(InputMatcher.Accelerating, GroupEvent.AddedOrRemoved);
    }

    protected override bool Filter(InputEntity entity) {
        return true;
    }

    protected override void Execute(List<InputEntity> entities) {
        var accelerate = entities.SingleEntity().isAccelerating;
        foreach(var e in _group.GetEntities()) {
            var move = e.move;
            var speed = accelerate ? move.maxSpeed : 0;
            e.ReplaceMove(speed, move.maxSpeed);
        }
    }
}
