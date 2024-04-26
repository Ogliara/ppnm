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
		
		WriteLine($"Value of integral of unit circle via plain = {val_uc} +/- {err_uc} when N = {N_uc}.");
		
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

		
		WriteLine("----- Part b) -----");
		double test = 7.5;
		WriteLine($"test = {test}, test modulo 2 = {test % 2}");
		WriteLine($"Base 10 Corput of 6 = {montecarlo.corput(6,10)}");
		WriteLine($"Base 100 Corput of 6 = {montecarlo.corput(6,100)}");
		WriteLine($"Base 6 Corput of 6 = {montecarlo.corput(6,6)}");

		vector xstest = new vector(2);
		vector xstest2 = new vector(2);
		for(int i=0; i<100; i++){
			montecarlo.halton(i,2,xstest);
			montecarlo.additive(i,2,xstest2);
			WriteLine($"{xstest[0]} {xstest[1]} {xstest2[0]} {xstest2[1]}");
		}
				
		(double val_uc2, double err_uc2) = montecarlo.lowdis(f_uc, a_uc, b_uc, N_uc);
		
		WriteLine($"Value of integral of unit circle via lowdis = {val_uc2} +/- {err_uc2} when N = {N_uc}.");


		//Plotdata.
		for(int N=100; N<10000001; N*=10){
			(val_uc, err_uc) = montecarlo.plain(f_uc, a_uc, b_uc, N);
			(val_uc2, err_uc2) = montecarlo.plain(f_uc, a_uc, b_uc, N);
			Error.WriteLine($"{N} {err_uc} {Abs(PI - val_uc)} {err_uc2}");
		}

	}//Main func
}//main class
