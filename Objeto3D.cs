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
using System.Collections;
using System.Drawing;
using Movil3D;

namespace Movil3D
{
 public abstract class Objeto3D
 {
  public SolidBrush objectbrush;
  public Font objectfont;
  public String nombre;
  public ArrayList triangulos;
  public Vector centro;
  
  
  public Objeto3D()
  {
   objectfont= new Font("Arial",8,FontStyle.Regular);
   objectbrush= new SolidBrush(Color.Black);
   nombre="";
   triangulos=new ArrayList();
   centro=new Vector(0,0,0);
  }
  
  public virtual ArrayList GeneraTriangulos()
  {
   return triangulos;
  }

  public virtual void Pintar(Graphics g, bool wireframe)
  {
   foreach(Triangulo t in triangulos)
   {
    t.Pintar(g,wireframe);
   }
  }
  
  public virtual void Rotar(float rx, float ry, float rz)
  {
   Rotar(rx,ry,rz,centro);
  }
  
  public virtual void Rotar(float rx, float ry, float rz, Vector eje)
  {
   foreach(Triangulo t in triangulos)
   {
    t.Rotar(rx,ry,rz,eje);
   }
  }
  
  public virtual void Trasladar(Vector vector)
  {
   foreach(Triangulo t in triangulos)
   {
    t.Trasladar(vector);
   }
  }
  
  public virtual void Centrar(Vector vector)
  {
   foreach(Triangulo t in triangulos)
   {
    t.Centrar(vector);
   }
  }
  
  public virtual void Escalar(float ex, float ey, float ez)
  {
   Escalar(ex,ey,ez,centro);
  }

  public virtual void Escalar(float ex, float ey, float ez, Vector eje)
  {
   foreach(Triangulo t in triangulos)
   {
    t.Escalar(ex,ey,ez);
   }
  }
 }
}


