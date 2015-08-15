using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddViewSystem : IReactiveSystem {
    public IMatcher trigger { get { return CoreMatcher.Resource; } }

    public GroupEventType eventType { get { return GroupEventType.OnEntityAdded; } }

    readonly Transform _viewContainer = new GameObject("Views").transform;

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            var res = Resources.Load<GameObject>(e.resource.name);
            GameObject gameObject = null;
            try {
                gameObject = UnityEngine.Object.Instantiate(res);
                
            } catch (Exception) {
                Debug.Log("Cannot instantiate " + res);
            }

            if (gameObject != null) {
                gameObject.transform.parent = _viewContainer;
                e.AddView(gameObject);
            }
        }
    }
}

