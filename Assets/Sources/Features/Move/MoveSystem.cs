using Entitas;

public class MoveSystem : IEntitySystem, ISetEntityRepository {
    EntityCollection _collection;

    public void SetEntityRepository(EntityRepository repo) {
        _collection = repo.GetCollection(Matcher.AllOf(Matcher.Move, Matcher.Position));
    }

    public void Execute() {
        foreach (var e in _collection.GetEntities()) {
            var move = e.move;
            var pos = e.position;
            e.ReplacePosition(pos.x, pos.y + move.speed, pos.z);
        }
    }
}

