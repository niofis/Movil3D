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
 public class Esfera : Objeto3D
 {
  private int res;
  private float r;
  private Color color;
  private Vertex[][] vertices;
  //private Triangulo[][] triangulos;
  private SolidBrush br;
  
  public Esfera(Vector centro,int res, float r, Color color)
  {
   this.res=res;
   this.r=r;
   this.color=color;
   this.centro=centro;
   br=new SolidBrush(this.color);
   Generar();
  }
  
  public void Generar()
  {
   int x=0,y=0;
   double grad=(float)(((float)180/(float)res)* 0.01745329);
   vertices=new Vertex[res+1][];
   Vertex vi,vf,vt;
   vi=new Vertex(0,-r,0);
   vf=new Vertex(0,r,0);
   
   for(x=0;x<res+1;x++)
   {
    vertices[x]=new Vertex[res+1];
   }
   
   for(x=0;x<res+1;x++)
   {
    vertices[0][x]=new Vertex(vi);
    vertices[res][x]=new Vertex(vf);
   }
   
   for(y=1;y<res;y++)
   {
    vt=new Vertex(vi);
    vt.Rotar(0,0,(float)(grad*y));
    for(x=0;x<res+1;x++)
    {
     vertices[y][x]=new Vertex(vt);
     vt.Rotar(0,(float)(grad*2),0);
    }
   }
   res++;
   triangulos.Clear();//=new Triangulo[res][];
   
   TrasladarP(centro);
   
   Vertex v1,v2,v3;
   
   for(y=0;y<res-1;y++)
    for(x=0;x<res;x++)
    {
     v1=vertices[y][x];
     v2=vertices[y+1][x];
     v3=(x+1<res)?vertices[y+1][x+1]:vertices[y+1][0];     
     triangulos.Add(new Triangulo(v1,v2,v3,color,"t"));
     
     v1=vertices[y][x];
     v2=(x+1<res)?v2=vertices[y][x+1]:vertices[y][0];
     v3=(x+1<res)?vertices[y+1][x+1]:vertices[y+1][0]; 
     triangulos.Add(new Triangulo(v1,v3,v2,color,"t"));
    }
   
   vertices=null;
   
  }
  private void TrasladarP(Vector v)
  {
   for(int y=0;y<res;y++)
    for(int x=0;x<res;x++)
    {
     vertices[y][x].x+=v.x;
     vertices[y][x].y+=v.y;
     vertices[y][x].z+=v.z;
    }
  }  
 }
}
