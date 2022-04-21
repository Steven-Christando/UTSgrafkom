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
    internal class tembok : Asset3d
    {
        public tembok(Vector3 color) : base(color)
        {
        }
        public void render(int pilihan, Matrix4 temp, double time, Matrix4 cameraView, Matrix4 cameraProjection)
        {
            base.render(cameraView, cameraProjection);

            /*_shader.SetVector3("ourColor", new Vector3(0.0f, 0f, 0f));
            GL.DrawElements(PrimitiveType.LineLoop, _indices.Count, DrawElementsType.UnsignedInt, 0);*/

        }


        public void createAlas(float x, float y, float z)
        {
            //Buat temporary vector
            Vector3 temp_vector;
            //1. Inisialisasi vertex
            // Titik 0 kanan bawah depan
            temp_vector.X = 3f;// x 
            temp_vector.Y = -0.5f;// y
            temp_vector.Z = 0f;// z

            _vertices.Add(temp_vector);

            // Titik 1 kanan atas depan
            temp_vector.X = 3f;// x
            temp_vector.Y = -0.45f;// y
            temp_vector.Z = 0f;// z

            _vertices.Add(temp_vector);

            // Titik 2 kiri atas depan
            temp_vector.X = -3f;// x
            temp_vector.Y = -0.45f;// y
            temp_vector.Z = 0f;// z
            _vertices.Add(temp_vector);

            // Titik 3 kiri bawah depan 
            temp_vector.X = - 3f;// x
            temp_vector.Y = - 0.5f; // y
            temp_vector.Z = 0f;// z

            _vertices.Add(temp_vector);

            // Titik 4 kiri bawah belakang
            temp_vector.X = -3f;// x
            temp_vector.Y = -0.5f; // y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // Titik 5 kiri atas belakang
            temp_vector.X = -3f;// x
            temp_vector.Y = -0.45f; // y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // Titik 6 kanan bawah belakang
            temp_vector.X = 3f;// x
            temp_vector.Y = -0.5f; // y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // Titik 7 kanan atas belakang
            temp_vector.X = 3f;// x
            temp_vector.Y = -0.45f; // y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);


            //2. Inisialisasi index vertex
            _indices = new List<uint>
            {
                //depan
                0,1,2,
                0,2,3,
                //samping kiri
                3,4,5,
                2,3,5,
                //samping kanan
                0,6,7,
                0,1,7,
                //belakang
                4,5,6,
                5,6,7,
                //atas
                1,2,5,
                1,5,7,
                //bawah
                0,3,4,
                0,4,6

            };
        }
        public void createAtap(float x, float y, float z)
        {
            //Buat temporary vector
            Vector3 temp_vector;
            //1. Inisialisasi vertex
            // Titik 0 kanan bawah depan
            temp_vector.X = 3f;// x 
            temp_vector.Y = 1.0f;// y
            temp_vector.Z = 0f;// z

            _vertices.Add(temp_vector);

            // Titik 1 kanan atas depan
            temp_vector.X = 3f;// x
            temp_vector.Y = 0.95f;// y
            temp_vector.Z = 0f;// z

            _vertices.Add(temp_vector);

            // Titik 2 kiri atas depan
            temp_vector.X = -3f;// x
            temp_vector.Y = 0.95f;// y
            temp_vector.Z = 0f;// z
            _vertices.Add(temp_vector);

            // Titik 3 kiri bawah depan 
            temp_vector.X = -3f;// x
            temp_vector.Y = 1f; // y
            temp_vector.Z = 0f;// z

            _vertices.Add(temp_vector);

            // Titik 4 kiri bawah belakang
            temp_vector.X = -3f;// x
            temp_vector.Y = 1f; // y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // Titik 5 kiri atas belakang
            temp_vector.X = -3f;// x
            temp_vector.Y = 0.95f; // y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // Titik 6 kanan bawah belakang
            temp_vector.X = 3f;// x
            temp_vector.Y = 1f; // y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // Titik 7 kanan atas belakang
            temp_vector.X = 3f;// x
            temp_vector.Y = 0.95f; // y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);
            //2. Inisialisasi index vertex
            _indices = new List<uint>
            {
                //depan
                0,1,2,
                0,2,3,
                //samping kiri
                3,4,5,
                2,3,5,
                //samping kanan
                0,6,7,
                0,1,7,
                //belakang
                4,5,6,
                5,6,7,
                //atas
                1,2,5,
                1,5,7,
                //bawah
                0,3,4,
                0,4,6

            };
        }
        public void createSampingKiri(float x, float y, float z)
        {
            //Buat temporary vector
            Vector3 temp_vector;
            //1. Inisialisasi vertex
            // Titik 0 kiri bawah depan
            temp_vector.X = -3f;// x 
            temp_vector.Y = -0.5f;// y
            temp_vector.Z = 0f;// z
           
            _vertices.Add(temp_vector);

            // titik 1 kanan bawah depan 
            temp_vector.X = -2.95f;// x 
            temp_vector.Y = -0.5f;// y
            temp_vector.Z = 0f;// z

            _vertices.Add(temp_vector);

            // Titik 2 kiri atas depan
            temp_vector.X = -3f;// x 
            temp_vector.Y = 1f;// y
            temp_vector.Z = 0f;// z

            _vertices.Add(temp_vector);

            // titik 3 kanan atas depan 
            temp_vector.X = -2.95f;// x 
            temp_vector.Y = 1f;// y
            temp_vector.Z = 0f;// z
            _vertices.Add(temp_vector);

            // Titik 4 kiri bawah belakang
            temp_vector.X = -3f;// x 
            temp_vector.Y = -0.5f;// y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // titik 5 kanan bawah belakang
            temp_vector.X = -2.95f;// x 
            temp_vector.Y = -0.5f;// y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // Titik 6 kiri atas belakang
            temp_vector.X = -3f;// x 
            temp_vector.Y = 1f;// y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // titik 7 kanan atas belakang 
            temp_vector.X = -2.95f;// x 
            temp_vector.Y = 1f;// y
            temp_vector.Z = -1f;// z
            _vertices.Add(temp_vector);

            _indices = new List<uint>
            {
                /*//depan
                0,1,2,
                1,2,3,
                //belakang
                4,5,6,
                5,6,7,*/
                //samping kiri
                0,2,4,
                2,4,6
            };
        }
        public void createSampingKanan(float x, float y, float z)
        {
            //Buat temporary vector
            Vector3 temp_vector;
            //1. Inisialisasi vertex
            // Titik 0 kiri bawah depan
            temp_vector.X = 3f;// x 
            temp_vector.Y = -0.5f;// y
            temp_vector.Z = 0f;// z

            _vertices.Add(temp_vector);

            // titik 1 kanan bawah depan 
            temp_vector.X = 2.95f;// x 
            temp_vector.Y = -0.5f;// y
            temp_vector.Z = 0f;// z

            _vertices.Add(temp_vector);

            // Titik 2 kiri atas depan
            temp_vector.X = 3f;// x 
            temp_vector.Y = 1f;// y
            temp_vector.Z = 0f;// z

            _vertices.Add(temp_vector);

            // titik 3 kanan atas depan 
            temp_vector.X = 2.95f;// x 
            temp_vector.Y = 1f;// y
            temp_vector.Z = 0f;// z
            _vertices.Add(temp_vector);

            // Titik 4 kiri bawah belakang
            temp_vector.X = 3f;// x 
            temp_vector.Y = -0.5f;// y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // titik 5 kanan bawah belakang
            temp_vector.X = 2.95f;// x 
            temp_vector.Y = -0.5f;// y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // Titik 6 kiri atas belakang
            temp_vector.X = 3f;// x 
            temp_vector.Y = 1f;// y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // titik 7 kanan atas belakang 
            temp_vector.X = 2.95f;// x 
            temp_vector.Y = 1f;// y
            temp_vector.Z = -1f;// z
            _vertices.Add(temp_vector);

            _indices = new List<uint>
            {
                /*//depan
                0,1,2,
                1,2,3,
                //belakang
                4,5,6,
                5,6,7,*/
                //samping kiri
                0,2,4,
                2,4,6
            };
        }
        public void createBelakang(float x, float y, float z)
        {
            //Buat temporary vector
            Vector3 temp_vector;
            //1. Inisialisasi vertex
            // Titik 0 kiri bawah belakang
            temp_vector.X = -3f;// x 
            temp_vector.Y = -0.45f;// y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // titik 1 kiri atas belakang 
            temp_vector.X = -3f;// x 
            temp_vector.Y = 1f;// y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // Titik 2 kanan atas belakang
            temp_vector.X = 3f;// x 
            temp_vector.Y = -0.45f;// y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // titik 3 kanan atas belakang 
            temp_vector.X = 3f;// x 
            temp_vector.Y = 1f;// y
            temp_vector.Z = -1f;// z
            _vertices.Add(temp_vector);


            _indices = new List<uint>
            {
               //belakang
               0,1,3,
               0,2,3
            };
        }
        public void createSekat1(float x, float y, float z)
        {
            //Buat temporary vector
            Vector3 temp_vector;
            //1. Inisialisasi vertex
            // Titik 0 kiri bawah depan
            temp_vector.X = -1f;// x 
            temp_vector.Y = -0.5f;// y
            temp_vector.Z = 0f;// z

            _vertices.Add(temp_vector);

            // titik 1 kanan bawah depan 
            temp_vector.X = -2.95f;// x 
            temp_vector.Y = -0.5f;// y
            temp_vector.Z = 0f;// z

            _vertices.Add(temp_vector);

            // Titik 2 kiri atas depan
            temp_vector.X = -1f;// x 
            temp_vector.Y = 1f;// y
            temp_vector.Z = 0f;// z

            _vertices.Add(temp_vector);

            // titik 3 kanan atas depan 
            temp_vector.X = -2.95f;// x 
            temp_vector.Y = 1f;// y
            temp_vector.Z = 0f;// z
            _vertices.Add(temp_vector);

            // Titik 4 kiri bawah belakang
            temp_vector.X = -1f;// x 
            temp_vector.Y = -0.5f;// y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // titik 5 kanan bawah belakang
            temp_vector.X = -2.95f;// x 
            temp_vector.Y = -0.5f;// y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // Titik 6 kiri atas belakang
            temp_vector.X = -1f;// x 
            temp_vector.Y = 1f;// y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // titik 7 kanan atas belakang 
            temp_vector.X = -2.95f;// x 
            temp_vector.Y = 1f;// y
            temp_vector.Z = -1f;// z
            _vertices.Add(temp_vector);

            _indices = new List<uint>
            {
                /*//depan
                0,1,2,
                1,2,3,
                //belakang
                4,5,6,
                5,6,7,*/
                //samping kiri
                0,2,4,
                2,4,6
            };
        }
        public void createSekat2(float x, float y, float z)
        {
            //Buat temporary vector
            Vector3 temp_vector;
            //1. Inisialisasi vertex
            // Titik 0 kiri bawah depan
            temp_vector.X = 1f;// x 
            temp_vector.Y = -0.5f;// y
            temp_vector.Z = 0f;// z

            _vertices.Add(temp_vector);

            // titik 1 kanan bawah depan 
            temp_vector.X = -2.95f;// x 
            temp_vector.Y = -0.5f;// y
            temp_vector.Z = 0f;// z

            _vertices.Add(temp_vector);

            // Titik 2 kiri atas depan
            temp_vector.X = 1f;// x 
            temp_vector.Y = 1f;// y
            temp_vector.Z = 0f;// z

            _vertices.Add(temp_vector);

            // titik 3 kanan atas depan 
            temp_vector.X = -2.95f;// x 
            temp_vector.Y = 1f;// y
            temp_vector.Z = 0f;// z
            _vertices.Add(temp_vector);

            // Titik 4 kiri bawah belakang
            temp_vector.X = 1f;// x 
            temp_vector.Y = -0.5f;// y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // titik 5 kanan bawah belakang
            temp_vector.X = -2.95f;// x 
            temp_vector.Y = -0.5f;// y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // Titik 6 kiri atas belakang
            temp_vector.X = 1f;// x 
            temp_vector.Y = 1f;// y
            temp_vector.Z = -1f;// z

            _vertices.Add(temp_vector);

            // titik 7 kanan atas belakang 
            temp_vector.X = -2.95f;// x 
            temp_vector.Y = 1f;// y
            temp_vector.Z = -1f;// z
            _vertices.Add(temp_vector);

            _indices = new List<uint>
            {
                /*//depan
                0,1,2,
                1,2,3,
                //belakang
                4,5,6,
                5,6,7,*/
                //samping kiri
                0,2,4,
                2,4,6
            };
        }
    }
}
