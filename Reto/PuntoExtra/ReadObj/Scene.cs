namespace ReadObj
{
    public class Scene
    {
        public readonly Mesh mesh;

        public readonly Transform transform;

        public Scene(Mesh mesh, Transform transform)
        {
            this.mesh = mesh;
            this.transform = transform;

        }


    }
}
