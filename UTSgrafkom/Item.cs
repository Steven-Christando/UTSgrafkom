using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSgrafkom
{
    internal interface Item
    {
        void load(int sizeX, int sizeY);
        void Render(Matrix4 cameraView, Matrix4 cameraProjection);
    }
}
