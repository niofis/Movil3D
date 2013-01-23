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
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using Movil3D;

namespace Movil3D
{
 public class Triangulo : Objeto3D
 {
  private Vector[] vertices;
  private Point[] pts;
  private Color color;
  private Brush br;
  private Vector normal;
  private Vector camara;
  private Vector v1;
  private Vector v2;
  //private Triangulo[] triangulos;  
  public float zi;
  
  public Triangulo(Vertex vr1, Vertex vr2, Vertex vr3,Color color, String nombre)
  {
   this.nombre=nombre;
   camara=new Vector(0,0,1);
   camara.Normalizar();
   this.color=color;
   br=new SolidBrush(color);
   normal=new Vector();
   vertices=new Vector[3];
   vertices[0]=new Vector(vr1);
   vertices[1]=new Vector(vr2);
   vertices[2]=new Vector(vr3);
   pts=new Point[3];
   pts[0]=new Point(0,0);
   pts[1]=new Point(0,0);
   pts[2]=new Point(0,0);
   v1=new Vector();
   v2=new Vector();
   //triangulos= new Triangulo[1];
   triangulos.Clear();
   triangulos.Add(this);
   CalculaZI();
  }
  
  public Point[] Puntos()
  {
   //float d=1;
   //d=1+(float)((vertices[0].z>1)?vertices[0].z*0.1:0);
   pts[0].X=(int)(vertices[0].x);
   pts[0].Y=(int)(vertices[0].y);
   //d=1+(float)((vertices[1].z>1)?vertices[1].z*0.1:0);
   pts[1].X=(int)(vertices[1].x);
   pts[1].Y=(int)(vertices[1].y);
   //d=1+(float)((vertices[2].z>1)?vertices[2].z*0.1:0);
   pts[2].X=(int)(vertices[2].x);
   pts[2].Y=(int)(vertices[2].y);
   return pts;
  }
  
  public override void Rotar(float rx, float ry, float rz, Vector centro)
  {
   Centrar(centro);
   float s,c,t;
   
   if(rx!=0)
   {
    s=(float)Math.Sin(rx);
    c=(float)Math.Cos(rx);
    foreach(Vector v in vertices)
    {
     t=c*v.y + s*v.z;
     v.z=-s*v.y + c*v.z;
     v.y=t;
    }
   }
   if(ry!=0)
   {
    s=(float)Math.Sin(ry);
    c=(float)Math.Cos(ry);
    foreach(Vector v in vertices)
    {
     t=c*v.x + s*v.z;
     v.z=-s*v.x + c*v.z;
     v.x=t;
    }
   }
   if(rz!=0)
   {
    s=(float)Math.Sin(rz);
    c=(float)Math.Cos(rz);
    foreach(Vector v in vertices)
    {
     t=c*v.x + s*v.y;
     v.y=-s*v.x + c*v.y;
     v.x=t;
    }
   }
   v1.x=vertices[1].x;
   v1.y=vertices[1].y;
   v1.z=vertices[1].z;
   v2.x=vertices[2].x;
   v2.y=vertices[2].y;
   v2.z=vertices[2].z;
   v1.Restar(vertices[0]);
   v2.Restar(vertices[0]);
   v1.PCruz(v2,normal);
   normal.Normalizar();
   Trasladar(centro);
   CalculaZI();
  }
  
  public override void Trasladar(Vector v)
  {
   foreach(Vector e in vertices)
   {
    e.x+=v.x;
    e.y+=v.y;
    e.z+=v.z;
   }
  }
  
  public override void Centrar(Vector v)
  {
   foreach(Vector e in vertices)
   {
    e.x-=v.x;
    e.y-=v.y;
    e.z-=v.z;
   }
  }
  
  public override void Pintar(Graphics g, bool wireframe)
  {
   float p=normal.PPunto(camara);
   //r=null; 
   //
   Color cl=Color.Black;
   if (!wireframe)
   {
       if (p > 0)
       {

           cl = Color.FromArgb((int)(color.R * p), (int)(color.G * p), (int)(color.B * p));
           br = new SolidBrush(cl);
           g.FillPolygon(br, Puntos());
           //g.DrawString(nombre, objectfont, objectbrush, vertices[1].x, vertices[1].y);
       }
   }
   else
   {
       if (p < 0) p = 0;
       cl = Color.FromArgb((int)(color.R * p), (int)(color.G * p), (int)(color.B * p));

       g.DrawPolygon(new Pen(cl,1), Puntos());
   }
   
   
  }
  
  public override string ToString()
  {
   string s;
   s="v1 " + vertices[0].ToString()+"\n";
   s+="v2 " + vertices[1].ToString()+"\n";
   s+="v3 " + vertices[2].ToString();
   return s;
  }
  
  public void CalculaZI()
  {
   zi=vertices[0].z;
   zi+=vertices[1].z;
   zi+=vertices[2].z;
   zi/=3;
  }
  
  public override void Escalar(float ex,float ey, float ez, Vector eje)
  {
   Centrar(eje);
   foreach(Vertex v in vertices)
   {
    v.x*=ex;
    v.y*=ey;
    v.z*=ez;
   }
   Trasladar(eje);
  }
  
 }
}
