﻿// See https://aka.ms/new-console-template for more information

using StructuralVisualizerCS;

Point p = new Point(2.0, 2.0);
Point q = new Point(1.5, 1.5);
Console.WriteLine(p.DistanceTo(p, q));

Vector v = new Vector(3.0, 3.0);
Vector u = new Vector(1.5, 2.0);
Console.WriteLine(v.IsNormal);
Console.WriteLine(v.Norm);
Console.WriteLine(new Vector().Dot(v,u));
Console.WriteLine(v);
