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
using Movil3D;

namespace Movil3D
{
 public class Vector : Vertex
 {
  private float n;
  public Vector()
  {
   this.x=0;
   this.y=0;
   this.z=0;
  } 
  
  public Vector(float x, float y, float z)
  {
   this.x=x;
   this.y=y;
   this.z=z;
  }
  
  public Vector(Vertex vx)
  {
   this.x=vx.x;
   this.y=vx.y;
   this.z=vx.z;
  }
  
  public void Normalizar()
  {
   n=(float)Math.Sqrt(x*x + y*y + z*z);
   if(n>0)
   {
    this.x/=n;
    this.y/=n;
    this.z/=n;
   }
  }
  
  public Vector PCruz(Vector v)
  {
   Vector s=new Vector();
   s.x=y*v.z-z*v.y;
   s.y=x*v.z-z*v.x;
   s.z=x*v.y-y*v.x;
   return s;
  }
  
  public void PCruz(Vector b, Vector c)
  {
   c.x=(y*b.z)-(z*b.y);
   c.y=-((x*b.z)-(z*b.x));
   c.z=(x*b.y)-(y*b.x);
  }
  
  public float PPunto(Vector v)
  {
   return x*v.x + y*v.y + z*v.z;
  }
  
  public void Restar(Vector v)
  {
   x-=v.x;
   y-=v.y;
   z-=v.z;
  }
  
  public void Sumar(Vector v)
  {
   x+=v.x;
   y+=v.y;
   z+=v.z;
  }
  
  public override String ToString()
  {
   return "x=" + x.ToString() + " y=" + y.ToString() + " z=" + z.ToString();
  }
 }
}
