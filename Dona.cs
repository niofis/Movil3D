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
using Movil3D;

namespace Movil3D
{
 public class Dona : Objeto3D
 {
  private int res1;
  private int res2;
  private float rad1;
  private float rad2;
  private Color color;
  private Vertex[][] vertices;
  //private Vertex[] pivotes;
  private Vertex[] piv2;
  //private Triangulo[][] triangulos;
  private SolidBrush sb;
  
  public Dona(Vector centro, int res1, int res2, float rad1, float rad2, Color color)
  {
   this.res1=res1;
   this.res2=res2;
   this.centro=centro;
   this.rad1=rad1;
   this.rad2=rad2;
   this.color=color;
   sb=new SolidBrush(color);
   Generar();
  }
  
  public void Generar()
  {
   int x=0,y=0;
   float grad=(float)(((float)360/(float)res1)* 0.01745329);
   piv2=new Vertex[res2];
   Vertex p1;
   
   vertices=new Vertex[res1][];
   for(y=0;y<res1;y++)
   {
    vertices[y]=new Vertex[res2];
   }
   
   float grad2=(float)(((float)360/(float)res2)* 0.01745329);
   p1=new Vertex(0,0,rad2);
   piv2= new Vertex[res2];
   for(x=0;x<res2;x++)
   {
    piv2[x]=new Vertex(p1.x,p1.y-rad1,p1.z);
    p1.Rotar(grad2,0,0);
   }
   for(y=0;y<res1;y++)
   {
    for(x=0;x<res2;x++)
    {
     vertices[y][x]=new Vertex(piv2[x]);
    }
    foreach(Vertex v in piv2)
    {
     v.Rotar(0,0,grad);
    }
   }
   
   TrasladarP(centro);
   
   triangulos.Clear();
   
   
   Vertex v1,v2,v3;
   int t;
   for(y=0;y<res1;y++)
    for(x=0;x<res2;x++)
    {
     t=(y+1<res1)?y+1:0;
     v1=vertices[y][x];
     v2=vertices[t][x];
     v3=(x+1<res2)?vertices[t][x+1]:vertices[t][0];     
     triangulos.Add(new Triangulo(v1,v2,v3,color,"t"));
     
     
     v1=vertices[y][x];
     v2=(x+1<res2)?v2=vertices[y][x+1]:vertices[y][0];
     v3=(x+1<res2)?vertices[t][x+1]:vertices[t][0]; 
     triangulos.Add(new Triangulo(v1,v3,v2,color,"t"));
    }
   
  }
  
  private void TrasladarP(Vector v)
  {
   for(int y=0;y<res1;y++)
    for(int x=0;x<res2;x++)
    {
     vertices[y][x].x+=v.x;
     vertices[y][x].y+=v.y;
     vertices[y][x].z+=v.z;
    }
  }
  
  private void CentrarP(Vector v)
  {
   for(int y=0;y<res1;y++)
    for(int x=0;x<res2;x++)
    {
     vertices[y][x].x-=v.x;
     vertices[y][x].y-=v.y;
     vertices[y][x].z-=v.z;
    }
  }  
 }
}
