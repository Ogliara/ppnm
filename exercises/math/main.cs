using System;
using System.Numerics;
using static System.Console;


class math{
	double times2(double y){
		double z=7;
		return y*z;
	} 
	


	static void Main(){
		double x =(3d/2d) * Math.PI;
		double sinx = Math.Sin(x);
		double abs_sinx = Math.Abs(sinx);
		System.Console.Write("Hi, sin to {0} is {1}, and the absolute value of {1} is {2}.\n", 
			x, sinx, abs_sinx);
		Write($"x={x}\n");  //Using the dollar-sign to denote string. Thus, we don't need references.
		

		//Using the special functions library.
		for(int i=1; i<10; i+=1){
			Write($"fgamma({i})={sfunc.fgamma(i)}\n");
		}		



		//For some reason, this doesn't work. Something about missing an 'assembly reference'?
		//A future exercise has the reference in it. Will look at it later.
		//Complex complex1 = new Complex(17, 18);
		//System.Console.Write("{0}\n",complex1);
	}
}
