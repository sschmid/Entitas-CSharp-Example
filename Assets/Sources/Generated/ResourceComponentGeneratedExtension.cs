using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public ResourceComponent resource { get { return (ResourceComponent)GetComponent(CoreComponentIds.Resource); } }

        public bool hasResource { get { return HasComponent(CoreComponentIds.Resource); } }

        static readonly Stack<ResourceComponent> _resourceComponentPool = new Stack<ResourceComponent>();

        public static void ClearResourceComponentPool() {
            _resourceComponentPool.Clear();
        }

        public Entity AddResource(string newName) {
            var component = _resourceComponentPool.Count > 0 ? _resourceComponentPool.Pop() : new ResourceComponent();
            component.name = newName;
            return AddComponent(CoreComponentIds.Resource, component);
        }

        public Entity ReplaceResource(string newName) {
            var previousComponent = hasResource ? resource : null;
            var component = _resourceComponentPool.Count > 0 ? _resourceComponentPool.Pop() : new ResourceComponent();
            component.name = newName;
            ReplaceComponent(CoreComponentIds.Resource, component);
            if (previousComponent != null) {
                _resourceComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveResource() {
            var component = resource;
            RemoveComponent(CoreComponentIds.Resource);
            _resourceComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class CoreMatcher {
        static AllOfMatcher _matcherResource;

        public static AllOfMatcher Resource {
            get {
                if (_matcherResource == null) {
                    _matcherResource = new CoreMatcher(CoreComponentIds.Resource);
                }

                return _matcherResource;
            }
        }
    }
