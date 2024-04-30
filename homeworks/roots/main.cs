using System;
using static System.Console;

public static class main{
	public static void Main(){
		WriteLine("----- DEBUGGING, 1 DIMENSION -----");
		var fs_debug = new Func<vector,double>[] {x => x[0]*2 + 7};
		vector x0s_debug = new vector(1); x0s_debug[0] = 1;
		WriteLine($"fs_debug[0](x0s_debug) = {fs_debug[0](x0s_debug)}.");
		vector root_debug = roots.newton(fs_debug, x0s_debug);
		WriteLine($"Debugging root = {root_debug[0]}. fs_debug[0](root) = {fs_debug[0](root_debug)}.");
		
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


	}//Main class
}//main func
