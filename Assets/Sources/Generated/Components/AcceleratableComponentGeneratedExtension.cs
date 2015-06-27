using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly AcceleratableComponent acceleratableComponent = new AcceleratableComponent();

        public bool isAcceleratable {
            get { return HasComponent(CoreComponentIds.Acceleratable); }
            set {
                if (value != isAcceleratable) {
                    if (value) {
                        AddComponent(CoreComponentIds.Acceleratable, acceleratableComponent);
                    } else {
                        RemoveComponent(CoreComponentIds.Acceleratable);
                    }
                }
            }
        }

        public Entity IsAcceleratable(bool value) {
            isAcceleratable = value;
            return this;
        }
    }
}

    public partial class CoreMatcher {
        static AllOfMatcher _matcherAcceleratable;

        public static AllOfMatcher Acceleratable {
            get {
                if (_matcherAcceleratable == null) {
                    _matcherAcceleratable = new CoreMatcher(CoreComponentIds.Acceleratable);
                }

                return _matcherAcceleratable;
            }
        }
    }
