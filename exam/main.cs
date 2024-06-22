using System;
using System.Collections.Generic;
using static System.Math;
using static System.Console;

public static class main{
	public static void Main(){
		WriteLine("Hello, World!");
		int N = 100;
		vector times = vector.linspace(N, 0, 10);
		//vector ytest = vector.random(N,-10,10);
		vector ytest = new vector(N);
		for(int i=0; i<N; i++){
			ytest[i] = 10*Sin(times[i]);
		}
		vector ytest_uncut = ytest.copy();
		double cutoff = 7;
		List<int> mtestlist = new List<int>();
		for(int i=0; i<N; i++){
			if(Abs(ytest[i]) >= cutoff){
				ytest[i] = 0;
				mtestlist.Add(i);
			}
		}
		int[] mtest = mtestlist.ToArray();

		WriteLine("mtest");
		for(int i=0; i<mtest.Length; i++){
			WriteLine($"{mtest[i]}");
		}
		WriteLine();


		WriteLine("ytest");
		ytest.show();
		WriteLine();

		vector ztest = leastsquares.declipping(mtest,ytest);
		WriteLine("ztest");
		ztest.show();
		WriteLine();

		vector xtest = ytest.copy();
		for(int i=0; i<mtest.Length; i++){xtest[mtest[i]] = ztest[i];}
		WriteLine("xtest");
		xtest.show();
		WriteLine();

		//Calculating sum of squared error.
		vector diff = new vector(N);
		double sse = 0;
		for(int i=0; i<N; i++){
			sse += Pow(ytest_uncut[i] - xtest[i] , 2);
			diff[i] = ytest_uncut[i] - xtest[i];
		}
		double diffnormsq = diff.norm()*diff.norm();

		WriteLine($"Sum of squared error = {sse}.");
		WriteLine($"Squared norm of diff vector = {diffnormsq}.");
		WriteLine();

		//Writing out plot data to the standard error output.

		for(int i=0; i<ytest.size; i++){
			Error.WriteLine($"{times[i]} {ytest[i]} {xtest[i]}");
		}
		
	}//Main function.
}//main class.
