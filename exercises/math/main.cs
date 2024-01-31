using System;

class math{
	static void Main(){
		double x =(3d/2d) * Math.PI;
		double sinx = Math.Sin(x);
		double abs_sinx = Math.Abs(sinx);
		System.Console.Write("Hi, sin to {0} is {1}, and the absolute value of {1} is {2}.\n", x, sinx, abs_sinx);
	}
}
