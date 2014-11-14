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
        var finishLinePosY = _repo.finishLineEntity.position.y;
        foreach (var e in entities) {
            if (e.position.y > finishLinePosY) {
                _repo.DestroyEntity(e);
            }
        }
    }
}

