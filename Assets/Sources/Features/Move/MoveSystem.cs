using Entitas;

public class MoveSystem : IEntitySystem, ISetEntityRepository {
    EntityCollection _collection;

    public void SetEntityRepository(EntityRepository repo) {
        _collection = repo.GetCollection(Matcher.AllOf(Matcher.Movable, Matcher.Position));
    }

    public void Execute() {
        foreach (var e in _collection.GetEntities()) {
            var pos = e.position;
            e.ReplacePosition(pos.x, pos.y + 0.01f, pos.z);
        }
    }
}

