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
using System.IO;
using Movil3D;
using System.Windows.Forms;
using MilkShape3D;

namespace Movil3D
{
 public class Mesh : Objeto3D
 {
  private ArrayList vertices;
  private string gstr;
  private int line_count;
  private int mesh_count;
  
  public Mesh(Vector centro)
  {
   triangulos=new ArrayList();
   vertices=new ArrayList();
   this.centro=centro;
  }
  
  public void Cargar(string archivo)
  {
   CMS3DFile ms3dfile=new CMS3DFile();
   ms3dfile.LoadFromFile(archivo);
   Triangulo tr;

   	ms3d_triangle_t ms3dtriangle = new ms3d_triangle_t();
  	ms3d_vertex_t ms3dvertex0=new ms3d_vertex_t();
   	ms3d_vertex_t ms3dvertex1=new ms3d_vertex_t();
  	ms3d_vertex_t ms3dvertex2=new ms3d_vertex_t();
  	ms3d_group_t ms3dgroup=new ms3d_group_t();
  	ms3d_material_t ms3dmaterial=new ms3d_material_t();
	
	int i,j;
	j=ms3dfile.GetNumTriangles();
	
	for(i=0;i<j;i++)
	{
		ms3dfile.GetTriangleAt(i,ref ms3dtriangle);
		ms3dfile.GetVertexAt(ms3dtriangle.vertexIndices[0],ref ms3dvertex0);
		ms3dfile.GetVertexAt(ms3dtriangle.vertexIndices[1],ref ms3dvertex1);
		ms3dfile.GetVertexAt(ms3dtriangle.vertexIndices[2],ref ms3dvertex2);

		ms3dfile.GetGroupAt(ms3dtriangle.groupIndex,ref ms3dgroup);
		ms3dfile.GetMaterialAt(ms3dgroup.materialIndex,ref ms3dmaterial);

		tr=new Triangulo(
			new Vector(ms3dvertex0.vertex[0],ms3dvertex0.vertex[1],-ms3dvertex0.vertex[2]),
			new Vector(ms3dvertex2.vertex[0],ms3dvertex2.vertex[1],-ms3dvertex2.vertex[2]),
			new Vector(ms3dvertex1.vertex[0],ms3dvertex1.vertex[1],-ms3dvertex1.vertex[2]),
			Color.FromArgb((int)(ms3dmaterial.diffuse[0]*255),(int)(ms3dmaterial.diffuse[1]*255),(int)(ms3dmaterial.diffuse[2]*255)),ms3dgroup.name);
		
		triangulos.Add(tr);

	}
		ms3dfile.Clear();
	}   
  
  private int ProcessLine(string line, int status)
  {
   int i,j,k;
   float tx,ty,tz;
   Triangulo tr;
   
   
   string str=line;
   string tstr="";
   string[] str_arr;
   
   if(str.CompareTo("")==0)
    return status;
   
   switch(status)
   {
    case 1:
    if(str.CompareTo("// MilkShape 3D ASCII")==0)
    {
     status=2;
    }
    else
     status=0;
    break;
    case 2: // total frames
    i=str.IndexOf(":");
    tstr=str.Substring(0,i);
    if(tstr.CompareTo("Frames")==0)
    {
     status=3;
    }
    else
     status=0;
    break;
    case 3: // frame number
    i=str.IndexOf(":");
    tstr=str.Substring(0,i);
    if(tstr.CompareTo("Frame")==0)
    {
     status=4;
    }
    else
     status=0;
    break;
    case 4: //Meshes
    i=str.IndexOf(":");
    tstr=str.Substring(0,i);
    
    if(tstr.CompareTo("Meshes")==0)
    {
     str+=" ";
     i=str.IndexOf(": ")+2;
     j=str.IndexOf(" ",i);
     tstr=str.Substring(i,j-i);
     mesh_count=Int32.Parse(tstr);
     status=5;
    }
    else
     status=0;
    break;
    case 5: //"Meshname" 0 0
    if(mesh_count==0)
    {
     status=0;
     status=ProcessLine(str,status);
     break;
     //return 2; //Terminado
    }
    i=str.IndexOf("\"")+1;
    j=str.IndexOf("\"",i);
    gstr=str.Substring(i,j-i);
    status=6;
    mesh_count--;
    break;
    case 6: //vertice count
    line_count=Int32.Parse(str);
    status=7;
    vertices.Clear();
    
    break;
    case 7: //guarda los vertices marcados
    if(line_count==0)
    {
     status=8;
     status=ProcessLine(str,status);
     break;
    }
    str_arr=str.Split(' ');
    
    tx=Single.Parse(str_arr[1])+centro.x;
    ty=-Single.Parse(str_arr[2])+centro.y;
    tz=-Single.Parse(str_arr[3])+centro.z;
    
    vertices.Add(new Vertex(tx,ty,tz));
    
    line_count--;
    break;
    case 8: //lee la cantidad de normales
    line_count=Int32.Parse(str);
    status=9;
    break;
    case 9: //ignoramos las normales
    if(line_count==0)
    {
     status=10;
     status=ProcessLine(str,status);
     break;
    }
    line_count--;
    
    break;
    case 10: //lee la cantidad de triangulos
    line_count=Int32.Parse(str);
    status=11;
    break;
    case 11:
    if(line_count==0)
    {
     status=5;
     status=ProcessLine(str,status);
     break;
    }
    str_arr=str.Split(' ');
    
    i=Int32.Parse(str_arr[1]);
    j=Int32.Parse(str_arr[2]);
    k=Int32.Parse(str_arr[3]);
    
    tr=new Triangulo((Vertex)vertices[i],(Vertex)vertices[k],(Vertex)vertices[j],Color.Blue,gstr);
    triangulos.Add(tr);
    
    line_count--;
    break;
   }
   
   return status;
  }
 }
}
