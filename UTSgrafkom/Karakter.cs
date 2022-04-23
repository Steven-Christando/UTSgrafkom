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
    internal class Karakter : Asset3d, Item
    {
        float degr = 0;
        double time;
        List<Asset3d> listObject = new List<Asset3d>();
        Asset3d kepala,pantat,badan,google,kakiKanan,kakiKiri,tas;
        Vector3 color;
        float x, y, z;

        int increment = 0;
        int incrementNaikTurun = 0;
        int change = -1;
        int changeNaikTurun = -1;
        int type;
        float degree = 1f;
        float degreeNaikTurun = 0.005f;
        static class Constants
        {
            public const string path = "D:../../../shader/";
        }
        public Karakter(float x, float y, float z, Vector3 color) : base(color)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.color = color;
        }

        public void karakterVent()
        {
            badan = new Asset3d(new Vector3(this.color));
            badan.tabung(0, -0.0225f, 0, 0.05f, 0.05f, 0.005f);
            badan.rotate(badan.objectCenter, Vector3.UnitX, 90f);

            kepala = new Asset3d(new Vector3(this.color));
            kepala.createSphere(0, 0.075f, 0, 0.05f, 25, 25);

            google = new Asset3d(new Vector3(0.5f, 0.5f, 0.5f));
            google.createEllipsoid(-0.0375f, 0.075f, 0, 0.025f, 0.02f, 0.025f, 25, 25);

            badan.child.Add(kepala);
            kepala.child.Add(google);

            kepala.rotate(kepala.objectCenter, Vector3.UnitY, 90f);
            badan.translate(-1.25f, -0.4255f, -0.9f);

            listObject.Add(kepala);
            listObject.Add(badan);
            listObject.Add(google);
            type = 0;
        }

        public void karakterReaktor()
        {
            kepala = new Asset3d(this.color);
            kepala.createSphere(0, -0.2f, 0, 0.1f, 25, 25);

            pantat = new Asset3d(this.color);
            pantat.createSphere(0, -0.3f, 0, 0.1f, 25, 25);
            
            badan = new Asset3d(this.color);
            badan.tabung(0, -0.3f, 0, 0.1f, 0.1f, 0.005f);
            badan.rotate(badan.objectCenter, Vector3.UnitX, 90f);

            google = new Asset3d(new Vector3(0.5f,0.5f,0.5f));
            google.createEllipsoid(0.0f, -0.2f, 0.1f, 0.05f, 0.03f, 0.04f, 25, 25);

            kakiKiri = new Asset3d(new Vector3(this.color));
            kakiKiri.tabung(-0.061f, -0.3f, 0.15f, 0.04f, 0.03f, 0.01f);
            kakiKiri.rotate(badan.objectCenter, Vector3.UnitX, 90f);

            kakiKanan = new Asset3d(new Vector3(this.color));
            kakiKanan.tabung(0.061f, -0.3f, 0.15f, 0.04f, 0.03f, 0.01f);
            kakiKanan.rotate(badan.objectCenter, Vector3.UnitX, 90f);

            tas = new Asset3d(new Vector3(this.color));
            tas.createBoxVertices(0, -0.275f, -0.05f);

            badan.child.Add(kepala);
            kepala.child.Add(google);
            badan.child.Add(pantat);
            badan.child.Add(kakiKanan);
            badan.child.Add(kakiKiri);
            badan.child.Add(tas);

            badan.rotate(badan.objectCenter, Vector3.UnitY, -45);
            badan.translate(-1.7f, 0, -0.5f);

            listObject.Add(badan);
            listObject.Add(kepala);
            listObject.Add(pantat);
            listObject.Add(google);
            listObject.Add(kakiKiri);
            listObject.Add(kakiKanan);
            listObject.Add(tas);
            type = 1;
        }

        public void mayatKarakter()
        {

        }

        public void load(int SizeX,int SizeY)
        {
            foreach (Asset3d i in listObject)
            {
                i.load(Constants.path + "shader.vert", Constants.path + "shader.frag", SizeX, SizeY);
                
            }
        }

        public void render(Matrix4 cameraView, Matrix4 cameraProjection)
        {

            for (int i = 0; i < listObject.Count; i++)
            {
                listObject[i].render(cameraView, cameraProjection);
            }
            if (type == 0)
            {
                /*if (increment == 0 || increment == 100)
                {
                    change *= -1;
                    degree *= -1;
                }
                increment += change;
                if(incrementNaikTurun == 0 || incrementNaikTurun == 30)
                {
                    changeNaikTurun *= -1;
                    degreeNaikTurun *= -1;
                }
                incrementNaikTurun += changeNaikTurun;*/
                if (increment >= 0 && increment <= 199)
                {
                    if(increment <= 99)
                    {
                        badan.rotate(badan.objectCenter, Vector3.UnitY, -1);
                    } else
                    {
                        badan.rotate(badan.objectCenter, Vector3.UnitY, 1);
                    }
                } else if (increment >= 200 && increment <= 230)
                {
                    badan.translate(0,-0.005f, 0);
                } else if (increment >= 231 && increment <=261)
                {
                    badan.translate(0, 0.005f, 0);
                    if(increment == 261)
                    {
                        increment = 0;
                    }
                }
                increment += 1;
            }
        }
    }
}
