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
    internal class Karakter : Asset3d
    {
        float degr = 0;
        double time;
        List<Asset3d> listObject = new List<Asset3d>();
        Asset3d kepala, bokong, google, tas, badan, kakiKiri, kakiKanan, topi;

        float x, y, z;
        static class Constants
        {
            public const string path = "D:../../../shader/";
        }
        public Karakter(float x, float y, float z, Vector3 color) : base(color)
        {
            this.x = x;
            this.y = y;
            this.z = z;

          
            badan = new Asset3d(new Vector3(0, 0.5f, 1));
            badan.tabung(0,0,0, 0.2f, 0.1f, 0.013f);
            badan.rotate(badan.objectCenter, Vector3.UnitX, 90f);
            listObject.Add(badan);
        }

        public void load(float SizeX,float SizeY)
        {
            foreach (Asset3d i in listObject)
            {
                i.load(Constants.path + "shader.vert", Constants.path + "shader.frag", SizeX, SizeY);
                
            }
        }

        public void render(double times, Matrix4 temps, Matrix4 cameraView, Matrix4 cameraProjection)
        {
            time += 15.0 * times;
            Matrix4 temp = Matrix4.Identity;
            for (int i = 0; i < listObject.Count; i++)
            {
                listObject[i].render(1, temp, time, cameraView, cameraProjection);
            }
        }

    }
}
