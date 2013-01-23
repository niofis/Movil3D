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
using System.Collections;
using System.Collections.Generic;
using Movil3D;
using System.Windows.Forms;

namespace Movil3D
{
 public class Graphics3D
 {
  private ArrayList objetos;
  private List<Triangulo> triangulos;
  private Vector centro;
  private Random rnd;
  private bool wireframe;
  
  public Graphics3D(Vector centro)
  {
   objetos=new ArrayList();
   triangulos=new List<Triangulo>();
   this.centro=centro;
   rnd = new Random();
   wireframe = false;
  }

  public Boolean Wireframe
  {
      get
      {
          return wireframe;
      }
      set
      {
          wireframe = value;
      }
  }
  
  public void Agregar(Objeto3D objeto)
  {
   objetos.Add(objeto);
   AgregaTriangulos(objeto.GeneraTriangulos());
  }
  
  private void AgregaTriangulos(ArrayList trs)
  {
   foreach(Triangulo t in trs)
   {
    triangulos.Add(t);
   }
  }  
  
  public void Pintar(Graphics g)
  {
   OrdenarTriangulos();
   foreach(Triangulo t in triangulos)
   {
    t.Pintar(g,wireframe);
   }
  }
  
  public void Rotar(float rx, float ry, float rz)
  {
   foreach(Triangulo t in triangulos)
   {
    t.Rotar(rx,ry,rz,centro);
   }
  }

	private int Partition(int p, int r)
	{
		int i,j,k;
		Triangulo t;
		float x;
		//Randomized Partition
		k=rnd.Next(0,r-p);
		k+=p;
		t=triangulos[r];
		triangulos[r]=triangulos[k];
		triangulos[k]=t;
		/////////////
		x=triangulos[r].zi;
		i=p-1;
		for(j=p;j<r;j++)
		{
			if(triangulos[j].zi>x)
			{
				i++;
				t=triangulos[i];
				triangulos[i]=triangulos[j];
				triangulos[j]=t;
			}
		}
		i++;
		t=triangulos[i];
		triangulos[i]=triangulos[r];
		triangulos[r]=t;
		return i;
	}

	private void QuickS(int p, int r)
	{
		int q;
		if(p<r)
		{
			q=Partition(p,r);
			QuickS(p,q-1);
			QuickS(q+1,r);
		}
	}
		
  public void OrdenarTriangulos()
  {
	
	QuickS(0,triangulos.Count-1);
//   List<Triangulo> tmp=new List<Triangulo>();
//   int i;
//   
//   
//   foreach(Triangulo t in triangulos)
//   {
//    i=0;
//    foreach(Triangulo a in tmp)
//    {
//     if(t.zi>a.zi)
//      break;
//     i++;
//    } 
//    tmp.Insert(i,t);
//   }
//   triangulos=tmp;
  }

  public void Escalar(float ex, float ey, float ez)
  {
   foreach(Triangulo t in triangulos)
   {
    t.Escalar(ex,ey,ez,centro);
   }
  }
  
 }
}
