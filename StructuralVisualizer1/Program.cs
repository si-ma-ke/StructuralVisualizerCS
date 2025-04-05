// See https://aka.ms/new-console-template for more information

using System;
using StructuralVisualizer1;

Point p = new Point(2.0, 2.0);
Point q = new Point(1.5, 1.5);
Console.WriteLine(p.DistanceTo(p, q));

Vector v = new Vector(3.0, 3.0);
Vector u = new Vector(1.5, 2.0);
Console.WriteLine(v.IsNormal);
Console.WriteLine(v.Norm);
Console.WriteLine(new Vector().Dot(v,u));
Console.WriteLine(v);

new TParam().EnsureValid(1);

Segment newSeg = new Segment(new Point(100,100),new Point(100,100));
Console.WriteLine(newSeg);

