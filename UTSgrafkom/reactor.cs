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
        public reactor(Vector3 color) : base(color)
        {
            warna = new Vector3(color);

            Asset3d tabungBesar = new Asset3d(new Vector3(0.45f, 0.5f, 0.55f));
            tabungBesar.tabung(-2.49f,-0.5f,0.5f, 0.2f, 0.2f, 0.02f);
            tabungBesar.rotate(tabungBesar.objectCenter, Vector3.UnitX, 90f);
            
            Asset3d tutup = new Asset3d(new Vector3(0.45f, 0.5f, 0.55f));
            tutup.createEllipsoid(-2.49f, -0.1f, 0.5f, 0.2f, 0.2f, 0.02f, 25, 25);
            tutup.rotate(tutup.objectCenter, Vector3.UnitX, 90f);
            tabungBesar.child.Add(tutup);

            Asset3d tabungMedium = new Asset3d(new Vector3(1f, 0.5f, 0.55f));
            tabungMedium.tabung(-2.49f, -0.5f, 0.35f, 0.1f, 0.1f, 0.02f);
            tabungMedium.rotate(tabungMedium.objectCenter, Vector3.UnitX, 90f);

            Asset3d tutup2 = new Asset3d(new Vector3(1f, 0.5f, 0.55f));
            tutup2.createEllipsoid(-2.49f, -0.1f, 0.35f, 0.1f, 0.1f, 0.02f, 25, 25);
            tutup2.rotate(tutup2.objectCenter, Vector3.UnitX, 90f);
            tabungMedium.child.Add(tutup2);

            tabungBesar.translate(0, 0.01f, -1.0f);
            tabungMedium.translate(0, 0.3f, -0.85f);

            listObject.Add(tabungMedium);
            listObject.Add(tabungBesar);
            listObject.Add(tutup);
            listObject.Add(tutup2);
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
        public void Render(Matrix4 cameraView, Matrix4 cameraProjection)
        {
            for (int i = 0; i < listObject.Count; i++)
            {
                listObject[i].render(cameraView, cameraProjection);
            }
        }
    }
}
