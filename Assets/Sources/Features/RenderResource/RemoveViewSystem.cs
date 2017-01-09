using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class RemoveViewSystem : ISetPool, IMultiReactiveSystem, IEnsureComponents {

    public TriggerOnEvent[] triggers {
        get {
            return new [] {
                GameMatcher.Resource.OnEntityRemoved(),
                Matcher.AllOf(GameMatcher.Resource, GameMatcher.Destroy).OnEntityAdded()
            };
        }
    }

    public IMatcher ensureComponents { get { return GameMatcher.View; } }

    public void SetPool(Pool pool) {
        pool.GetGroup(GameMatcher.View).OnEntityRemoved += onEntityRemoved;
    }

    void onEntityRemoved(Group group, Entity entity, int index, IComponent component) {
        var viewComponent = (ViewComponent)component;
        Object.Destroy(viewComponent.gameObject);
    }

    public void Execute(List<Entity> entities) {
        foreach(var e in entities) {
            e.RemoveView();
        }
    }
}
