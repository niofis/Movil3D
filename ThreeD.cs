/* Copyright (c) 2007, niofis
* All rights reserved.
*
* Redistribution and use in source and binary forms, with or without
* modification, are permitted provided that the following conditions are met:
*     * Redistributions of source code must retain the above copyright
*       notice, this list of conditions and the following disclaimer.
*     * Redistributions in binary form must reproduce the above copyright
*       notice, this list of conditions and the following disclaimer in the
*       documentation and/or other materials provided with the distribution.
*
* THIS SOFTWARE IS PROVIDED BY niofis ``AS IS'' AND ANY
* EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
* WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
* DISCLAIMED. IN NO EVENT SHALL niofis BE LIABLE FOR ANY
* DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
* (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
* LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
* ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
* (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
* SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/


using System;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using Movil3D;

namespace Movil3D
{
 public class ThreeD : Form
 {
  private int xa;
  private int ya;
  private float dx,dy;
  private Image img;
  private Graphics gr,gi;
  private Cubo cubo;
  private Esfera esfera;
  private Dona dona;
  private Cono cono;
  private Cilindro cilindro;
  private Caja caja;
  private Graphics3D g3d;
  private Mesh mesh;
  
  public ThreeD()
  {
   this.Text="ThreeD";
   //MessageBox.Show("Fijate");
   Init();
  }
  public void Init()
  {
			//this.DoubleBuffered=true;
   this.MouseDown += new MouseEventHandler(this.OnMouseDown);
   this.MouseUp += new MouseEventHandler(this.OnMouseUp);
   this.MouseMove += new MouseEventHandler(this.OnMouseMove);
   this.Paint += new PaintEventHandler(this.OnPaint);
   this.KeyUp += new KeyEventHandler(this.OnKeyUp);
   this.MouseWheel+=new MouseEventHandler(this.OnMouseWheel);
   //this.Idle += new EventHandler(this.OnIdle);
   this.Width = 600;
   this.Height = 600;
   gr= this.CreateGraphics();
   img=new Bitmap(this.Width,this.Height);
   gi=Graphics.FromImage(img);
   cubo=new Cubo(new Vector(this.Width/2,this.Height/2,0),150);
   //esfera=new Esfera(new Vector(this.Width/2,this.Height/2,0),15,100,Color.Blue);
   dona=new Dona(new Vector(this.Width/2,this.Height/2,0),70,40,150,60,Color.Green);
   //cono = new Cono(new Vector(this.Width/2, this.Height / 2, 0), 20, 25, 50, Color.Red);
   //cilindro = new Cilindro(new Vector(this.Width / 2, this.Height / 2, 0), 10, 25, 50, Color.Yellow);
   //caja=new Caja(new Vector(this.Width/2,this.Height/2,0),50,30,20,Color.Purple);
   mesh=new Mesh(new Vector(this.Width/2,this.Height/2,0));
   g3d=new Graphics3D(new Vector(this.Width/2,this.Height/2,0));
   //g3d.Agregar(cilindro);
   //g3d.Agregar(caja);
   g3d.Agregar(cubo);
   g3d.Agregar(dona);
   //g3d.Agregar(cono);
   //g3d.Agregar(mesh);
   //AbrirArchivo();
   g3d.Wireframe = true;
  }
  
  public void OnKeyUp(object sender, KeyEventArgs e)
  {
   if(e.KeyCode == Keys.Up)
    MessageBox.Show(Keys.Up.ToString());
  }
  
  public void AbrirArchivo()
  {
   OpenFileDialog dlg;
   dlg=new OpenFileDialog();
   dlg.Filter="MilkShape3D files (*.ms3d)|*.ms3d";
   if(dlg.ShowDialog()==DialogResult.OK)
   {
    mesh.Cargar(dlg.FileName);
    g3d.Agregar(mesh);
   }
  }
  
  public void OnIdle(object sender, EventArgs e)
  {
   
  }
  public void OnPaint(object sener, PaintEventArgs e)
  {
			Redraw();
			
			//gr.DrawImage(img,0,0);
  }
		public void Redraw()
		{
			int inicio=Environment.TickCount;
		  //gr.DrawLine(new Pen(Color.Black),xa,ya,e.X,e.Y);
		  gi.FillRectangle(new SolidBrush(Color.White),0,0,this.Width,this.Height);
		   
		   
			g3d.Pintar(gi); 
		   
		  gr.DrawImage(img,0,0);
		  int fin=Environment.TickCount;
		  int total=fin - inicio;
		  float se=((float)total)/1000.0f;
			this.Text = String.Format("{0:0.00} fps - {1:0.00} segs",1/se,se);
		}
  public void OnMouseDown(object sender, MouseEventArgs e)
  {
			xa=e.X;
			ya=e.Y;
  }  
  public void OnMouseUp(object sender, MouseEventArgs e)
  {
  }
  public void OnMouseWheel(object sender, MouseEventArgs e)
  {
			if(e.Delta<0)
				g3d.Escalar(0.9f,0.9f,0.9f);
			else
				g3d.Escalar(1.1f,1.1f,1.1f);
			Redraw();
  }
  public void OnMouseMove(object sender, MouseEventArgs e)
  {
			dx=xa-e.X;
		  dy=ya-e.Y;
		   
		   
		  dx*=0.01745329f;
		  dy*=0.01745329f;
			g3d.Rotar(dy,dx,0);
			xa=e.X;
		  ya=e.Y;
			Redraw();
  }


  private void InitializeComponent()
  {
      this.SuspendLayout();
      // 
      // ThreeD
      // 
      this.ClientSize = new System.Drawing.Size(292, 266);
      this.Name = "ThreeD";
      this.ResumeLayout(false);

  }
 } 
}

