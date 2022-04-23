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
        tembok atap, alas, tembokKiri, tembokKanan, belakang, sekat1, sekat2;
        public ruangan(Vector3 color) : base(color)
        {
            alas = new tembok(new Vector3(0.231f, 0.231f, 0.231f));
            alas.createAlas(0f, 0, -1f);

            atap = new tembok(new Vector3(0.231f, 0.231f, 0.231f));
            atap.createAtap(0f, 0, -1f);

            tembokKiri = new tembok(new Vector3(0.231f, 0.2315f, 0.231f));
            tembokKiri.createSampingKiri(0f, 0, -1f);

            tembokKanan = new tembok(new Vector3(0.231f, 0.231f, 0.231f));
            tembokKanan.createSampingKanan(0f, 0, -1f);

            belakang = new tembok(new Vector3(0.231f, 0.231f, 0.231f));
            belakang.createBelakang(0f, 0, -1f);

            sekat1 = new tembok(new Vector3(0f, 0f, 0f));
            sekat1.createSekat1(0f, 0, -1f);

            sekat2 = new tembok(new Vector3(0f, 0f, 0f));
            sekat2.createSekat2(0f, 0, -1f);

            listTembok.Add(alas);
            listTembok.Add(atap);
            listTembok.Add(tembokKiri);
            listTembok.Add(tembokKanan);
            listTembok.Add(belakang);
            listTembok.Add(sekat1);
            listTembok.Add(sekat2);
        }

        public void load(int SizeX, int SizeY)
        {
            foreach (Asset3d i in listTembok)
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

        }        
    }
}
