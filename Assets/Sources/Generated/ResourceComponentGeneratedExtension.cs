using Entitas;

namespace Entitas {
    public partial class Entity {
        public ResourceComponent resource { get { return (ResourceComponent)GetComponent(CoreComponentIds.Resource); } }

        public bool hasResource { get { return HasComponent(CoreComponentIds.Resource); } }

        public void AddResource(ResourceComponent component) {
            AddComponent(CoreComponentIds.Resource, component);
        }

        public void AddResource(string newName) {
            var component = new ResourceComponent();
            component.name = newName;
            AddResource(component);
        }

        public void ReplaceResource(string newName) {
            ResourceComponent component;
            if (hasResource) {
                WillRemoveComponent(CoreComponentIds.Resource);
                component = resource;
            } else {
                component = new ResourceComponent();
            }
            component.name = newName;
            ReplaceComponent(CoreComponentIds.Resource, component);
        }

        public void RemoveResource() {
            RemoveComponent(CoreComponentIds.Resource);
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
