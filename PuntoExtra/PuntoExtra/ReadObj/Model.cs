using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadObj
{
    public class Model
    {
        public Vertex Position;
        public Mesh Mesh;
        public Transform Transform;

        public Model(Vertex position, Mesh mesh, Transform transform)
        {
            Position = position;
            Mesh = mesh;
            Transform = transform;
        }
    }
}
