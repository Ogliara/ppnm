using System;
using static System.Console;
public static class main{
	public static void Main(){
		//Part a) Linear Splines
		WriteLine("----- Linear Splines -----");
		vector x = new vector(10);
		vector y = new vector(x.size);
		WriteLine("x  y");
		for(int i=0; i<x.size; i++){
			x[i] = i;
			y[i] = Math.Cos(x[i]);
			WriteLine($"{x[i]}  {y[i]}");
		}
		double z = 1.4;
		int inter = linsplin.binsearch(x,z);
		WriteLine();
		WriteLine($"z={z} -> i={inter} through binary search through x");
	}
}
