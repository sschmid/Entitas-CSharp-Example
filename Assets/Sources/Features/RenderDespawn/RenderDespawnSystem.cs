using Entitas;
using UnityEngine;

public class RenderDespawnSystem : IReactiveSubEntityWillBeRemovedSystem {
    public AllOfEntityMatcher GetTriggeringMatcher() {
        return Matcher.View;
    }

    public void Execute(EntityComponentPair[] pairs) {
        foreach (var pair in pairs) {
            var view = (ViewComponent)pair.component;
            Object.Destroy(view.gameObject);
        }
    }
}

