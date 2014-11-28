namespace Entitas {
    public partial class Entity {
        public MoveComponent move { get { return (MoveComponent)GetComponent(ComponentIds.Move); } }

        public bool hasMove { get { return HasComponent(ComponentIds.Move); } }

        public void AddMove(MoveComponent component) {
            AddComponent(ComponentIds.Move, component);
        }

        public void AddMove(float newSpeed, float newMaxSpeed) {
            var component = new MoveComponent();
            component.speed = newSpeed;
            component.maxSpeed = newMaxSpeed;
            AddMove(component);
        }

        public void ReplaceMove(float newSpeed, float newMaxSpeed) {
            MoveComponent component;
            if (hasMove) {
                WillRemoveComponent(ComponentIds.Move);
                component = move;
            } else {
                component = new MoveComponent();
            }
            component.speed = newSpeed;
            component.maxSpeed = newMaxSpeed;
            ReplaceComponent(ComponentIds.Move, component);
        }

        public void RemoveMove() {
            RemoveComponent(ComponentIds.Move);
        }
    }

    public static partial class Matcher {
        static AllOfEntityMatcher _matcherMove;

        public static AllOfEntityMatcher Move {
            get {
                if (_matcherMove == null) {
                    _matcherMove = Matcher.AllOf(new [] { ComponentIds.Move });
                }

                return _matcherMove;
            }
        }
    }
}
