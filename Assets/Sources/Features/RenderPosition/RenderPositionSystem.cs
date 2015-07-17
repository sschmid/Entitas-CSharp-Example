using Entitas;
using UnityEngine;

public class RenderPositionSystem : IReactiveSystem {
    public IMatcher trigger { get { return Matcher.AllOf(CoreMatcher.View, CoreMatcher.Position); } }

    public GroupEventType eventType { get { return GroupEventType.OnEntityAdded; } }

    public void Execute(Entity[] entities) {
        foreach (var e in entities) {
            var pos = e.position;
            e.view.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
        }
    }
}

