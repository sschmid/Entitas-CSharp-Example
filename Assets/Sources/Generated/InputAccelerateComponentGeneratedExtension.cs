namespace Entitas {
    public partial class Entity {
        static readonly InputAccelerateComponent inputAccelerateComponent = new InputAccelerateComponent();

        public bool isInputAccelerate {
            get { return HasComponent(ComponentIds.InputAccelerate); }
            set {
                if (value != isInputAccelerate) {
                    if (value) {
                        AddComponent(ComponentIds.InputAccelerate, inputAccelerateComponent);
                    } else {
                        RemoveComponent(ComponentIds.InputAccelerate);
                    }
                }
            }
        }
    }

    public partial class EntityRepository {
        public Entity inputAccelerateEntity { get { return GetCollection(Matcher.InputAccelerate).GetSingleEntity(); } }

        public bool isInputAccelerate {
            get { return inputAccelerateEntity != null; }
            set {
                var entity = inputAccelerateEntity;
                if (value != (entity != null)) {
                    if (value) {
                        CreateEntity().isInputAccelerate = true;
                    } else {
                        DestroyEntity(entity);
                    }
                }
            }
        }
    }

    public static partial class Matcher {
        static AllOfEntityMatcher _matcherInputAccelerate;

        public static AllOfEntityMatcher InputAccelerate {
            get {
                if (_matcherInputAccelerate == null) {
                    _matcherInputAccelerate = Matcher.AllOf(new [] { ComponentIds.InputAccelerate });
                }

                return _matcherInputAccelerate;
            }
        }
    }
}
