using System;
using static System.Console;
using static System.Math;

public static class main{
	public static void perform_mini(Func<vector,double> f, vector x0){
		WriteLine($"Initial guess, x0");
		x0.show();
		WriteLine("");

		WriteLine($"f(x0) = {f(x0)}.");
		WriteLine("");

		(vector x_mini, int loopcount) = mini.newton(f, x0);
		WriteLine($"Solution, x");
		x_mini.show();
		WriteLine("");

		WriteLine($"f(x) = {f(x_mini)}.");
		WriteLine("");

		WriteLine($"Loop count = {loopcount}.");
	}//perform_mini function

	public static void Main(){
		WriteLine("----- DEBUGGING -----");
		Func<vector,double> f_debug = x => 47*Pow(x[0],2) + 3*Exp(x[1]) + 7;
		WriteLine($"Debugging function is f(x) = 47*Pow(x[0],2) + 3*Exp(x[1]) + 7.");
		vector x0_debug = new vector(2);
			x0_debug[0] = 37;
			x0_debug[1] = -4;
		WriteLine("");
		
		perform_mini(f_debug, x0_debug);
		WriteLine("");


		WriteLine("----- ROSENBROCK'S VALLEY FUNCTION -----");
		Func<vector,double> f_rosen = x => Pow((1-x[0]),2) + 100*Pow((x[1]-Pow(x[0],2)),2);
		WriteLine($"Valley function is f(x) = Pow((1-x[0]),2) + 100*Pow((x[1]-Pow(x[0],2)),2).");
		vector x0_rosen = new vector(2);
			x0_rosen[0] = 45;
			x0_rosen[1] = 137;
		WriteLine("");

		perform_mini(f_rosen, x0_rosen);
		WriteLine("");


		WriteLine("----- HIMMELBLAU'S FUNCTION -----");
		Func<vector,double> f_himmel = x => Pow(Pow(x[0],2)+x[1]-11,2) + Pow(x[0]+Pow(x[1],2)-7,2);
		WriteLine($"Himmel function is f(x) = Pow(Pow(x[0],2)+x[1]-11,2) + Pow(x[0]+Pow(x[1],2)-7,2).");
		vector x0_himmel = new vector(2);
			x0_himmel[0] = 265;
			x0_himmel[1] = 47;
		WriteLine("");

		perform_mini(f_himmel, x0_himmel);


	}//Main function
}//main class
