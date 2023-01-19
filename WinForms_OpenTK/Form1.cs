using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_OpenTK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NativeWindowSettings nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(800, 600),
                Title = "OpenGL App",
                // Flags = ContextFlags.ForwardCompatible,
                Flags = ContextFlags.Default,
                Location = new Vector2i(400, 400),

                APIVersion = new Version(3, 3),
                // Profile = ContextProfile.Core,
                Profile = ContextProfile.Compatability,
                API = ContextAPI.OpenGL
            };

            using (Window Window = new Window(GameWindowSettings.Default, nativeWindowSettings))
            {
                Window.Run();
            }
        }
    }
}
