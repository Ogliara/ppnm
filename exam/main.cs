using System;
using System.Collections.Generic;
using static System.Math;
using static System.Console;

public static class main{
	public static void Main(){
		int N = 100;
		vector times = vector.linspace(N, 0, 30); //Generating a vector of equally spaced time values.
		vector ytest = new vector(N); //Making a y-vector from those time values.
		for(int i=0; i<N; i++){
			ytest[i] = 2*Sin(times[i]) + 3*Cos(times[i]); //This seems like an appropriate function.
		}
		vector ytest_uncut = ytest.copy(); //Saving the original signal before clipping it.
		double cutoff = 2;
		List<int> mtestlist = new List<int>();
		for(int i=0; i<N; i++){
			if(Abs(ytest[i]) >= cutoff){
				ytest[i] = 0; //Setting all y-values that are outside the cutoff to zero.
				mtestlist.Add(i); //Adding the appropriate indicies to the m-array.
			}
		}
		int[] mtest = mtestlist.ToArray();

		//Displaying m-array.
		WriteLine("mtest");
		for(int i=0; i<mtest.Length; i++){
			WriteLine($"{mtest[i]}");
		}
		WriteLine();

		//Displaying y-vector.
		WriteLine("ytest");
		ytest.show();
		WriteLine();

		//Applying declipping routine and displaying z-vector.
		vector ztest = leastsquares.declipping(mtest,ytest);
		WriteLine("ztest");
		ztest.show();
		WriteLine();

		//Making x-vector by inserting z into y, then displaying x.
		vector xtest = ytest.copy();
		for(int i=0; i<mtest.Length; i++){xtest[mtest[i]] = ztest[i];}
		WriteLine("xtest");
		xtest.show();
		WriteLine();

		//Calculating sum of squared error. This is one way of gauging the accuracy of the routine.
		double sse = 0;
		for(int i=0; i<N; i++){
			sse += Pow(ytest_uncut[i] - xtest[i] , 2);
		}
		WriteLine($"Sum of squared error = {sse}.");

		//Writing out plot data to the standard error output.
		for(int i=0; i<N; i++){
			Error.WriteLine($"{times[i]} {ytest[i]} {xtest[i]} {ytest_uncut[i]}");
		}		
	}//Main function.
}//main class.
