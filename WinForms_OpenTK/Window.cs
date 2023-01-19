using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WinForms_OpenTK
{
    public class Window : GameWindow
    {
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
            Console.WriteLine(GL.GetString(StringName.Version));
            // Console.WriteLine(GL.GetString(StringName.Extensions));
            Console.WriteLine(GL.GetString(StringName.Renderer));
            Console.WriteLine(GL.GetString(StringName.Vendor));
            Console.WriteLine(GL.GetString(StringName.ShadingLanguageVersion));

            VSync = VSyncMode.On;
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            // Check if the Escape button is currently being pressed.
            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                // If it is, close the window.
                Close();
            }
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            // Отбрасываем грань
            GL.Enable(EnableCap.CullFace);
            // default back. Задняя грань - против часовой.
            // GL.CullFace(CullFaceMode.Back);
            //GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
            //GL.PolygonMode(MaterialFace.Back, PolygonMode.Line);
            GL.ClearColor(Color4.Aqua);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.ClearColor(Color4.Aqua);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // Primitives: points, lines, lineStrip,
            //             lineLoop, Polygon, Triangles,
            //             triangleStrip, TriangleFan,
            //             quads, quadstrip.

            //GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            // GL.PointSize(60);
            GL.Rotate(0.9f, 0, 1f, 0);
            // GL.Rotate(0.5f, 0.5f, 0f, 0.5f);
            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(1f, 0, 0);
            GL.Vertex2(-0.5, -0.5);
            GL.Color3(0, 1f, 0);
            GL.Vertex2(0, 0.5);
            GL.Color3(0f, 0f, 1f);
            GL.Vertex2(0.5, -0.5);

            GL.Color3(1f, 1f, 0);
            GL.Vertex2(-0.9, 0.9);
            GL.Color3(0f, 1f, 1f);
            GL.Vertex2(0.9, 0.8);
            GL.Vertex2(0.9, 0.9);

            GL.End();

            GL.LineWidth(5f);
            GL.Begin(PrimitiveType.LineLoop);
            GL.Color3(0, 0, 0);
            GL.Vertex2(-0.5, -0.5);
            GL.Vertex2(0, 0.5);
            GL.Vertex2(0.5, -0.5);
            GL.End();

            DrawMyName();

            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Size.X, Size.Y);
        }

        protected override void OnUnload()
        {
            base.OnUnload();
        }

        void DrawMyName()
        {
            // Name
            GL.Begin(PrimitiveType.LineLoop);
            GL.Color3(0, 0, 0);
            GL.Vertex2(-0.92, -0.6);
            GL.Vertex2(-0.77, -0.7);
            GL.Vertex2(-0.77, -0.87);
            GL.Vertex2(-0.92, -0.92);
            GL.End();

            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex2(-0.6, -0.92);
            GL.Vertex2(-0.5, -0.62);
            GL.Vertex2(-0.4, -0.92);
            GL.End();
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(-0.6, -0.82);
            GL.Vertex2(-0.4, -0.82);
            GL.End();

            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex2(-0.3, -0.92);
            GL.Vertex2(-0.2, -0.62);
            GL.Vertex2(-0.1, -0.92);
            GL.Vertex2(0, -0.62);
            GL.Vertex2(0.1, -0.92);
            GL.End();

            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(0.2, -0.92);
            GL.Vertex2(0.2, -0.64);
            GL.End();
            GL.PointSize(6);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(0.197, -0.62);
            GL.End();

            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex2(0.3, -0.92);
            GL.Vertex2(0.3, -0.62);
            GL.Vertex2(0.4, -0.7);
            GL.Vertex2(0.3, -0.8);
            GL.Vertex2(0.4, -0.92);
            GL.End();
        }
    }
}
