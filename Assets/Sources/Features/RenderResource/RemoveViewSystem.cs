using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class RemoveViewSystem : IMultiReactiveSystem, IEnsureComponents {

    public TriggerOnEvent[] triggers {
        get {
            return new [] {
                GameMatcher.Resource.OnEntityRemoved(),
                GameMatcher.Destroy.OnEntityAdded()
            };
        }
    }

    public IMatcher ensureComponents { get { return GameMatcher.View; } }

    public void Execute(List<Entity> entities) {
        foreach(var e in entities) {
            Object.Destroy(e.view.gameObject);
            e.RemoveView();
        }
    }
}
