using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ReadObj
{
    public partial class Form1 : Form
    {
        Scene[] _scenes;
        readonly Canvas _canvas;
        TreeNode _selectedNode;
        Scene _selectedScene;
        Mesh _mesh;
        private bool _rx;

        float _angle;
        string _filePath;
        bool _stop;

        public Form1()
        {
            InitializeComponent();
            _canvas = new Canvas(pictureBox1.Size);
            pictureBox1.Image = _canvas.bitmap;
            
            _scenes = new Scene[1];
            _scenes[0] = new Scene();
            _selectedScene = _scenes[0];
        }

        private void timer1_Tick(object sender, EventArgs j)
        {
            Draw();
            if (_scenes != null)
            {
                if (_selectedScene != null)
                {
                    if (_rx)
                    {
                        foreach (var model in _selectedScene.Models)
                        {
                            model.Transform.Rotation = Matrix.RotX(_angle++);
                        }
                        Matrix combinedRotation = Matrix.RotX(_angle);
                        foreach (var model in _selectedScene.Models)
                        {
                            model.Transform.Rotation = combinedRotation;
                        }
                        _angle++;
                    }

                    if (_rx == false && _stop)
                    {
                        _selectedScene.Models[0].Transform.Rotation = Matrix.Identity;
                    }
                }
            }

            pictureBox1.Invalidate();
        }

        public void Draw()
        {
            if (_selectedScene != null)
            {
                _canvas.FastClear();
                _canvas.Render(_selectedScene);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _rx = true;
        }

        private void ReadObj()
        {
            Vertex[] vertices;
            Triangle[] faces;

            using (StreamReader reader = new StreamReader(_filePath))
            {
                List<Vertex> vertexList = new List<Vertex>();
                List<Triangle> faceList = new List<Triangle>();

                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                reader.DiscardBufferedData();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line != null && line.StartsWith("v "))
                    {
                        string[] vertexValues = line.Split(' ');
                        float x = float.Parse(vertexValues[1]);
                        float y = float.Parse(vertexValues[2]);
                        float z = float.Parse(vertexValues[3]);
                        Vertex vertex = new Vertex(x, y, z);
                        vertexList.Add(vertex);
                    }
                    else if (line != null && line.StartsWith("f "))
                    {
                        string[] faceValues = line.Split(' ');
                        List<int> faceIndices = new List<int>();
                        for (int j = 0; j < faceValues.Length; j++)
                        {
                            string[] vertexIndexValues = faceValues[j].Split('/');
                            int vertexIndex;
                            if (int.TryParse(vertexIndexValues[0], out vertexIndex))
                            {
                                vertexIndex--;
                                faceIndices.Add(vertexIndex);
                            }
                        }

                        for (int i = 1; i < faceIndices.Count - 1; i++)
                        {
                            Triangle face = new Triangle(faceIndices[0], faceIndices[i], faceIndices[i + 1], Color.White);
                            faceList.Add(face);
                        }
                    }
                }
                vertices = vertexList.ToArray();
                faces = faceList.ToArray();
            }
            
            NewModel(vertices, faces);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            this.WindowState = FormWindowState.Maximized;
        }

        private void SerchArchive_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = @"Buscar archivo";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            openFileDialog.ShowDialog();

            _filePath = openFileDialog.FileName;

            ReadObj();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _selectedNode = e.Node;
            _selectedScene = (Scene)_selectedNode.Tag;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            _rx = false;
            _stop = true;
        }

        private void NewModel(Vertex[] vertices, Triangle[] triangles)
        {
            // Create a new mesh with the vertices and triangles
            _mesh = new Mesh(vertices, triangles);

            Transform modelTransform = new Transform(1f, new Vertex(0, 0, 10), Matrix.Identity);
            
            // Create a new model with the mesh and the transformation
            Model newModel = new Model(new Vertex(0, 0, 0), _mesh, modelTransform);
            
            // Add the model to the selected scene
            _selectedScene.AddModel(newModel);

            if (_scenes != null)
            {
                treeView1.Nodes.Clear();

                for (int i = 0; i < _scenes.Length; i++)
                {
                    TreeNode node = new TreeNode(@"Escena " + (i + 1));
                    node.Tag = _scenes[i];
                    treeView1.Nodes.Add(node);
                }
            }
            
            _canvas.Render(_selectedScene);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
