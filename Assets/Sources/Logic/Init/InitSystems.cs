using Entitas;

public class InitSystems : Feature {

    public InitSystems(Contexts contexts) : base("Init Systems") {
        Add(new CreatePlayerSystem(contexts));
        Add(new CreateOpponentsSystem(contexts));
        Add(new CreateFinishLineSystem(contexts));
    }
}
