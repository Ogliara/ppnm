using System;
using static System.Console;
using static System.Math;

public static class main{
	public static void Main(){
		WriteLine("----- DEBUGGING, 1 DIMENSION -----");
		var fs_debug = new Func<vector,double>[] {x => x[0]*2 + 7};
		vector x0s_debug = new vector(1); x0s_debug[0] = 1;
		WriteLine($"fs_debug[0](x0s_debug) = {fs_debug[0](x0s_debug)}.");
		vector root_debug = roots.newton(fs_debug, x0s_debug);
		WriteLine($"Debugging root = {root_debug[0]}. fs_debug[0](root) = {fs_debug[0](root_debug)}.");
		WriteLine("");
		
		WriteLine("----- DEBUGGING, 2 DIMENSIONS -----");
		var fs_debug2 = new Func<vector,double>[] {x => x[0]*2 + 7, x => x[0]*x[0] + x[1]*6 + 3};
		vector x0s_debug2 = new vector(2); 
			x0s_debug2[0] = -4;
			x0s_debug2[1] = -3;
		WriteLine($"fs_debug2[0](x0s_debug2) = {fs_debug2[0](x0s_debug2)}.");
		WriteLine($"fs_debug[1](x0s_debug2) = {fs_debug2[1](x0s_debug2)}.");
		vector root_debug2 = roots.newton(fs_debug2, x0s_debug2);
		WriteLine($"Debugging root2 = ({root_debug2[0]},{root_debug2[1]}).");
		WriteLine($"fs_debug2[0](root2) = {fs_debug2[0](root_debug2)}.");
		WriteLine($"fs_debug2[1](root2) = {fs_debug2[1](root_debug2)}.");
		WriteLine("");

		

		WriteLine($"----- Rosenbrock's Valley Function -----");
		var fs_rb = new Func<vector,double>[] {
			x => 2*x[0] - 2 + 400*(Pow(x[0],3) - x[1]*x[0]), 
			x => 200*(x[1] - Pow(x[0],2))
			};
		WriteLine("Gradient is 2*x[0] - 2 + 400*(Pow(x[0],3) - x[1]*x[0]) and 200*(x[1] - Pow(x[0],2)).");
		vector x0s_rb = new vector(2); 
			x0s_rb[0] = 1.5;
			x0s_rb[1] = 1.5;
		WriteLine("Initial Guess");
		x0s_rb.show();
		WriteLine($"fs_rb[0](x0s_rb) = {fs_rb[0](x0s_rb)}.");
		WriteLine($"fs_rb[1](x0s_rb) = {fs_rb[1](x0s_rb)}.");
		vector root_rb = roots.newton(fs_rb, x0s_rb);
		WriteLine($"Rosenbrock root = ({root_rb[0]},{root_rb[1]}).");
		WriteLine($"fs_rb[0](root_rb) = {fs_rb[0](root_rb)}.");
		WriteLine($"fs_rb[1](root_rb) = {fs_rb[1](root_rb)}.");
		WriteLine($"Root found at {root_rb[0]},{root_rb[1]}.");
		WriteLine("");



		WriteLine($"----- Himmelblau's Function -----");
		var fs_hb = new Func<vector,double>[] {
			x => 4*(Pow(x[0],3) + x[0]*x[1] - 11) + 2*(x[0] + Pow(x[1],2) - 7), 
			x => 2*(Pow(x[0],2) + x[1] - 11) + 4*x[1]*(x[0] + Pow(x[1],2) - 7)
			};
		WriteLine("Gradient is 4*(Pow(x[0],3) + x[0]*x[1] - 11) + 2*(x[0] + Pow(x[1],2) - 7) and 2*(Pow(x[0],2) + x[1] - 11) + 4*x[1]*(x[0] + Pow(x[1],2) - 7).");
		vector x0s_hb = new vector(2); 
			x0s_hb[0] = 2;
			x0s_hb[1] = 3;
		WriteLine("Initial Guess");
		x0s_hb.show();
		WriteLine($"fs_hb[0](x0s_hb) = {fs_hb[0](x0s_hb)}.");
		WriteLine($"fs_hb[1](x0s_hb) = {fs_hb[1](x0s_hb)}.");
		vector root_hb = roots.newton(fs_hb, x0s_hb);
		WriteLine($"Himmelblau root = ({root_hb[0]},{root_hb[1]}).");
		WriteLine($"fs_hb[0](root_hb) = {fs_hb[0](root_hb)}.");
		WriteLine($"fs_hb[1](root_hb) = {fs_hb[1](root_hb)}.");
		WriteLine($"Root found at {root_hb[0]},{root_hb[1]}.");



	}//Main class
}//main func
