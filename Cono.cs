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
 public class Cono : Objeto3D
 {
  public int res;
  public float rad;
  public float alto;
  public Color color;
  public SolidBrush sb;
  public Vertex[] puntos;
  
  public Cono(Vector centro,int res,float rad, float alto, Color color)
  { 
   this.centro=centro;
   this.res=res;
   this.rad=rad;
   this.alto=alto;
   this.color=color;
   //sb=new SolidBrush(color);
   Generar();
  }
  
  public void Generar()
  {
   puntos =new Vertex[res+2];
   float grad=(float)(((float)360/(float)res)*0.01745329);
   
   int x,y;
   Vertex p=new Vertex(0,0,-rad);
   for(x=0;x<res;x++)
   {
    puntos[x]= new Vertex(p);
    p.Rotar(0,grad,0);
   }
   puntos[res]=new Vertex(0,-alto,0);
   puntos[res+1]= new Vertex(0,0,0);
   triangulos.Clear();
   TrasladarP(new Vector(0,alto/2,0));
   TrasladarP(centro);
   for(x=0;x<res;x++)
   {
    y=(x+1<res)?x+1:0;
    triangulos.Add(new Triangulo(puntos[x],puntos[y],puntos[res],color,"t"));
    triangulos.Add(new Triangulo(puntos[y],puntos[x],puntos[res+1],color,"t"));
   }   
   TrasladarP(centro);
  }
  
  private void TrasladarP(Vector v)
  {
   for(int y=0;y<res+2;y++)
   {
    puntos[y].x+=v.x;
    puntos[y].y+=v.y;
    puntos[y].z+=v.z;
   }
  }
 }
}
