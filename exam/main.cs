using System;
using static System.Math;
using static System.Console;

public static class main{
	public static void Main(){
		//Testing the 2D integrator with a known function.
		Func<double,double,double> f = (x,y) => 2*x + y*y;
		WriteLine($"f(3,5) = {f(3,5)}.");
		Func<double,double> d = x => x;
		Func<double,double> u = x => 2*x;
		double a = 2; double b = 5;
		WriteLine($"Analytic answer = {2*(5*5*5-2*2*2)/3  +  7*(5*5*5*5-2*2*2*2)/12}.");
		double numres = integrator.integrate2d(f, a, b, d, u);
		WriteLine($"Numerical answer = {numres}.");
	}//Main function.
}//main class.
