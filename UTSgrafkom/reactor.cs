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
    internal class reactor : Asset3d
    {
        float degr = 0;
        Vector3 warna;
        List<Asset3d> listObject = new List<Asset3d>();
        double time = 0;
        public reactor(Vector3 color) : base(color)
        {
            warna = new Vector3(color);

            Asset3d tabungBesar = new Asset3d(new Vector3(0, 0.5f, 1));
            tabungBesar.tabung(0f,0,0f, 0.5f, 0.2f, 0.02f);
            Asset3d tabungMedium = new Asset3d(new Vector3(1, 0.5f, 1));
            tabungMedium.tabung(0f, 0f, -0.3f, 0.3f, 0.2f, 0.02f);
            listObject.Add(tabungMedium);
            listObject.Add(tabungBesar);
        }
        static class Constants
        {
            public const string path = "D:../../../shader/";
        }
        public void load(float SizeX, float SizeY)
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
                
                    degr = MathHelper.DegreesToRadians(90f);
                    temp = Matrix4.CreateRotationX(degr) * temps;
                    listObject[i].render(1, temp, time, cameraView, cameraProjection);
                
            }
        }
    }
}
