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
        //untuk animasi
        int counter;
        int increment = 1;
        float speed = 0.005f;

        List<Asset3d2> listObject = new List<Asset3d2>();
        Asset3d2 laser;

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
            
            //rotate supaya keliatan tidur
            alas.rotate(new Vector3(0, 0, 0), Vector3.UnitX, -90f);

            //cone depan
            Asset3d2 coneF = new Asset3d2(darkGrey);
            coneF.createElipticParaboloid(0, 0, 0, 0.03f, 0.03f, 0.01f);
            coneF.rotate(coneF.objectCenter, Vector3.UnitX, 45f);
            coneF.translate(0f, 0.1f, 0.6f);
            alas.child.Add(coneF);

            //cone belakang
            Asset3d2 coneB = new Asset3d2(darkGrey);
            coneB.createElipticParaboloid(0, 0, 0, 0.03f, 0.03f, 0.01f);
            coneB.rotate(coneB.objectCenter, Vector3.UnitX, 45f);
            coneB.rotate(coneB.objectCenter, Vector3.UnitY, 180f);
            coneB.translate(0f, 0.1f, -0.6f);
            alas.child.Add(coneB);

            //cone kiri
            Asset3d2 coneL = new Asset3d2(darkGrey);
            coneL.createElipticParaboloid(0, 0, 0, 0.03f, 0.03f, 0.01f);
            coneL.rotate(coneL.objectCenter, Vector3.UnitX, 45f);
            coneL.rotate(coneL.objectCenter, Vector3.UnitY, -90f);
            coneL.translate(-0.6f, 0.1f, 0f);
            alas.child.Add(coneL);

            //cone kanan
            Asset3d2 coneR = new Asset3d2(darkGrey);
            coneR.createElipticParaboloid(0, 0, 0, 0.03f, 0.03f, 0.01f);
            coneR.rotate(coneR.objectCenter, Vector3.UnitX, 45f);
            coneR.rotate(coneR.objectCenter, Vector3.UnitY, 90f);
            coneR.translate(0.6f, 0.1f, 0f);
            alas.child.Add(coneR);

            //laser
            laser = new Asset3d2(green);
            laser.createEllipsoid(0, 0, 0.01f, 0.5f, 0.5f, 0f, 30, 30);
            laser.rotate(laser.objectCenter, Vector3.UnitX, 90f);
            alas.child.Add(laser);

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

            counter += increment;

            laser.translate(0, speed, 0);

            Console.WriteLine(counter);

            if (counter <= 0 || counter >= 100)
            {
                speed *= -1;
                increment *= -1;
            }
        }
    }
}
