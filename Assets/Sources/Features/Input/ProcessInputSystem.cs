using Entitas;

public class ProcessInputSystem : IReactiveSubEntitySystem, ISetEntityRepository {
    public IEntityMatcher GetTriggeringMatcher() {
        return Matcher.InputAccelerate;
    }

    public EntityCollectionEventType GetEventType() {
        return EntityCollectionEventType.OnEntityAddedOrRemoved;
    }

    EntityCollection _accerlerate;
    EntityCollection _collection;

    public void SetEntityRepository(EntityRepository repo) {
        _accerlerate = repo.GetCollection(Matcher.InputAccelerate);
        _collection = repo.GetCollection(Matcher.AllOf(Matcher.InputControlled, Matcher.Move));
    }

    public void Execute(Entity[] entities) {
        var accelerate = _accerlerate.Count != 0;
        foreach (var e in _collection.GetEntities()) {
            var move = e.move;
            var speed = accelerate ? move.maxSpeed : 0;
            e.ReplaceMove(speed, move.maxSpeed);
        }
    }
}

