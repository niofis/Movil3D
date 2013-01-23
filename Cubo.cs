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
 public class Cubo : Objeto3D
 {
  private Vector c;
  private float ancho;
  private Vertex[]  vertices;
  //private Triangulo[] triangulos;
  private Pen p;
  
  
  public Cubo(Vector centro, float ancho) 
  {
   this.centro=this.c=centro;
   this.ancho=ancho;
   p=new Pen(Color.Black);
   vertices=new Vertex[8];
   triangulos.Clear();
   
   vertices[0]=(new Vertex(c.x-ancho,c.y+ancho,c.z-ancho));
   vertices[1]=(new Vertex(c.x+ancho,c.y+ancho,c.z-ancho));
   vertices[2]=(new Vertex(c.x+ancho,c.y+ancho,c.z+ancho));
   vertices[3]=(new Vertex(c.x-ancho,c.y+ancho,c.z+ancho));
   vertices[4]=(new Vertex(c.x-ancho,c.y-ancho,c.z-ancho));
   vertices[5]=(new Vertex(c.x+ancho,c.y-ancho,c.z-ancho));
   vertices[6]=(new Vertex(c.x+ancho,c.y-ancho,c.z+ancho));
   vertices[7]=(new Vertex(c.x-ancho,c.y-ancho,c.z+ancho));
   
   triangulos.Add(new Triangulo(vertices[0],vertices[1],vertices[2],Color.Blue,"Cara1T1"));
   triangulos.Add(new Triangulo(vertices[0],vertices[2],vertices[3],Color.Blue,"Cara1T2"));
   triangulos.Add(new Triangulo(vertices[2],vertices[1],vertices[5],Color.Red,"Cara2T1"));
   triangulos.Add(new Triangulo(vertices[2],vertices[5],vertices[6],Color.Red,"Cara2T2"));
   triangulos.Add(new Triangulo(vertices[4],vertices[6],vertices[5],Color.Green,"Cara3T1"));
   triangulos.Add(new Triangulo(vertices[4],vertices[7],vertices[6],Color.Green,"Cara3T2"));
   triangulos.Add(new Triangulo(vertices[3],vertices[4],vertices[0],Color.Yellow,"Cara4T1"));
   triangulos.Add(new Triangulo(vertices[3],vertices[7],vertices[4],Color.Yellow,"Cara4T2"));
   triangulos.Add(new Triangulo(vertices[1],vertices[0],vertices[4],Color.Purple,"Cara5T1"));
   triangulos.Add(new Triangulo(vertices[1],vertices[4],vertices[5],Color.Purple,"Cara5T2"));
   triangulos.Add(new Triangulo(vertices[2],vertices[7],vertices[3],Color.Brown,"Cara6T1"));
   triangulos.Add(new Triangulo(vertices[2],vertices[6],vertices[7],Color.Brown,"Cara6T2"));
   
  }
 }
}
