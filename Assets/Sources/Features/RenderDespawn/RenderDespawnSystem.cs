using Entitas;
using UnityEngine;

public class RenderDespawnSystem : IReactiveSubEntitySystem {
    public IEntityMatcher GetTriggeringMatcher() {
        return Matcher.AllOf(Matcher.Destroy, Matcher.View);
    }
    public EntityCollectionEventType GetEventType() {
        return EntityCollectionEventType.OnEntityAdded;
    }

    public void Execute(Entity[] entities) {
        foreach (var e in entities) {
            Object.Destroy(e.view.gameObject);
        }
    }
}

