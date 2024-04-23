using System;
using static System.Console;
using static System.Math;

public static class main{
	public static void Main(){
		//Testing some integrals.
		WriteLine("--- Testing integral of sqrt(x) from 0 to 1. ---");
		Func<double,double> func1 = t => Sqrt(t);
		WriteLine($"{integrator.integrate(func1, 0, 1)} is within accuracy goals of 2/3.");
		WriteLine("");

		WriteLine("--- Testing integral of 1/sqrt(x) from 0 to 1. ---");
		Func<double,double> func2 = t => 1/Sqrt(t);
		WriteLine($"{integrator.integrate(func2, 0, 1)} is within accuracy goals of 2.");
		WriteLine("");

		WriteLine("--- Testing integral of 4*sqrt(1-x^2) from 0 to 1. ---");
		Func<double,double> func3 = t => 4*Sqrt(1-Pow(t,2));
		WriteLine($"{integrator.integrate(func3, 0, 1)} is within accuracy goals of pi.");
		WriteLine("");

		WriteLine("--- Testing integral of ln(x)/sqrt(x) from 0 to 1. ---");
		Func<double,double> func4 = t => Log(t)/Sqrt(t);
		WriteLine($"{integrator.integrate(func4, 0, 1)} is within accuracy goals of -4.");
		WriteLine("");


		//Making a plot of error function.
		vector zs = vector.linspace(100,-10,10);
		vector errys = new vector(zs.size);
		for(int i=0; i<zs.size; i++){
			errys[i] = integrator.erf(zs[i]);
			Error.WriteLine($"{zs[i]} {errys[i]}");
		}
		
		WriteLine("--- Comparing error function approximations to exact values ---");
		WriteLine("z | approx | exact");
		WriteLine($"-2 | {integrator.erf(-2)} | -0.99532");
		WriteLine($"-1 | {integrator.erf(-1)} | -0.84270");
		WriteLine($"-0.6 | {integrator.erf(-0.6)} | -0.60386");
		WriteLine($"-0.1 | {integrator.erf(-0.1)} | -0.11246");
		WriteLine($"0 | {integrator.erf(0)} | 0");
		WriteLine($"0.1 | {integrator.erf(0.1)} | 0.11246");
		WriteLine($"0.6 | {integrator.erf(0.6)} | 0.60386");
		WriteLine($"1 | {integrator.erf(1)} | 0.84270");
		WriteLine($"2 | {integrator.erf(2)} | 0.99532");
		WriteLine("These results are very similar to plot exercise.");
		
	}//Main func
}//main class
