using Entitas;

public class ViewSystems : Feature {

    public ViewSystems(Contexts contexts) : base("View Systems") {
        Add(new RemoveViewSystem(contexts));
        Add(new AddViewSystem(contexts));
        Add(new RenderPositionSystem(contexts));
    }
}
