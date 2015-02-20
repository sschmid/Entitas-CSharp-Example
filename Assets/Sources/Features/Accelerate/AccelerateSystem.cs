using Entitas;

public class AccelerateSystem : IReactiveSystem, ISetPool {
    public IMatcher GetTriggeringMatcher() {
        return Matcher.Accelerate;
    }

    public GroupEventType GetEventType() {
        return GroupEventType.OnEntityAddedOrRemoved;
    }

    Group _group;

    public void SetPool(Pool pool) {
        _group = pool.GetGroup(Matcher.AllOf(Matcher.Acceleratable, Matcher.Move));
    }

    public void Execute(Entity[] entities) {
        var accelerate = entities.SingleEntity().isAccelerate;
        foreach (var e in _group.GetEntities()) {
            var move = e.move;
            var speed = accelerate ? move.maxSpeed : 0;
            e.ReplaceMove(speed, move.maxSpeed);
        }
    }
}

