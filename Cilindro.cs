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
 public class Cilindro : Objeto3D
 {
  public int res;
  public float rad;
  public float alto;
  public Color color;
  public SolidBrush sb;
  public Vertex[] puntosu;
  public Vertex[] puntosd;
  
  public Cilindro(Vector centro,int res,float rad, float alto, Color color)
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
   
   puntosu =new Vertex[res+1];
   puntosd =new Vertex[res+1];
   float grad=(float)(((float)360/(float)res)*0.01745329);
   
   int x,y;
   float ha=alto/2;
   Vertex p=new Vertex(0,0,-rad);
   for(x=0;x<res;x++)
   {
    puntosu[x]= new Vertex(p.x,p.y-ha,p.z);
    puntosd[x]= new Vertex(p.x,p.y+ha,p.z);
    p.Rotar(0,grad,0);
   }
   puntosu[res]=new Vertex(0,-ha,0);
   puntosd[res]= new Vertex(0,ha,0);
   //triangulos= new Triangulo[res*4];
   triangulos.Clear();
   
   for(y=0;y<res+1;y++)
   {
    puntosu[y].x-=centro.x;
    puntosu[y].y-=centro.y;
    puntosu[y].z-=centro.z;
    puntosd[y].x-=centro.x;
    puntosd[y].y-=centro.y;
    puntosd[y].z-=centro.z;
   }
   
   for(x=0;x<res;x++)
   {
    y=(x+1<res)?x+1:0;
    triangulos.Add(new Triangulo(puntosu[y],puntosu[x],puntosd[x],color,"t"));
    triangulos.Add(new Triangulo(puntosd[x],puntosd[y],puntosu[y],color,"t"));
    triangulos.Add(new Triangulo(puntosu[x],puntosu[y],puntosu[res],color,"t"));
    triangulos.Add(new Triangulo(puntosd[y],puntosd[x],puntosd[res],color,"t"));
   }   
   
   for(y=0;y<res+1;y++)
   {
    puntosu[y].x+=centro.x;
    puntosu[y].y+=centro.y;
    puntosu[y].z+=centro.z;
    puntosd[y].x+=centro.x;
    puntosd[y].y+=centro.y;
    puntosd[y].z+=centro.z;
   }
  }
 }
}
