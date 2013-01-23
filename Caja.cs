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
 public class Caja : Objeto3D
 {
  private float alto;
  private float ancho;
  private float fondo;
  private Color color;
  private Vertex[]  vertices;
  private Pen p;
  
  
  public Caja(Vector centro, float alto, float ancho, float fondo, Color color) 
  {
   
   this.centro=centro;
   this.ancho=ancho;
   this.alto=alto;
   this.fondo=fondo;
   this.color=color;
   
   p=new Pen(Color.Black);
   vertices=new Vertex[8];
   triangulos.Clear();
   float a=(float)(ancho/2.0);
   float h=(float)(alto/2.0);
   float f=(float)(fondo/2.0);
   
   vertices[0]=(new Vertex(centro.x-a,centro.y+h,centro.z-f));
   vertices[1]=(new Vertex(centro.x+a,centro.y+h,centro.z-f));
   vertices[2]=(new Vertex(centro.x+a,centro.y+h,centro.z+f));
   vertices[3]=(new Vertex(centro.x-a,centro.y+h,centro.z+f));
   vertices[4]=(new Vertex(centro.x-a,centro.y-h,centro.z-f));
   vertices[5]=(new Vertex(centro.x+a,centro.y-h,centro.z-f));
   vertices[6]=(new Vertex(centro.x+a,centro.y-h,centro.z+f));
   vertices[7]=(new Vertex(centro.x-a,centro.y-h,centro.z+f));
   
   triangulos.Add(new Triangulo(vertices[0],vertices[1],vertices[2],color,"Cara1T1"));
   triangulos.Add(new Triangulo(vertices[0],vertices[2],vertices[3],color,"Cara1T2"));
   triangulos.Add(new Triangulo(vertices[2],vertices[1],vertices[5],color,"Cara2T1"));
   triangulos.Add(new Triangulo(vertices[2],vertices[5],vertices[6],color,"Cara2T2"));
   triangulos.Add(new Triangulo(vertices[4],vertices[6],vertices[5],color,"Cara3T1"));
   triangulos.Add(new Triangulo(vertices[4],vertices[7],vertices[6],color,"Cara3T2"));
   triangulos.Add(new Triangulo(vertices[3],vertices[4],vertices[0],color,"Cara4T1"));
   triangulos.Add(new Triangulo(vertices[3],vertices[7],vertices[4],color,"Cara4T2"));
   triangulos.Add(new Triangulo(vertices[1],vertices[0],vertices[4],color,"Cara5T1"));
   triangulos.Add(new Triangulo(vertices[1],vertices[4],vertices[5],color,"Cara5T2"));
   triangulos.Add(new Triangulo(vertices[2],vertices[7],vertices[3],color,"Cara6T1"));
   triangulos.Add(new Triangulo(vertices[2],vertices[6],vertices[7],color,"Cara6T2"));
   
  }
 }
}
