Movil3D
=======

Very simple software rasterizer for 3D objects written in C#. This library renders to a **System.Drawing.Graphics** object passed as parameter to the 'Pintar' (Draw) method.

###Build

Simply open the solution in visual studio and build the application, it can be either compiled as a DLL o as a standalone EXE. It targets .NET Framework 2.0 but can be upgraded to 4.5 without any modifications.

###Characteristics

Can render solid objects and wireframes. Has a buuilt-in visualizer that allows zoom and rotation of objects.

Primivites:
* Cube
* Torus
* Sphere
* Cone
* Box
* Cylinder
* Mesh. Used to load 3D object in the [MilkShape3D](http://www.milkshape3d.com/) (ms3d) format.

###Screenshot
![Screenshot](https://raw.githubusercontent.com/niofis/Movil3D/master/screenshot.png)


This project was written back in 2008.

Enrique CR.


