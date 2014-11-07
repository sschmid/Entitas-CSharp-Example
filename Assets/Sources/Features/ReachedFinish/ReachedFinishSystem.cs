using Entitas;

public class ReachedFinishSystem : IReactiveSubEntitySystem, ISetEntityRepository {
    public IEntityMatcher GetTriggeringMatcher() {
        return Matcher.Position;
    }

    public EntityCollectionEventType GetEventType() {
        return EntityCollectionEventType.OnEntityAdded;
    }

    EntityRepository _repo;

    public void SetEntityRepository(EntityRepository repo) {
        _repo = repo;
    }

    public void Execute(Entity[] entities) {
        var finishLine = _repo.finishLineEntity;
        foreach (var e in entities) {
            if (e.position.y > finishLine.position.y) {
                _repo.DestroyEntity(e);
            }
        }
    }
}

