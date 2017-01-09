using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class RenderPositionSystem : IReactiveSystem, IEnsureComponents {

    public TriggerOnEvent trigger { get { return Matcher.AllOf(GameMatcher.View, GameMatcher.Position).OnEntityAdded(); } }

    public IMatcher ensureComponents { get { return GameMatcher.View; } }

    public void Execute(List<Entity> entities) {
        foreach(var e in entities) {
            var pos = e.position;
            e.view.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
        }
    }
}
