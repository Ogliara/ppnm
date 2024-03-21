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
		double z = 9;
		int inter = linspline.binsearch(x,z);
		WriteLine();
		WriteLine($"z={z} -> i={inter} through binary search through x");
		
		linspline testspline = new linspline(x,y);
		WriteLine(testspline.integ(Math.PI/2d));
		testspline.linterp_ys.show();
		for(int i=0; i<x.size; i++){
			Error.WriteLine($"{x[i]} {y[i]} {testspline.zs[i]} {testspline.linterp_ys[i]} {testspline.integ_ys[i]}");
		}
		for(int i=x.size; i<testspline.zs.size; i++){
			Error.WriteLine($"NULL NULL {testspline.zs[i]} {testspline.linterp_ys[i]} {testspline.integ_ys[i]}");
		}
	}
}


