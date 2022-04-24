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
    internal class reactor : Asset3d, Item
    {
        float degr = 0;
        Vector3 warna;
        List<Asset3d> listObject = new List<Asset3d>();
        double time = 0;
        Asset3d ring1, ring2,tabungBesar,tutup,tabungMedium,tutup2,tabung1,bola1,tabung2,bola2,tabung3,bola3,tabung4,bola4,tabung5,bola5,tabung6,bola6,holder, bolaReaktor, kabel, controlBox;
        public reactor(Vector3 color) : base(color)
        {
            warna = new Vector3(color);

            tabungBesar = new Asset3d(new Vector3(129/255f, 138/255f, 164/255f));
            tabungBesar.tabung(0f,0f,0f, 0.2f, 0.2f, 0.02f);
            tabungBesar.rotate(tabungBesar.objectCenter, Vector3.UnitX, 90f);
            
            tutup = new Asset3d(new Vector3(129 / 255f, 138 / 255f, 164 / 255f));
            tutup.createEllipsoid(0f, 0.3f, 0f, 0.2f, 0.2f, 0.02f, 25, 25);
            tutup.rotate(tutup.objectCenter, Vector3.UnitX, 90f);

            tabungBesar.child.Add(tutup);

            tabungMedium = new Asset3d(new Vector3(129 / 255f, 138 / 255f, 164 / 255f));
            tabungMedium.tabung(0, 0, 0, 0.1f, 0.1f, 0.02f);
            tabungMedium.rotate(tabungMedium.objectCenter, Vector3.UnitX, 90f);

            tutup2 = new Asset3d(new Vector3(129 / 255f, 138 / 255f, 164 / 255f));
            tutup2.createEllipsoid(0, 0.4f, 0, 0.1f, 0.1f, 0.02f, 25, 25);
            tutup2.rotate(tutup2.objectCenter, Vector3.UnitX, 90f);
            tabungMedium.child.Add(tutup2);

            holder = new Asset3d(new Vector3(153 / 255f, 23 / 255f, 86 / 255f));
            holder.createTorus(0, 0.425f, 0, 0.07f, 0.015f, 30, 30);

            bolaReaktor = new Asset3d(new Vector3(19 / 255f, 44 / 255f, 103 / 255f));
            bolaReaktor.createSphere(0, 0.4f, 0, 0.07f, 30, 30);

            tabungMedium.child.Add(holder);
            tabungMedium.child.Add(bolaReaktor);

            tabungMedium.translate(-2.49f, -0.2f, -0.5f);

            tabung1 = new Asset3d(new Vector3(210/255f, 231/255f, 230/255f));
            tabung1.tabung(0, 0, 0, 0.02f, 0.02f, 0.012f);
            tabung1.rotate(tabungMedium.objectCenter, Vector3.UnitX, 90f);

            bola1 = new Asset3d(new Vector3(210 / 255f, 231 / 255f, 230 / 255f));
            bola1.createSphere(0, -0.455f, 0, 0.02f, 25, 25);
            bola1.translate(0, 0f, -0.3f);
            tabung1.child.Add(bola1);

            tabung2 = new Asset3d(new Vector3(210 / 255f, 231 / 255f, 230 / 255f));
            tabung2.tabung(0, 0, 0, 0.02f, 0.02f, 0.012f);
            tabung2.rotate(tabungMedium.objectCenter, Vector3.UnitX, 90f);

            bola2 = new Asset3d(new Vector3(210 / 255f, 231 / 255f, 230 / 255f));
            bola2.createSphere(0, -0.455f, 0, 0.02f, 25, 25);
            bola2.translate(0, 0f, -0.3f);
            tabung2.child.Add(bola2);

            tabung3 = new Asset3d(new Vector3(210 / 255f, 231 / 255f, 230 / 255f));
            tabung3.tabung(0, 0, 0, 0.02f, 0.02f, 0.012f);
            tabung3.rotate(tabungMedium.objectCenter, Vector3.UnitX, 90f);

            bola3 = new Asset3d(new Vector3(210 / 255f, 231 / 255f, 230 / 255f));
            bola3.createSphere(0, -0.455f, 0, 0.02f, 25, 25);
            bola3.translate(0, 0f, -0.3f);
            tabung3.child.Add(bola3);

            tabung4 = new Asset3d(new Vector3(210 / 255f, 231 / 255f, 230 / 255f));
            tabung4.tabung(0, 0, 0, 0.02f, 0.02f, 0.012f);
            tabung4.rotate(tabungMedium.objectCenter, Vector3.UnitX, 90f);

            bola4 = new Asset3d(new Vector3(210 / 255f, 231 / 255f, 230 / 255f));
            bola4.createSphere(0, -0.455f, 0, 0.02f, 25, 25);
            bola4.translate(0, 0f, -0.3f);
            tabung4.child.Add(bola4);

            tabung5 = new Asset3d(new Vector3(210 / 255f, 231 / 255f, 230 / 255f));
            tabung5.tabung(0, 0, 0, 0.02f, 0.02f, 0.012f);
            tabung5.rotate(tabungMedium.objectCenter, Vector3.UnitX, 90f);

            bola5 = new Asset3d(new Vector3(210 / 255f, 231 / 255f, 230 / 255f));
            bola5.createSphere(0, -0.455f, 0, 0.02f, 25, 25);
            bola5.translate(0, 0f, -0.3f);
            tabung5.child.Add(bola5);

            tabung6 = new Asset3d(new Vector3(210 / 255f, 231 / 255f, 230 / 255f));
            tabung6.tabung(0, 0, 0, 0.02f, 0.02f, 0.012f);
            tabung6.rotate(tabungMedium.objectCenter, Vector3.UnitX, 90f);

            bola6 = new Asset3d(new Vector3(210 / 255f, 231 / 255f, 230 / 255f));
            bola6.createSphere(0, -0.455f, 0, 0.02f, 25, 25);
            bola6.translate(0, 0f, -0.3f);
            tabung6.child.Add(bola6);

            ring1 = new Asset3d(new Vector3(71 / 255f, 255 / 255f, 253 / 255f));
            ring1.createTorus(0, 0, 0, 0.1f, 0.02f, 30, 30);
            ring1.rotate(ring1.objectCenter, Vector3.UnitX, 90);
            ring1.rotate(ring1.objectCenter, Vector3.UnitY, 45);
            ring1.translate(-0.05f, 0.2f, 0.15f);

            ring2 = new Asset3d(new Vector3(71 / 255f, 255 / 255f, 253 / 255f));
            ring2.createTorus(0, 0, 0, 0.1f, 0.02f, 30, 30);
            ring2.rotate(ring1.objectCenter, Vector3.UnitX, 90);
            ring2.rotate(ring1.objectCenter, Vector3.UnitY, -45);
            ring2.translate(-0.05f, -0.15f, 0.075f);

            controlBox = new Asset3d(new Vector3(1f, 0, 0));
            controlBox.createBoxVertices(0, 0, 0);
            controlBox.scale(1f, 1f,0.5f);
            controlBox.rotate(controlBox.objectCenter, Vector3.UnitY, 90);
            controlBox.translate(-2.95f, -0.3f, -0.2f);

            kabel = new Asset3d(new Vector3(1, 0, 1));
            kabel.prepareVertices();
            kabel.setControlCoordinate(-2.65f, -0.2f, -0.5f);
            kabel.setControlCoordinate(-2.7f, -0.2f, -0.45f);
            kabel.setControlCoordinate(-2.73f, -0.225f, -0.2f);
            kabel.setControlCoordinate(-2.78f, -0.225f, -0.2f);
            kabel.setControlCoordinate(-2.80f, -0.25f, -0.2f);
            kabel.setControlCoordinate(-2.98f, -0.275f, -0.175f);
            List<Vector3> _verticesBazier = kabel.createCurveBazier();
            kabel.setVertices(_verticesBazier);

            tabungBesar.child.Add(ring1);
            tabungBesar.child.Add(ring2);

            tabungBesar.translate(-2.49f, -0.44f, -0.5f);
            tabung1.translate(-2.49f, 0.65f, -0.095f);
            tabung2.translate(-2.4f, 0.65f, -0.15f);
            tabung3.translate(-2.58f, 0.65f, -0.15f);
            tabung4.translate(-2.58f, 0.65f, -0.25f);
            tabung5.translate(-2.4f, 0.65f, -0.25f);
            tabung6.translate(-2.49f, 0.65f, -0.31f);

            listObject.Add(tabungBesar);
            listObject.Add(tutup);
            listObject.Add(tabungMedium);
            listObject.Add(tutup2);
            listObject.Add(holder);
            listObject.Add(bolaReaktor);

            listObject.Add(tabung1);
            listObject.Add(bola1);
            listObject.Add(tabung2);
            listObject.Add(bola2);
            listObject.Add(tabung3);
            listObject.Add(bola3);
            listObject.Add(tabung4);
            listObject.Add(bola4);
            listObject.Add(tabung5);
            listObject.Add(bola5);
            listObject.Add(tabung6);
            listObject.Add(bola6);

            listObject.Add(ring1);
            listObject.Add(ring2);

            listObject.Add(kabel);

            listObject.Add(controlBox);
        }
        static class Constants
        {
            public const string path = "D:../../../shader/";
        }
        public void load(int SizeX, int SizeY)
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
            bolaReaktor.rotate(bolaReaktor.objectCenter, Vector3.UnitY, 90f);
        }
    }
}
