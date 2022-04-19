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
    internal class Scanner
    {
        double time;

        List<Asset3d> listObject = new List<Asset3d>();
        Asset3d alas;

        static class Constants
        {
            public const string path = "../../../shader/";
        }

        public Scanner()
        {
            alas = new Asset3d(new Vector3(1f, 1f, 1f));
            alas.tabung(1f, 1f, 0f, 1f, 1f, 1f);

            listObject.Add(alas);
        }

        public void load(float SizeX, float SizeY)
        {
            foreach (Asset3d i in listObject)
            {
                i.load(Constants.path + "shader.vert", Constants.path + "shader.frag", SizeX, SizeY);
            }
        }

        public void render(double times, Matrix4 matrixTransform, Matrix4 cameraView, Matrix4 cameraProjection)
        {
            time += 15.0 * times;
            Matrix4 temp = Matrix4.Identity;
            for (int i = 0; i < listObject.Count; i++)
            {
                listObject[i].render(1, matrixTransform, time, cameraView, cameraProjection);
            }
        }
    }
}
