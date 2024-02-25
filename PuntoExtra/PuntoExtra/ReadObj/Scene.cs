using System.Collections.Generic;
using System.Reflection;

namespace ReadObj
{
    public class Scene
    {
        public readonly List<Model> Models;

        public Scene()
        {
            Models = new List<Model>();

        }
        public void AddModel(Model model)
        {
            Models.Add(model);
        }


    }
}
