namespace Entitas {
    public partial class Pool {
        public ISystem CreateCreateOpponentsSystem() {
            return this.CreateSystem<CreateOpponentsSystem>();
        }
    }
}