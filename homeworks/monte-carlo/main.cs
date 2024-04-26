using System;
using static System.Console;
using static System.Math;
public static class main{
	public static void Main(){
		//Unit circle in cartesian coordinates.
		Func<vector,double> f_uc = x => Sqrt(x[0]*x[0] + x[1]*x[1]);

		vector a_uc = new vector(2);
		a_uc[0] = -1; a_uc[1] = -1;

		vector b_uc = new vector(2);
		b_uc[0] = 1; b_uc[1] = 1;

		int N_uc = 10000;

		(double val_uc, double err_uc) = montecarlo.plain(f_uc, a_uc, b_uc, N_uc);
		
		WriteLine($"Value of integral of unit circle = {val_uc} +/- {err_uc} when N = {N_uc}.");
		
		WriteLine("Looking at the plot, the actual error doesn't go as 1/sqrt(N), but it does converge towards a value - 0.08 in this case.");

		
		WriteLine("----- Calculating Long Integral -----");
		Func<vector,double> f_long = x => Pow(1/PI,3) * Pow( 1-Cos(x[0])*Cos(x[1])*Cos(x[2]) , -1 );

		vector a_long = new vector(3);
		vector b_long = new vector(3);
		for(int i=0; i<a_long.size; i++){
			a_long[i] = 0;
			b_long[i] = PI;
		}
		int N_long = 10000;

		(double val_long, double err_long) = montecarlo.plain(f_long, a_long, b_long, N_long);

		WriteLine($"Value of long integral = {val_long} +/- {err_long} when N = {N_long}.");

		

		//Plotdata.
		for(int N=100; N<10000001; N*=10){
			(val_uc, err_uc) = montecarlo.plain(f_uc, a_uc, b_uc, N);
			Error.WriteLine($"{N} {err_uc} {Abs(PI - val_uc)}");
		}

	}//Main func
}//main class
