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
            Vector3 red = new Vector3(247 / 255f, 7 / 255f, 5 / 255f);
            Vector3 darkRed = new Vector3(200 / 255f, 0 / 255f, 0 / 255f);
            Vector3 white = new Vector3(1, 1, 1);


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
            coneF.translate(0f, 0.1f * 0.25f, 0.6f * 0.25f);
            alas.child.Add(coneF);

            //cone belakang
            Asset3d2 coneB = new Asset3d2(darkGrey);
            coneB.createElipticParaboloid(0, 0, 0, 0.03f, 0.03f, 0.01f);
            coneB.rotate(coneB.objectCenter, Vector3.UnitX, 45f);
            coneB.rotate(coneB.objectCenter, Vector3.UnitY, 180f);
            coneB.translate(0f, 0.1f * 0.25f, -0.6f * 0.25f);
            alas.child.Add(coneB);

            //cone kiri
            Asset3d2 coneL = new Asset3d2(darkGrey);
            coneL.createElipticParaboloid(0, 0, 0, 0.03f, 0.03f, 0.01f);
            coneL.rotate(coneL.objectCenter, Vector3.UnitX, 45f);
            coneL.rotate(coneL.objectCenter, Vector3.UnitY, -90f);
            coneL.translate(-0.6f * 0.25f, 0.1f * 0.25f, 0f);
            alas.child.Add(coneL);

            //cone kanan
            Asset3d2 coneR = new Asset3d2(darkGrey);
            coneR.createElipticParaboloid(0, 0, 0, 0.03f, 0.03f, 0.01f);
            coneR.rotate(coneR.objectCenter, Vector3.UnitX, 45f);
            coneR.rotate(coneR.objectCenter, Vector3.UnitY, 90f);
            coneR.translate(0.6f * 0.25f, 0.1f * 0.25f, 0f);
            alas.child.Add(coneR);

            //laser
            laser = new Asset3d2(green);
            laser.createEllipsoid(0, 0, 0.01f, 0.7f, 0.7f, 0f, 30, 30);
            laser.rotate(laser.objectCenter, Vector3.UnitX, 90f);
            alas.child.Add(laser);

            //atur posisi
            alas.scale(0.25f, 0.25f, 0.25f);
            alas.translate(2f, -0.35f, -0.5f);

            //KARAKTER

            Asset3d2 badan = new Asset3d2(red);
            badan.tabung(0, 0, 0, 0.1f, 0.1f, 0.005f);
            badan.rotate(badan.objectCenter, Vector3.UnitX, 90f);

            Asset3d2 kepala = new Asset3d2(red);
            kepala.createEllipsoid(0, 0, 0, 0.1f, 0.09f, 0.1f, 30, 30);
            kepala.translate(0f, 0.1f, 0f);

            Asset3d2 pantat = new Asset3d2(red);
            pantat.createEllipsoid(0, 0, 0, 0.1f, 0.08f, 0.1f, 30, 30);

            Asset3d2 google = new Asset3d2(new Vector3(147/255f, 193/255f, 213/255f));
            google.createEllipsoid(0, 0, 0, 0.06f, 0.03f, 0.01f, 25, 25);
            google.translate(0, 0.1f, 0.1f);

            Asset3d2 kakiL = new Asset3d2(darkRed);
            kakiL.tabung(0, 0, 0, 0.04f, 0.04f, 0.007f);
            kakiL.rotate(kakiL.objectCenter, Vector3.UnitX, 90f);
            kakiL.translate(-0.05f, -0.15f, 0f);

            Asset3d2 kakiR = new Asset3d2(darkRed);
            kakiR.tabung(0, 0, 0, 0.04f, 0.04f, 0.007f);
            kakiR.rotate(kakiR.objectCenter, Vector3.UnitX, 90f);
            kakiR.translate(0.05f, -0.15f, 0f);

            Asset3d2 tas = new Asset3d2(darkRed);
            tas.createCuboid(0, 0, 0, 0.15f);
            tas.translate(0, 0.05f, -0.05f);

            kepala.child.Add(google);
            badan.child.Add(kepala);
            badan.child.Add(pantat);
            badan.child.Add(kakiL);
            badan.child.Add(kakiR);
            badan.child.Add(tas);

            //Atur posisis
            badan.translate(2f, -0.2f, -0.5f);
            badan.rotate(badan.objectCenter, Vector3.UnitY, 15f);


            //SCREEN
            Asset3d2 layar = new Asset3d2(red);
            layar.createBlock(0, 0, 0, 0.5f, 0.25f, 0.05f);

            Asset3d2 frameL = new Asset3d2(darkGrey);
            frameL.createBlock(0, 0, 0, 0.05f, 0.3f, 0.06f);
            frameL.translate(-0.25f, 0f, 0f);
            layar.child.Add(frameL);

            Asset3d2 frameR = new Asset3d2(darkGrey);
            frameR.createBlock(0, 0, 0, 0.05f, 0.3f, 0.06f);
            frameR.translate(0.25f, 0f, 0f);
            layar.child.Add(frameR);

            Asset3d2 frameT = new Asset3d2(darkGrey);
            frameT.createBlock(0, 0, 0, 0.5f, 0.05f, 0.06f);
            frameT.translate(0f, 0.125f, 0f);
            layar.child.Add(frameT);

            Asset3d2 frameB = new Asset3d2(darkGrey);
            frameB.createBlock(0, 0, 0, 0.5f, 0.05f, 0.06f);
            frameB.translate(0f, -0.125f, 0f);
            layar.child.Add(frameB);

            Asset3d2 stand = new Asset3d2(grey);
            stand.tabung(0, 0, 0, 0.02f, 0.02f, 0.01f);
            stand.rotate(stand.objectCenter, Vector3.UnitX, 90f);
            stand.translate(0f, -0.3f, 0f);
            layar.child.Add(stand);

            Asset3d2 line = new Asset3d2(white);
            line.tabung(0, 0, 0, 0.01f, 0.01f, 0.02f);
            line.rotate(line.objectCenter, Vector3.UnitY, 90f);
            line.translate(0.2f, 0, 0.03f);
            layar.child.Add(line);

            Asset3d2 line2 = new Asset3d2(white);
            line2.tabung(0, 0, 0, 0.01f, 0.01f, 0.02f);
            line2.rotate(line2.objectCenter, Vector3.UnitY, 90f);
            line2.translate(0.2f, 0.05f, 0.03f);
            layar.child.Add(line2);

            Asset3d2 line3 = new Asset3d2(white);
            line3.tabung(0, 0, 0, 0.01f, 0.01f, 0.02f);
            line3.rotate(line3.objectCenter, Vector3.UnitY, 90f);
            line3.translate(0.2f, -0.05f, 0.03f);
            layar.child.Add(line3);


            //atur posisi
            layar.translate(2.5f, -0.1f, -0.5f);
            layar.rotate(layar.objectCenter, Vector3.UnitY, -35f);


            listObject.Add(alas);
            listObject.Add(badan);
            listObject.Add(layar);
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

            if (counter <= 0 || counter >= 70)
            {
                speed *= -1;
                increment *= -1;
            }
        }
    }
}
