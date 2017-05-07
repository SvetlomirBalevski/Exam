namespace ProjectManager
{
    public class EngineProvider
    {
        public EngineProvider(Engine engine)
        {
            this.Engine = engine;
        }

        public Engine Engine { get; private set; }

        public void Start()
        {
            this.Engine.Start();
        }
    }
}
