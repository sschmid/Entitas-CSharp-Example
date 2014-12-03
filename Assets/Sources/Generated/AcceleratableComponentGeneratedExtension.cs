namespace Entitas {
    public partial class Entity {
        static readonly AcceleratableComponent acceleratableComponent = new AcceleratableComponent();

        public bool isAcceleratable {
            get { return HasComponent(ComponentIds.Acceleratable); }
            set {
                if (value != isAcceleratable) {
                    if (value) {
                        AddComponent(ComponentIds.Acceleratable, acceleratableComponent);
                    } else {
                        RemoveComponent(ComponentIds.Acceleratable);
                    }
                }
            }
        }
    }

    public static partial class Matcher {
        static AllOfEntityMatcher _matcherAcceleratable;

        public static AllOfEntityMatcher Acceleratable {
            get {
                if (_matcherAcceleratable == null) {
                    _matcherAcceleratable = Matcher.AllOf(new [] { ComponentIds.Acceleratable });
                }

                return _matcherAcceleratable;
            }
        }
    }
}
