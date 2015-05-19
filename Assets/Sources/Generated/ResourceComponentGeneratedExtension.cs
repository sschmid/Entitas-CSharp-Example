using Entitas;

namespace Entitas {
    public partial class Entity {
        public ResourceComponent resource { get { return (ResourceComponent)GetComponent(CoreComponentIds.Resource); } }

        public bool hasResource { get { return HasComponent(CoreComponentIds.Resource); } }

        public Entity AddResource(ResourceComponent component) {
            return AddComponent(CoreComponentIds.Resource, component);
        }

        public Entity AddResource(string newName) {
            var component = new ResourceComponent();
            component.name = newName;
            return AddResource(component);
        }

        public Entity ReplaceResource(string newName) {
            ResourceComponent component;
            if (hasResource) {
                WillRemoveComponent(CoreComponentIds.Resource);
                component = resource;
            } else {
                component = new ResourceComponent();
            }
            component.name = newName;
            return ReplaceComponent(CoreComponentIds.Resource, component);
        }

        public Entity RemoveResource() {
            return RemoveComponent(CoreComponentIds.Resource);
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
