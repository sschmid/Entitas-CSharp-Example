namespace Entitas {
    public partial class Entity {
        static readonly FinishLineComponent finishLineComponent = new FinishLineComponent();

        public bool isFinishLine {
            get { return HasComponent(ComponentIds.FinishLine); }
            set {
                if (value != isFinishLine) {
                    if (value) {
                        AddComponent(ComponentIds.FinishLine, finishLineComponent);
                    } else {
                        RemoveComponent(ComponentIds.FinishLine);
                    }
                }
            }
        }
    }

    public partial class EntityRepository {
        public Entity finishLineEntity { get { return GetCollection(Matcher.FinishLine).GetSingleEntity(); } }

        public bool isFinishLine {
            get { return finishLineEntity != null; }
            set {
                var entity = finishLineEntity;
                if (value != (entity != null)) {
                    if (value) {
                        CreateEntity().isFinishLine = true;
                    } else {
                        DestroyEntity(entity);
                    }
                }
            }
        }
    }

    public static partial class Matcher {
        static AllOfEntityMatcher _matcherFinishLine;

        public static AllOfEntityMatcher FinishLine {
            get {
                if (_matcherFinishLine == null) {
                    _matcherFinishLine = Matcher.AllOf(new [] { ComponentIds.FinishLine });
                }

                return _matcherFinishLine;
            }
        }
    }
}
