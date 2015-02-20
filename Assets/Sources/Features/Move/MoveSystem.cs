using Entitas;

public class MoveSystem : IExecuteSystem, ISetPool {
    Group _group;

    public void SetPool(Pool pool) {
        _group = pool.GetGroup(Matcher.AllOf(Matcher.Move, Matcher.Position));
    }

    public void Execute() {
        foreach (var e in _group.GetEntities()) {
            var move = e.move;
            var pos = e.position;
            e.ReplacePosition(pos.x, pos.y + move.speed, pos.z);
        }
    }
}

