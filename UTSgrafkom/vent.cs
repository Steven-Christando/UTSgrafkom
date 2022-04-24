using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace UTSgrafkom
{
    internal class vent : Asset3d, Item
    {

        public vent(Vector3 color) : base(color)
        {
        }
        static class Constants
        {
            public const string path = "D:../../../shader/";
        }

        public void Render(Matrix4 cameraView, Matrix4 cameraProjection)
        {
            base.render(cameraView, cameraProjection);

            /*_shader.SetVector3("ourColor", new Vector3(0.0f, 0f, 0f));
            GL.DrawElements(PrimitiveType.LineLoop, _indices.Count, DrawElementsType.UnsignedInt, 0);*/

        }
        public void alasVent()
        {
            Vector3 temp_vector;
            //1. Inisialisasi vertex
            // Titik 0 kiri depan
            temp_vector.X = -1.3f;// x 
            temp_vector.Y = -0.4445f;// y
            temp_vector.Z = -0.8f;// z

            _vertices.Add(temp_vector);

            // Titik 1 kiri belakang
            temp_vector.X = -1.5f;// x
            temp_vector.Y = -0.4445f;// y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // Titik 2 kanan depan
            temp_vector.X = -1f;// x
            temp_vector.Y = -0.4445f;// y
            temp_vector.Z = -0.8f;// z
            _vertices.Add(temp_vector);

            // Titik 3 kanan belakang
            temp_vector.X = -1.2f;// x
            temp_vector.Y = -0.4445f; // y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);


            _indices = new List<uint>
            {
                //depan
                0,1,3,
                0,2,3
                /*1,2,3*/
            };
        }
        public void tutupVent()
        {
            Vector3 temp_vector;
            //1. Inisialisasi vertex
            // Titik 0 kiri bawah
            temp_vector.X = -1.2f;// x 
            temp_vector.Y = -0.4445f;// y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // Titik 1 kanan bawah
            temp_vector.X = -1f;// x
            temp_vector.Y = -0.4445f;// y
            temp_vector.Z = -0.8f;// z

            _vertices.Add(temp_vector);

            // Titik 2 kanan atas
            temp_vector.X = -1.15f;// x
            temp_vector.Y = -0.2f;// y
            temp_vector.Z = -0.8f;// z
            _vertices.Add(temp_vector);

            // Titik 3 kiri atas
            temp_vector.X = -1.35f;// x
            temp_vector.Y = -0.2f; // y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);


            _indices = new List<uint>
            {
                //depan
                0,1,3,
                1,2,3
            };
        }
        
        public void load(int sizeX, int sizeY)
        {
            throw new NotImplementedException();
        }
    }
}
