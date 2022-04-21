using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace UTSgrafkom
{
    internal class Scanner: Item
    {
        double time;

        List<Asset3d2> listObject = new List<Asset3d2>();

        public Scanner()
        {
            Vector3 grey = new Vector3(168 / 255f, 212 / 255f, 215 / 255f);
            Vector3 darkGrey = new Vector3(105/255f, 142/255f, 148/255f);
            Vector3 darkGreen = new Vector3(49/255f, 206/255f, 102/255f);
            Vector3 green = new Vector3(113 / 255f, 231 / 255f, 172 / 255f);


            Asset3d2 alas = new Asset3d2(darkGrey);
            alas.tabung(0f, 0f, 0f, 0.8f, 0.8f, 0.005f);

            //alas dalam hijau
            Asset3d2 tutupHijau = new Asset3d2(darkGreen);
            tutupHijau.createEllipsoid(0, 0, 0.01f, 0.5f, 0.5f, 0f, 30, 30);
            alas.child.Add(tutupHijau);

            //alas luar abu-abu
            Asset3d2 tutupAbu = new Asset3d2(grey);
            tutupAbu.createEllipsoid(0, 0, 0, 0.8f, 0.8f, 0f, 30, 30);
            alas.child.Add(tutupAbu);            
            
            alas.rotate(new Vector3(0, 0, 0), Vector3.UnitX, -90f);
            
            //tabung sebelah kiri
            Asset3d2 tabungL = new Asset3d2(darkGrey);
            tabungL.tabung(0f, 0f, 0f, 0.2f, 0.2f, 0.01f);
            tabungL.rotate(tabungL.objectCenter, Vector3.UnitY, 90f);
            tabungL.rotate(tabungL.objectCenter, Vector3.UnitZ, 45f);
            tabungL.translate(-0.6f, 0f, 0f);
            alas.child.Add(tabungL);

            //tabung sebelah kanan
            Asset3d2 tabungR = new Asset3d2(darkGrey);
            tabungR.tabung(0f, 0f, 0f, 0.2f, 0.2f, 0.01f);
            tabungR.rotate(tabungR.objectCenter, Vector3.UnitY, -90f);
            tabungR.rotate(tabungR.objectCenter, Vector3.UnitZ, -45f);
            tabungR.translate(0.6f, 0f, 0f);
            alas.child.Add(tabungR);

            //tabung sebelah depan
            Asset3d2 tabungF = new Asset3d2(darkGrey);
            tabungF.tabung(0f, 0f, 0f, 0.2f, 0.2f, 0.01f);
            tabungF.rotate(tabungF.objectCenter, Vector3.UnitY, 0f);
            tabungF.rotate(tabungF.objectCenter, Vector3.UnitX, -45f);
            tabungF.translate(0f, 0f, -0.6f);
            alas.child.Add(tabungF);

            //tabung sebelah belakang
            Asset3d2 tabungB = new Asset3d2(darkGrey);
            tabungB.tabung(0f, 0f, 0f, 0.2f, 0.2f, 0.01f);
            tabungB.rotate(tabungB.objectCenter, Vector3.UnitY, 180f);
            tabungB.rotate(tabungB.objectCenter, Vector3.UnitX, 45f);
            tabungB.translate(0f, 0f, 0.6f);
            alas.child.Add(tabungB);

            alas.rotate(alas.objectCenter, Vector3.UnitY, 45f);

            listObject.Add(alas);
        }

        public void load(int SizeX, int SizeY)
        {
            foreach (Asset3d2 i in listObject)
            {
                i.load(SizeX, SizeY);
            }
        }

        public void render(Matrix4 cameraView, Matrix4 cameraProjection)
        {
            for (int i = 0; i < listObject.Count; i++)
            {
                listObject[i].render(cameraView, cameraProjection);
            }
        }
    }
}
