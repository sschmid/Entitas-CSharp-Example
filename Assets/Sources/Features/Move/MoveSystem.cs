using Entitas;

public sealed class MoveSystem : ISetPool, IExecuteSystem {

    Group _group;

    public void SetPool(Pool pool) {
        _group = pool.GetGroup(Matcher.AllOf(GameMatcher.Move, GameMatcher.Position));
    }

    public void Execute() {
        foreach (var e in _group.GetEntities()) {
            var move = e.move;
            var pos = e.position;
            e.ReplacePosition(pos.x, pos.y + move.speed, pos.z);
        }
    }
}

