namespace ReadObj
{   
    public class Mesh
    {

        public readonly Vertex[] vertices;
        public readonly Triangle[] triangles;

        public Mesh(Vertex[] vertices, Triangle[] triangles)
        {
            this.vertices = vertices;
            this.triangles = triangles;

        }
    }
}
