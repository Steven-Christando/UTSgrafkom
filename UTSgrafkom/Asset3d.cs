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
    internal class Asset3d
    {
        public List<Vector3> _vertices = new List<Vector3>();
        public List<uint> _indices = new List<uint>();

        private Vector3 _color;

        int _vertexBufferObject;
        int _elementBufferObject;
        int _vertexArrayObject;

        public Shader _shader;

        Matrix4 model = Matrix4.Identity;
        Matrix4 view;
        Matrix4 projection;

        public List<Vector3> euler = new List<Vector3>();  // Sudut lokal, relatif terhadap objek yang bersangkutan.
        public Vector3 objectCenter = Vector3.Zero;         // Titik tengah objek

        public List<Asset3d> child = new List<Asset3d>();   // Sistem Hierarchical Object ==> List untuk menampung objek - objek child.
        public Asset3d(Vector3 color)
        {
            this._color = color;
            euler.Add(Vector3.UnitX); // Masukkan sudut Euler di Constructor.
            euler.Add(Vector3.UnitY);
            euler.Add(Vector3.UnitZ);
        }
        public void load(string shadervert, string shaderfrag, float sizex, float sizey)
        {
            //inisialisasi generate buffer
            _vertexBufferObject = GL.GenBuffer();               //menyimpan vertex bisa warna, texture dll untuk dikirim ke GPU (cuman dikirim)

            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Count * Vector3.SizeInBytes,_vertices.ToArray(), BufferUsageHint.StaticDraw);

            _vertexArrayObject = GL.GenVertexArray();           //kasih tau GPU dibaginya datanya kek gmn
            GL.BindVertexArray(_vertexArrayObject);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);


            if (_indices.Count != 0)
            {
                _elementBufferObject = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
                GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Count * sizeof(uint),_indices.ToArray(), BufferUsageHint.StaticDraw);
            }


            _shader = new Shader(shadervert, shaderfrag);
            _shader.Use();          //ngasih tau GPU ini mau diapain

            view = Matrix4.CreateTranslation(0.0f, 0.0f, -3.0f);
            projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), sizex / (float)sizey, 0.1f, 100.0f);
        }

        public void render(Matrix4 cameraView, Matrix4 cameraProjection)
        {
            _shader.Use();
            GL.BindVertexArray(_vertexArrayObject);
            //uniform untuk color
            _shader.SetVector3("ourColor", _color);

            /*kalo pake yang time pake yang ini*/
            /*Matrix4 model = Matrix4.Identity * Matrix4.CreateRotationY((float)MathHelper.DegreesToRadians(time));*/

            /*kalo pake yang degree pake ini*/
            /*model = temp;*/
            _shader.SetMatrix4("model", model);
            _shader.SetMatrix4("view", cameraView);
            _shader.SetMatrix4("projection", cameraProjection);


            

            if (_indices.Count != 0)
            {
                GL.DrawElements(PrimitiveType.Triangles, _indices.Count, DrawElementsType.UnsignedInt, 0);
            }
            else
            {
                GL.DrawArrays(PrimitiveType.LineStrip, 0, _vertices.Count);
            }
        }
        public void resetEuler()
        {
            euler.Clear();
            euler.Add(Vector3.UnitX);
            euler.Add(Vector3.UnitY);
            euler.Add(Vector3.UnitZ);
        }
        #region object
        public void createEllipsoidWireframe(float x, float y, float z, float radiusX, float radiusY, float radiusZ)
        {
            objectCenter = new Vector3(x, y, z);
            var tempVertex = new Vector3();
            for (float u = -MathF.PI; u < MathF.PI; u += MathF.PI / 1000.0f)
            {
                for (float v = -MathF.PI / 2.0f; v < MathF.PI / 2.0f; v += MathF.PI / 100.0f)
                {
                    tempVertex.X = radiusX * MathF.Cos(v) * MathF.Cos(u) + x;
                    tempVertex.Y = radiusY * MathF.Cos(v) * MathF.Sin(u) + y;
                    tempVertex.Z = radiusZ * MathF.Sin(v) + z;
                    _vertices.Add(tempVertex);
                }
            }
        }
        public void createSphereWireframe(float x, float y, float z, float radiusXY, float radiusZ)
        {
            objectCenter = new Vector3(x, y, z);
            var tempVertex = new Vector3();
            for (float u = -MathF.PI; u < MathF.PI; u += MathF.PI / 1000.0f)
            {
                for (float v = -MathF.PI / 2.0f; v < MathF.PI / 2.0f; v += MathF.PI / 100.0f)
                {
                    tempVertex.X = radiusXY * MathF.Cos(v) * MathF.Cos(u) + x;
                    tempVertex.Y = radiusXY * MathF.Cos(v) * MathF.Sin(u) + y;
                    tempVertex.Z = radiusZ * MathF.Sin(v) + z;
                    _vertices.Add(tempVertex);
                }
            }
        }
        public void createBoxVertices(float x, float y, float z)
        {
            //biar lebih fleksibel jangan inisialiasi posisi dan 
            //panjang kotak didalam tapi ditaruh ke parameter
            float _positionX = x;
            float _positionY = y;
            float _positionZ = z;

            float _boxLength = 0.6f;

            //Buat temporary vector
            Vector3 temp_vector;
            //1. Inisialisasi vertex
            // Titik 1
            temp_vector.X = _positionX - _boxLength / 5.0f; // x 
            temp_vector.Y = _positionY + _boxLength / 5.0f; // y
            temp_vector.Z = _positionZ - _boxLength / 5.0f; // z

            _vertices.Add(temp_vector);

            // Titik 2
            temp_vector.X = _positionX + _boxLength / 5.0f; // x
            temp_vector.Y = _positionY + _boxLength / 5.0f; // y
            temp_vector.Z = _positionZ - _boxLength / 5.0f; // z

            _vertices.Add(temp_vector);
            // Titik 3
            temp_vector.X = _positionX - _boxLength / 5.0f; // x
            temp_vector.Y = _positionY - _boxLength / 5.0f; // y
            temp_vector.Z = _positionZ - _boxLength / 5.0f; // z
            _vertices.Add(temp_vector);

            // Titik 4
            temp_vector.X = _positionX + _boxLength / 5.0f; // x
            temp_vector.Y = _positionY - _boxLength / 5.0f; // y
            temp_vector.Z = _positionZ - _boxLength / 5.0f; // z

            _vertices.Add(temp_vector);

            // Titik 5
            temp_vector.X = _positionX - _boxLength / 5.0f; // x
            temp_vector.Y = _positionY + _boxLength / 5.0f; // y
            temp_vector.Z = _positionZ + _boxLength / 5.0f; // z

            _vertices.Add(temp_vector);

            // Titik 6
            temp_vector.X = _positionX + _boxLength / 5.0f; // x
            temp_vector.Y = _positionY + _boxLength / 5.0f; // y
            temp_vector.Z = _positionZ + _boxLength / 5.0f; // z

            _vertices.Add(temp_vector);

            // Titik 7
            temp_vector.X = _positionX - _boxLength / 5.0f; // x
            temp_vector.Y = _positionY - _boxLength / 5.0f; // y
            temp_vector.Z = _positionZ + _boxLength / 5.0f; // z

            _vertices.Add(temp_vector);

            // Titik 8
            temp_vector.X = _positionX + _boxLength / 5.0f; // x
            temp_vector.Y = _positionY - _boxLength / 5.0f; // y
            temp_vector.Z = _positionZ + _boxLength / 5.0f; // z

            _vertices.Add(temp_vector);
            //2. Inisialisasi index vertex
            _indices = new List<uint> {
                // Segitiga Depan 1
                0, 1, 2,
                // Segitiga Depan 2
                1, 2, 3,
                // Segitiga Atas 1
                0, 4, 5,
                // Segitiga Atas 2
                0, 1, 5,
                // Segitiga Kanan 1
                1, 3, 5,
                // Segitiga Kanan 2
                3, 5, 7,
                // Segitiga Kiri 1
                0, 2, 4,
                // Segitiga Kiri 2
                2, 4, 6,
                // Segitiga Belakang 1
                4, 5, 6,
                // Segitiga Belakang 2
                5, 6, 7,
                // Segitiga Bawah 1
                2, 3, 6,
                // Segitiga Bawah 2
                3, 6, 7
            };

        }
        public void createEllipsoid(float x, float y, float z, float radX, float radY, float radZ, float sectorCount, float stackCount)
        {
            objectCenter = new Vector3(x, y, z);

            float pi = (float)Math.PI;
            Vector3 temp_vector;
            float sectorStep = 2 * pi / sectorCount;
            float stackStep = pi / stackCount;
            float sectorAngle, stackAngle, tempX, tempY, tempZ;

            for (int i = 0; i <= stackCount; ++i)
            {
                stackAngle = pi / 2 - i * stackStep;
                tempX = radX * (float)Math.Cos(stackAngle);
                tempY = radY * (float)Math.Sin(stackAngle);
                tempZ = radZ * (float)Math.Cos(stackAngle);

                for (int j = 0; j <= sectorCount; ++j)
                {
                    sectorAngle = j * sectorStep;

                    temp_vector.X = x + tempX * (float)Math.Cos(sectorAngle);
                    temp_vector.Y = y + tempY;
                    temp_vector.Z = z + tempZ * (float)Math.Sin(sectorAngle);

                    _vertices.Add(temp_vector);
                }
            }

            uint k1, k2;
            for (int i = 0; i < stackCount; ++i)
            {
                k1 = (uint)(i * (sectorCount + 1));
                k2 = (uint)(k1 + sectorCount + 1);

                for (int j = 0; j < sectorCount; ++j, ++k1, ++k2)
                {
                    if (i != 0)
                    {
                        _indices.Add(k1);
                        _indices.Add(k2);
                        _indices.Add(k1 + 1);

                    }

                    if (i != stackCount - 1)
                    {
                        _indices.Add(k1 + 1);
                        _indices.Add(k2);
                        _indices.Add(k2 + 1);
                    }
                }
            }
        }

        public void createHalfEllipsoid(float radiusX, float radiusY, float radiusZ, float _x, float _y, float _z)
        {

            objectCenter.X = _x;
            objectCenter.Y = _y;
            objectCenter.Z = _z;

            float pi = (float)Math.PI;
            Vector3 temp_vector;
            for (float v = -pi / 2; v <= pi / 2; v += pi / 1000)
            {
                for (float u = 0; u <= pi; u += pi / 1000)
                {
                    temp_vector.X = _x + (float)Math.Cos(v) * (float)Math.Cos(u) * radiusX;
                    temp_vector.Y = _y + (float)Math.Cos(v) * (float)Math.Sin(u) * radiusY;
                    temp_vector.Z = _z + (float)Math.Sin(v) * radiusZ;
                    _vertices.Add(temp_vector);
                }
            }
        }

        public void createSphere(float x, float y, float z, float radXYZ, float sectorCount, float stackCount)
        {
            objectCenter = new Vector3(x, y, z);

            float pi = (float)Math.PI;
            Vector3 temp_vector;
            float sectorStep = 2 * pi / sectorCount;
            float stackStep = pi / stackCount;
            float sectorAngle, stackAngle, tempX, tempY, tempZ;

            for (int i = 0; i <= stackCount; ++i)
            {
                stackAngle = pi / 2 - i * stackStep;
                tempX = radXYZ * (float)Math.Cos(stackAngle);
                tempY = radXYZ * (float)Math.Sin(stackAngle);
                tempZ = radXYZ * (float)Math.Cos(stackAngle);

                for (int j = 0; j <= sectorCount; ++j)
                {
                    sectorAngle = j * sectorStep;

                    temp_vector.X = x + tempX * (float)Math.Cos(sectorAngle);
                    temp_vector.Y = y + tempY;
                    temp_vector.Z = z + tempZ * (float)Math.Sin(sectorAngle);

                    _vertices.Add(temp_vector);
                }
            }

            uint k1, k2;
            for (int i = 0; i < stackCount; ++i)
            {
                k1 = (uint)(i * (sectorCount + 1));
                k2 = (uint)(k1 + sectorCount + 1);

                for (int j = 0; j < sectorCount; ++j, ++k1, ++k2)
                {
                    if (i != 0)
                    {
                        _indices.Add(k1);
                        _indices.Add(k2);
                        _indices.Add(k1 + 1);

                    }

                    if (i != stackCount - 1)
                    {
                        _indices.Add(k1 + 1);
                        _indices.Add(k2);
                        _indices.Add(k2 + 1);
                    }
                }
            }
        }
        public void tabung(float _positionX, float _positionY, float _positionZ, float _radiusx, float _radiusy, float _radiusz)
        {
            objectCenter = new Vector3(_positionX, _positionY, _positionZ);
            Vector3 temp_vector; float _pi = (float)Math.PI;
            for (float v = -20.0f; v <= _pi / 100; v += 0.01f)
            {
                for (float u = -20.0f; u <= _pi; u += (_pi / 100))
                {
                    temp_vector.X = _positionX + _radiusx * (float)Math.Cos(u); 
                    temp_vector.Y = _positionY + _radiusy * (float)Math.Sin(u); 
                    temp_vector.Z = _positionZ + _radiusz * v;
                    _vertices.Add(temp_vector);
                }
            }
        }
        public void createTorus(float x, float y, float z, float radMajor, float radMinor, float sectorCount, float stackCount)
        {
            objectCenter = new Vector3(x, y, z);

            float pi = (float)Math.PI;
            Vector3 temp_vector;
            stackCount *= 2;
            float sectorStep = 2 * pi / sectorCount;
            float stackStep = 2 * pi / stackCount;
            float sectorAngle, stackAngle, tempX, tempY, tempZ;

            for (int i = 0; i <= stackCount; ++i)
            {
                stackAngle = pi / 2 - i * stackStep;
                tempX = radMajor + radMinor * (float)Math.Cos(stackAngle);
                tempY = radMinor * (float)Math.Sin(stackAngle);
                tempZ = radMajor + radMinor * (float)Math.Cos(stackAngle);

                for (int j = 0; j <= sectorCount; ++j)
                {
                    sectorAngle = j * sectorStep;

                    temp_vector.X = x + tempX * (float)Math.Cos(sectorAngle);
                    temp_vector.Y = y + tempY;
                    temp_vector.Z = z + tempZ * (float)Math.Sin(sectorAngle);

                    _vertices.Add(temp_vector);
                }
            }

            uint k1, k2;
            for (int i = 0; i < stackCount; ++i)
            {
                k1 = (uint)(i * (sectorCount + 1));
                k2 = (uint)(k1 + sectorCount + 1);

                for (int j = 0; j < sectorCount; ++j, ++k1, ++k2)
                {
                    _indices.Add(k1);
                    _indices.Add(k2);
                    _indices.Add(k1 + 1);

                    _indices.Add(k1 + 1);
                    _indices.Add(k2);
                    _indices.Add(k2 + 1);
                }
            }
        }
        public void createElipticParaboloid(float x, float y, float z, float radiusX, float radiusY, float radiusZ)

        {
            var tempVertex = new Vector3();
            for (float u = -MathF.PI; u < MathF.PI; u += MathF.PI / 1000.0f)
            {
                for (float v = 0.0f; v < 5.0f; v += 0.01f)
                {
                    tempVertex.X = radiusX * v * MathF.Cos(u) + x;
                    tempVertex.Y = radiusY * v * MathF.Sin(u) + y;
                    tempVertex.Z = radiusZ * v * v + z;
                    _vertices.Add(tempVertex);
                }
            }
        }
        #endregion
        #region transform
        public void rotate(Vector3 pivot, Vector3 vector, float angle)
        {
            var radAngle = MathHelper.DegreesToRadians(angle);

            var arbRotationMatrix = new Matrix4
                (
                new Vector4((float)(Math.Cos(radAngle) + Math.Pow(vector.X, 2.0f) * (1.0f - Math.Cos(radAngle))), (float)(vector.X * vector.Y * (1.0f - Math.Cos(radAngle)) + vector.Z * Math.Sin(radAngle)), (float)(vector.X * vector.Z * (1.0f - Math.Cos(radAngle)) - vector.Y * Math.Sin(radAngle)), 0),
                new Vector4((float)(vector.X * vector.Y * (1.0f - Math.Cos(radAngle)) - vector.Z * Math.Sin(radAngle)), (float)(Math.Cos(radAngle) + Math.Pow(vector.Y, 2.0f) * (1.0f - Math.Cos(radAngle))), (float)(vector.Y * vector.Z * (1.0f - Math.Cos(radAngle)) + vector.X * Math.Sin(radAngle)), 0),
                new Vector4((float)(vector.X * vector.Z * (1.0f - Math.Cos(radAngle)) + vector.Y * Math.Sin(radAngle)), (float)(vector.Y * vector.Z * (1.0f - Math.Cos(radAngle)) - vector.X * Math.Sin(radAngle)), (float)(Math.Cos(radAngle) + Math.Pow(vector.Z, 2.0f) * (1.0f - Math.Cos(radAngle))), 0),
                Vector4.UnitW
                );

            model *= Matrix4.CreateTranslation(-pivot);
            model *= arbRotationMatrix;
            model *= Matrix4.CreateTranslation(pivot);

            for (int i = 0; i < 3; i++)
            {
                euler[i] = Vector3.Normalize(getRotationResult(pivot, vector, radAngle, euler[i], true));
            }

            objectCenter = getRotationResult(pivot, vector, radAngle, objectCenter);

            foreach (var i in child)
            {
                i.rotate(pivot, vector, angle);
            }
        }

        public Vector3 getRotationResult(Vector3 pivot, Vector3 vector, float angle, Vector3 point, bool isEuler = false)
        {
            Vector3 temp, newPosition;

            if (isEuler)
            {
                temp = point;
            }
            else
            {
                temp = point - pivot;
            }

            newPosition.X =
                temp.X * (float)(Math.Cos(angle) + Math.Pow(vector.X, 2.0f) * (1.0f - Math.Cos(angle))) +
                temp.Y * (float)(vector.X * vector.Y * (1.0f - Math.Cos(angle)) - vector.Z * Math.Sin(angle)) +
                temp.Z * (float)(vector.X * vector.Z * (1.0f - Math.Cos(angle)) + vector.Y * Math.Sin(angle));

            newPosition.Y =
                temp.X * (float)(vector.X * vector.Y * (1.0f - Math.Cos(angle)) + vector.Z * Math.Sin(angle)) +
                temp.Y * (float)(Math.Cos(angle) + Math.Pow(vector.Y, 2.0f) * (1.0f - Math.Cos(angle))) +
                temp.Z * (float)(vector.Y * vector.Z * (1.0f - Math.Cos(angle)) - vector.X * Math.Sin(angle));

            newPosition.Z =
                temp.X * (float)(vector.X * vector.Z * (1.0f - Math.Cos(angle)) - vector.Y * Math.Sin(angle)) +
                temp.Y * (float)(vector.Y * vector.Z * (1.0f - Math.Cos(angle)) + vector.X * Math.Sin(angle)) +
                temp.Z * (float)(Math.Cos(angle) + Math.Pow(vector.Z, 2.0f) * (1.0f - Math.Cos(angle)));

            if (isEuler)
            {
                temp = newPosition;
            }
            else
            {
                temp = newPosition + pivot;
            }
            return temp;
        }

        public void translate(float x, float y, float z)
        {
            model *= Matrix4.CreateTranslation(x, y, z);
            objectCenter.X += x;
            objectCenter.Y += y;
            objectCenter.Z += z;

            foreach (var i in child)
            {
                i.translate(x, y, z);
            }
        }

        public void scale(float scaleX, float scaleY, float scaleZ)
        {
            model *= Matrix4.CreateTranslation(-objectCenter);
            model *= Matrix4.CreateScale(scaleX, scaleY, scaleZ);
            model *= Matrix4.CreateTranslation(objectCenter);

            foreach (var i in child)
            {
                i.scale(scaleX, scaleY, scaleZ);
            }
        }
        #endregion
    }
}
