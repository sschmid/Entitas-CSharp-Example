using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RenderPositionSystem : IReactiveSystem, IEnsureComponents {
    public IMatcher trigger { get { return Matcher.AllOf(CoreMatcher.View, CoreMatcher.Position); } }

    public GroupEventType eventType { get { return GroupEventType.OnEntityAdded; } }

    public IMatcher ensureComponents { get { return CoreMatcher.View; } }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            var pos = e.position;
            e.view.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
        }
    }
}

