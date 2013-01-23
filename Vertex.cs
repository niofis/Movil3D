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

namespace Movil3D
{
 public class Vertex
 {
  public float x,y,z;
  public Vertex()
  {
   x=0;
   y=0;
   z=0;
  }
  public Vertex(float x, float y, float z)
  {
   this.x=x;
   this.y=y;
   this.z=z;
  }
  
  public Vertex(Vertex v)
  {
   this.x=v.x;
   this.y=v.y;
   this.z=v.z;
  }
  
  public void Rotar(float rx, float ry, float rz)
  {
   float s,c,t;
   
   if(rx!=0)
   {
    s=(float)Math.Sin(rx);
    c=(float)Math.Cos(rx);
    t=c*y + s*z;
    z=-s*y + c*z;
    y=t;
   }
   
   if(ry!=0)
   {
    s=(float)Math.Sin(ry);
    c=(float)Math.Cos(ry);
    t=c*x + s*z;
    z=-s*x + c*z;
    x=t;
   }
   
   if(rz!=0)
   {
    s=(float)Math.Sin(rz);
    c=(float)Math.Cos(rz);
    t=c*x + s*y;
    y=-s*x + c*y;
    x=t;
   }
  }
  
  public override string ToString()
  {
   return "x="+x.ToString()+" y="+y.ToString()+" z="+z.ToString();
  }
 }
}
