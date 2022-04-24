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
    internal class ruangan : tembok, Item
    {
        List<tembok> listTembok = new List<tembok>();
        List<Asset3d> listObject = new List<Asset3d>();
        Asset3d blkgKiri, blkgKanan, lantaiKiri, lantaiKanan;
        tembok atap, alas, tembokKiri, tembokKanan, belakang, sekat1, sekat2;
        public ruangan(Vector3 color) : base(color)
        {
            alas = new tembok(new Vector3(0.231f, 0.231f, 0.231f));
            alas.createAlas(0f, 0, -1f);

            atap = new tembok(new Vector3(0.231f, 0.231f, 0.231f));
            atap.createAtap(0f, 0, -1f);

            tembokKiri = new tembok(new Vector3(55 / 255f, 50 / 255f, 100 / 255f));
            tembokKiri.createSampingKiri(0f, 0, -1f);

            tembokKanan = new tembok(new Vector3(119 / 255f, 216 / 255f, 253 / 255f));
            tembokKanan.createSampingKanan(0f, 0, -1f);

            belakang = new tembok(new Vector3(1f, 1f, 1f));
            belakang.createBelakang(0f, 0, -1f);

            sekat1 = new tembok(new Vector3(55 / 255f, 50 / 255f, 100 / 255f));
            sekat1.createSekat1(0f, 0, -1f);

            sekat2 = new tembok(new Vector3(119 / 255f, 216 / 255f, 253 / 255f));
            sekat2.createSekat2(0f, 0, -1f);

            blkgKiri = new Asset3d(new Vector3(50 / 255f, 45 / 255f, 100 / 255f));
            blkgKiri.createBlock(0, 0, 0, 2, 1.4f, 0);
            blkgKiri.translate(-2, 0.25f, -0.999f);

            blkgKanan = new Asset3d(new Vector3(115 / 255f, 207 / 255f, 243 / 255f));
            blkgKanan.createBlock(0, 0, 0, 2, 1.4f, 0);
            blkgKanan.translate(2, 0.25f, -0.999f);

            lantaiKiri = new Asset3d(new Vector3(168 / 255f, 212 / 255f, 215 / 255f));
            lantaiKiri.createBlock(0, 0, 0, 2f, 0, 1);
            lantaiKiri.translate(-2, -0.449f, -0.5f);

            lantaiKanan = new Asset3d(new Vector3(195 / 255f, 211 / 255f, 218 / 255f));
            lantaiKanan.createBlock(0, 0, 0, 2f, 0, 1);
            lantaiKanan.translate(2, -0.449f, -0.5f);


            listTembok.Add(alas);
            listTembok.Add(atap);
            listTembok.Add(tembokKiri);
            listTembok.Add(tembokKanan);
            listTembok.Add(belakang);
            listTembok.Add(sekat1);
            listTembok.Add(sekat2);
            listObject.Add(blkgKiri);
            listObject.Add(blkgKanan);
            listObject.Add(lantaiKiri);
            listObject.Add(lantaiKanan);
        }

        public void load(int SizeX, int SizeY)
        {
            foreach (Asset3d i in listTembok)
            {
                i.load(Constants.path + "shader.vert", Constants.path + "shader.frag", SizeX, SizeY);
            }

            foreach (Asset3d i in listObject)
            {
                i.load(Constants.path + "shader.vert", Constants.path + "shader.frag", SizeX, SizeY);
            }
        }

        public void Render(Matrix4 cameraView, Matrix4 cameraProjection) 
        {
            foreach (Asset3d i in listTembok)
            {
                i.render(cameraView, cameraProjection);
            }

            foreach (Asset3d i in listObject)
            {
                i.render(cameraView, cameraProjection);
            }

        }        
    }
}
