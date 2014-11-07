using Entitas;

public static class EntityRepositoryExtensions {

    public static IEntitySystem CreateSystem<T>(this EntityRepository repo) where T: new() {
        var system = new T();
        if (system is ISetEntityRepository) {
            ((ISetEntityRepository)system).SetEntityRepository(repo);
        }
        if (system is IEntitySystem) {
            return (IEntitySystem)system;
        }
        if (system is IReactiveSubEntitySystem) {
            return new ReactiveEntitySystem(repo, (IReactiveSubEntitySystem)system);
        }
        if (system is IReactiveSubEntityWillBeRemovedSystem) {
            return new ReactiveEntityWillBeRemovedSystem(repo, (IReactiveSubEntityWillBeRemovedSystem)system);
        }

        return null;
    }
}

public interface ISetEntityRepository {
    void SetEntityRepository(EntityRepository repo);
}
