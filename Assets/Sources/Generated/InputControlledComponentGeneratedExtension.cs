namespace Entitas {
    public partial class Entity {
        static readonly InputControlledComponent inputControlledComponent = new InputControlledComponent();

        public bool isInputControlled {
            get { return HasComponent(ComponentIds.InputControlled); }
            set {
                if (value != isInputControlled) {
                    if (value) {
                        AddComponent(ComponentIds.InputControlled, inputControlledComponent);
                    } else {
                        RemoveComponent(ComponentIds.InputControlled);
                    }
                }
            }
        }
    }

    public static partial class Matcher {
        static AllOfEntityMatcher _matcherInputControlled;

        public static AllOfEntityMatcher InputControlled {
            get {
                if (_matcherInputControlled == null) {
                    _matcherInputControlled = Matcher.AllOf(new [] { ComponentIds.InputControlled });
                }

                return _matcherInputControlled;
            }
        }
    }
}
