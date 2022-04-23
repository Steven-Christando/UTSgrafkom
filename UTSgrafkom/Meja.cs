using ConsoleApp1;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSgrafkom
{
    internal class Meja: Item
    {
        //untuk animasi
        int counter;
        int increment = 1;
        float speed = 0.005f;

        List<Asset3d2> listObject = new List<Asset3d2>();
        Asset3d2 laser;

        public Meja()
        {
            Vector3 grey = new Vector3(168 / 255f, 212 / 255f, 215 / 255f);
            Vector3 darkGrey = new Vector3(105 / 255f, 142 / 255f, 148 / 255f);
            Vector3 darkGreen = new Vector3(49 / 255f, 206 / 255f, 102 / 255f);
            Vector3 red = new Vector3(255 / 255f, 0 / 255f, 0 / 255f);
            Vector3 darkRed = new Vector3(174 / 255f, 0 / 255f, 0 / 255f);
            Vector3 softYellow = new Vector3(226 / 255f, 198 / 152f, 87 / 255f);
            Vector3 softBlue = new Vector3(194 / 255f, 222 / 255f, 235 / 255f);


            Asset3d2 alas = new Asset3d2(darkGrey);
            alas.tabung(0f, 0f, 0f, 0.3f, 0.3f, 0.0015f);

            //alas luar abu-abu
            Asset3d2 tutupAbu = new Asset3d2(grey);
            tutupAbu.createEllipsoid(0, 0, 0, 0.3f, 0.3f, 0f, 30, 30);
            alas.child.Add(tutupAbu);
            
            Asset3d2 kaki1 = new Asset3d2(darkGrey);
            kaki1.tabung(0f, 0f, 0f, 0.05f, 0.05f, 0.01f);
            alas.child.Add(kaki1);
            kaki1.translate(0f, 0.2f, 0f);

            Asset3d2 kaki2 = new Asset3d2(darkGrey);
            kaki2.tabung(0f, 0f, 0f, 0.05f, 0.05f, 0.01f);
            alas.child.Add(kaki2);
            kaki2.translate(0f, -0.2f, 0f);

            Asset3d2 kaki3 = new Asset3d2(darkGrey);
            kaki3.tabung(0f, 0f, 0f, 0.05f, 0.05f, 0.01f);
            alas.child.Add(kaki3);
            kaki3.translate(0.2f, 0f, 0f);

            Asset3d2 kaki4 = new Asset3d2(darkGrey);
            kaki4.tabung(0f, 0f, 0f, 0.05f, 0.05f, 0.01f);
            alas.child.Add(kaki4);
            kaki4.translate(-0.2f, 0f, 0f);

            Asset3d2 tombol = new Asset3d2(darkRed);
            Asset3d2 alasTombol = new Asset3d2(red);
            tombol.tabung(0, 0, 0.02f, 0.03f, 0.03f, 0.001f);
            alasTombol.createEllipsoid(0, 0, 0.02f, 0.03f, 0.03f, 0f, 30, 30);
            alas.child.Add(tombol);
            alas.child.Add(alasTombol);
           
            Asset3d2 bingkaiTombol = new Asset3d2(softYellow);
            bingkaiTombol.createBlock(0, 0, 0.001f, 0.15f, 0.15f, 0);
            bingkaiTombol.rotate(bingkaiTombol.objectCenter, Vector3.UnitZ, 120f);
            alas.child.Add(bingkaiTombol);

            Asset3d2 alasTutupTombol = new Asset3d2(softBlue);
            alasTutupTombol.createBlock(0, 0, 0.002f, 0.11f, 0.11f, 0);
            alasTutupTombol.rotate(alasTutupTombol.objectCenter, Vector3.UnitZ, 120f);
            alas.child.Add(alasTutupTombol);

            //rotate supaya keliatan tidur
            alas.rotate(new Vector3(0, 0, 0), Vector3.UnitX, -90f);
            alas.translate(0f, -0.3f, -0.5f);
            listObject.Add(alas);
            alas.rotate(alas.objectCenter, Vector3.UnitY, -30f);
        }

        public void load(int SizeX, int SizeY)
        {
            foreach (Asset3d2 i in listObject)
            {
                i.load(SizeX, SizeY);
            }
        }

        public void Render(Matrix4 cameraView, Matrix4 cameraProjection)
        {
            for (int i = 0; i < listObject.Count; i++)
            {
                listObject[i].render(cameraView, cameraProjection);
            }
        }
    }
}