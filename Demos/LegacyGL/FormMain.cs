﻿using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LegacyGL
{
    public partial class FormMain : Form
    {
        private Scene scene;
        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(0, 0, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene()
            {
                Camera = camera,
                ClearColor = Color.Black,
                RootElement = new BoundedClockRenderer(),
            };

            winGLCanvas1_Resize(this.winGLCanvas1, EventArgs.Empty);
        }

        void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            this.scene.Render();
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }
    }
}
