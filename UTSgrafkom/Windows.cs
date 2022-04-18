using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
namespace UTSgrafkom
{
    static class Constants
    {
        public const string path = "D:../../../shader/";
    }
    internal class Windows : GameWindow
    {
        float degr,degr2 = 0;
        double time;
        List<Asset3d> listObject = new List<Asset3d>();
        float x = 0;
        Karakter karakter;
        ruangan room;
        Asset3d donat;
        Camera camera;
        Matrix4 temp2 = Matrix4.Identity;
        Matrix4 temp4 = Matrix4.Identity;
        int counter = 0;
        public Windows(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
            
        }

        protected override void OnLoad()
        {

            base.OnLoad();
            /*GL.Enable(EnableCap.DepthTest);*/
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            /*room = new ruangan(new Vector3(0.6f, 0.5f, 0.5f));
            room.createBoxVertices(0, 0, 0);*/
            donat = new Asset3d(new Vector3(1.0f, 1.0f, 1.0f));
            donat.createTorus(0f,-0.9f, 0f, 0.9f, 0.02f, 12, 12);
            karakter = new Karakter(0f, 0f, 0f, new Vector3(0, 0.5f, 1));
            karakter.load(Size.X,Size.Y);
            /*donat.load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);*/
            /*room.load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);*/
            camera = new Camera(new Vector3(0, 0, 1), Size.X / (float)Size.Y);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            /*GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);*/
            time += 15.0 * time;
            Matrix4 temp = Matrix4.Identity;
            degr = MathHelper.DegreesToRadians(0.5f);
            temp *= Matrix4.CreateRotationY(degr);
            Matrix4 temp3 = Matrix4.Identity;
            degr2 = MathHelper.DegreesToRadians(0f);
            temp3 *= Matrix4.CreateRotationX(degr2);
            /*temp4 *= Matrix4.CreateTranslation(new Vector3(0f, 0.001f, 0f));*/
            x += 0.001f;
            /*temp2 = Matrix4.CreateTranslation(new Vector3(0f, 0f, 0f));*/
            /*donat.render(1, temp3 * temp4, time, camera.GetViewMatrix(), camera.GetProjectionMatrix());*/
            karakter.render(args.Time,temp, camera.GetViewMatrix(), camera.GetProjectionMatrix());
            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            /*Console.WriteLine("halo");*/
            GL.Viewport(0, 0, Size.X, Size.Y);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            var input = KeyboardState;
            float cameraSpeed = 0.5f;
            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }
            if (input.IsKeyDown(Keys.W))
            {
                camera.Position += camera.Front * cameraSpeed * (float)args.Time;
            }
            if (input.IsKeyDown(Keys.A))
            {
                camera.Position -= camera.Right * cameraSpeed * (float)args.Time;
                /*Console.WriteLine("tombol a di release");*/
            }
            if (input.IsKeyDown(Keys.S))
            {
                camera.Position -= camera.Front * cameraSpeed * (float)args.Time;
            }
            if (input.IsKeyDown(Keys.D))
            {
                camera.Position += camera.Right * cameraSpeed * (float)args.Time;
            }

            if (input.IsKeyDown(Keys.Space))
            {
                camera.Position += camera.Up * cameraSpeed * (float)args.Time;
            }
            if (input.IsKeyDown(Keys.LeftControl))
            {
                camera.Position -= camera.Up * cameraSpeed * (float)args.Time;
            }

            if (input.IsKeyDown(Keys.Right))
            {
                camera.Yaw += cameraSpeed * (float)args.Time * 30.0f;
            }
            if (input.IsKeyDown(Keys.Left))
            {
                camera.Yaw -= cameraSpeed * (float)args.Time * 30.0f;
            }
            if (input.IsKeyDown(Keys.Up))
            {
                camera.Pitch += cameraSpeed * (float)args.Time * 30.0f;
            }
            if (input.IsKeyDown(Keys.Down))
            {
                camera.Pitch -= cameraSpeed * (float)args.Time * 30.0f;
            }
        }
    }
}
