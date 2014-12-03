using Entitas;

public class AccelerateSystem : IReactiveSubEntitySystem, ISetEntityRepository {
    public IEntityMatcher GetTriggeringMatcher() {
        return Matcher.Accelerate;
    }

    public EntityCollectionEventType GetEventType() {
        return EntityCollectionEventType.OnEntityAddedOrRemoved;
    }

    EntityCollection _collection;

    public void SetEntityRepository(EntityRepository repo) {
        _collection = repo.GetCollection(Matcher.AllOf(Matcher.Acceleratable, Matcher.Move));
    }

    public void Execute(Entity[] entities) {
        var accelerate = entities.SingleEntity().isAccelerate;
        foreach (var e in _collection.GetEntities()) {
            var move = e.move;
            var speed = accelerate ? move.maxSpeed : 0;
            e.ReplaceMove(speed, move.maxSpeed);
        }
    }
}

