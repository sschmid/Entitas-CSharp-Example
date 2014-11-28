using Entitas;

public class DestroySystem : IEntitySystem, ISetEntityRepository {
    EntityRepository _repo;
    EntityCollection _collection;

    public void SetEntityRepository(EntityRepository repo) {
        _repo = repo;
        _collection = repo.GetCollection(Matcher.Destroy);
    }

    public void Execute() {
        foreach (var e in _collection.GetEntities()) {
            _repo.DestroyEntity(e);
        }
    }
}

