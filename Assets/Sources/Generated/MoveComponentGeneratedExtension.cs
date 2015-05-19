using Entitas;

namespace Entitas {
    public partial class Entity {
        public MoveComponent move { get { return (MoveComponent)GetComponent(CoreComponentIds.Move); } }

        public bool hasMove { get { return HasComponent(CoreComponentIds.Move); } }

        public Entity AddMove(MoveComponent component) {
            return AddComponent(CoreComponentIds.Move, component);
        }

        public Entity AddMove(float newSpeed, float newMaxSpeed) {
            var component = new MoveComponent();
            component.speed = newSpeed;
            component.maxSpeed = newMaxSpeed;
            return AddMove(component);
        }

        public Entity ReplaceMove(float newSpeed, float newMaxSpeed) {
            MoveComponent component;
            if (hasMove) {
                WillRemoveComponent(CoreComponentIds.Move);
                component = move;
            } else {
                component = new MoveComponent();
            }
            component.speed = newSpeed;
            component.maxSpeed = newMaxSpeed;
            return ReplaceComponent(CoreComponentIds.Move, component);
        }

        public Entity RemoveMove() {
            return RemoveComponent(CoreComponentIds.Move);
        }
    }
}

    public partial class CoreMatcher {
        static AllOfMatcher _matcherMove;

        public static AllOfMatcher Move {
            get {
                if (_matcherMove == null) {
                    _matcherMove = new CoreMatcher(CoreComponentIds.Move);
                }

                return _matcherMove;
            }
        }
    }
