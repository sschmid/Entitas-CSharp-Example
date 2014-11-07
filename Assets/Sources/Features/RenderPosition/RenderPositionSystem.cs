using Entitas;
using UnityEngine;

public class RenderPositionSystem : IReactiveSubEntitySystem {
    public IEntityMatcher GetTriggeringMatcher() {
        return Matcher.AllOf(Matcher.View, Matcher.Position);
    }

    public EntityCollectionEventType GetEventType() {
        return EntityCollectionEventType.OnEntityAdded;
    }

    public void Execute(Entity[] entities) {
        foreach (var e in entities) {
            if (e.hasView) {
                var pos = e.position;
                e.view.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
            }
        }
    }
}

