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
        float degr = 0;
        double time;
        Karakter karakter;
        reactor reaktor1;
        ruangan ruang;
        Camera camera;
        vent coba1,coba2;
        public Windows(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
            
        }

        protected override void OnLoad()
        {

            base.OnLoad();
            GL.Enable(EnableCap.DepthTest);
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            
            ruang = new ruangan(new Vector3(0, 0.5f, 1));
            ruang.load(Size.X, Size.Y);

            reaktor1 = new reactor(new Vector3(0, 0.5f, 1));
            reaktor1.load(Size.X, Size.Y);

            coba1 = new vent(new Vector3(0, 0, 0));
            coba1.alasVent();
            coba1.load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);

            coba2 = new vent(new Vector3(1, 1, 1));
            coba2.tutupVent();
            coba2.load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);

            karakter = new Karakter(0f, 0f, 0f, new Vector3(0, 0.5f, 1));
            karakter.load(Size.X, Size.Y);

            camera = new Camera(new Vector3(0, 0, 1), Size.X / (float)Size.Y);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            time += 15.0 * time;
            Matrix4 temp = Matrix4.Identity;
            degr = MathHelper.DegreesToRadians(0.5f);
            temp *= Matrix4.CreateRotationX(degr);
            ruang.render(1, temp, time, camera.GetViewMatrix(), camera.GetProjectionMatrix());
            reaktor1.render(args.Time, temp, camera.GetViewMatrix(), camera.GetProjectionMatrix());
            coba1.render(1, temp, args.Time, camera.GetViewMatrix(), camera.GetProjectionMatrix());
            coba2.render(1, temp, args.Time, camera.GetViewMatrix(), camera.GetProjectionMatrix());
            karakter.render(args.Time, temp, camera.GetViewMatrix(), camera.GetProjectionMatrix());
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
