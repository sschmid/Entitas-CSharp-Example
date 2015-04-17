using Entitas;

namespace Entitas {
    public partial class Entity {
        public PositionComponent position { get { return (PositionComponent)GetComponent(CoreComponentIds.Position); } }

        public bool hasPosition { get { return HasComponent(CoreComponentIds.Position); } }

        public void AddPosition(PositionComponent component) {
            AddComponent(CoreComponentIds.Position, component);
        }

        public void AddPosition(float newX, float newY, float newZ) {
            var component = new PositionComponent();
            component.x = newX;
            component.y = newY;
            component.z = newZ;
            AddPosition(component);
        }

        public void ReplacePosition(float newX, float newY, float newZ) {
            PositionComponent component;
            if (hasPosition) {
                WillRemoveComponent(CoreComponentIds.Position);
                component = position;
            } else {
                component = new PositionComponent();
            }
            component.x = newX;
            component.y = newY;
            component.z = newZ;
            ReplaceComponent(CoreComponentIds.Position, component);
        }

        public void RemovePosition() {
            RemoveComponent(CoreComponentIds.Position);
        }
    }
}

    public partial class CoreMatcher {
        static AllOfMatcher _matcherPosition;

        public static AllOfMatcher Position {
            get {
                if (_matcherPosition == null) {
                    _matcherPosition = new CoreMatcher(CoreComponentIds.Position);
                }

                return _matcherPosition;
            }
        }
    }
