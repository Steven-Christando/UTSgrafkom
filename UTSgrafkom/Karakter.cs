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

            kepala = new Asset3d(new Vector3(0, 0.5f, 1));
            kepala.createSphereWireframe(x + (-0.5f), y + (-0.3f), z + (0), 0.2f, 0.1f);

            bokong = new Asset3d(new Vector3(0, 0.5f, 1));
            bokong.createSphereWireframe(x + (-0.5f), y + (-0.52f), z + (0), 0.2f, 0.1f);

            google = new Asset3d(new Vector3(0.8f, 0.8f, 0.8f));
            google.createEllipsoidWireframe(x + (-0.412f), y + (-0.35f), z + (0), 0.123f, 0.075f, 0.1f);

            tas = new Asset3d(new Vector3(0f, 0.5f, 1));
            tas.createBoxVertices(x+(-0.62f),y+(-0.45f),z+(-0.1f));

            badan = new Asset3d(new Vector3(0, 0.5f, 1));
            badan.tabung(x+(-0.5f), y+(0), z + (0.55f), 0.2f, 0.1f, 0.013f);

            kakiKiri = new Asset3d(new Vector3(0, 0.5f, 1f));
            kakiKiri.tabung(x + (-0.62f), y + (0), z + (0.8f), 0.075f, 0.05f, 0.017f);

            kakiKanan = new Asset3d(new Vector3(0, 0.5f, 1f));
            kakiKanan.tabung(x + (-0.3753f), y + (0), y + (0.8f), 0.075f, 0.05f, 0.017f);

            topi = new Asset3d(new Vector3(0.5f, 0.5f, 1));
            topi.createElipticParaboloid(-0.5f, 0f, 0.06f, 0.035f, 0.05f, 0.003f);

            /*kakiKiri = new Asset3d(new Vector3(0f, 0.5f, 1f));
            kakiKiri.createElipticParaboloid(-0.53f, 1f, -1.05f, 0.03f, 0.05f, 0.025f);

            kakiKanan = new Asset3d(new Vector3(0f, 0.5f, 1f));
            kakiKanan.createElipticParaboloid(-0.8f, 1f, -1.05f, 0.03f, 0.05f, 0.025f);*/

            listObject.Add(kakiKanan);
            listObject.Add(kakiKiri);
            listObject.Add(tas);
            listObject.Add(kepala);
            listObject.Add(bokong);
            listObject.Add(badan);
            listObject.Add(google);
            listObject.Add(topi);
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
                if (i == 0 || i == 1 || i == 5 || i == 7)
                {
                    degr = MathHelper.DegreesToRadians(90f);
                    temp = Matrix4.CreateRotationX(degr)*temps;
                }
                else
                {
                    degr = MathHelper.DegreesToRadians(00f);
                    temp = Matrix4.CreateRotationX(degr)*temps;
                }
                listObject[i].render(1, temp, time, cameraView, cameraProjection);
            }
        }

    }
}
