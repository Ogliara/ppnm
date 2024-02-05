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
		
		//Tasks:
		Write("Tasks:\n");
		double sqrt2 = Math.Sqrt(2.0);
		Write($"sqrt2 = {sqrt2}, and sqrt2*sqrt2 = {sqrt2 * sqrt2}\n");

		double twopower = Math.Pow(2.0, 1d/5d);
		Write($"2^1/5 = {twopower} and (2^1/5)^5 = {Math.Pow(twopower, 5.0)}\n");

		double etopi = Math.Exp(Math.PI);
		Write($"e^pi = {etopi} and ln(e^pi) = {Math.Log(etopi)}\n");
		
		double pitoe = Math.Pow(Math.PI, Math.Exp(1));
		Write($"pi^e = {pitoe} and ln(pi^e) = {Math.Log(pitoe, Math.PI)}\n");





		//Using the special functions library, sfunc
		int fact = 1;
		for(int i=1; i<10; i+=1){
			Write($"fgamma({i}) = {sfunc.fgamma(i)} and ({i}-1)! = {fact}\n");
			fact = fact*i;
			Write($"lngamma({i}) = {sfunc.lngamma(i)} and exp(lngamma({i})) = {Math.Exp(sfunc.lngamma(i))}\n");
			Write("\n");
		}		



		//For some reason, this doesn't work. Something about missing an 'assembly reference'?
		//A future exercise has the reference in it. Will look at it later.
		//Complex complex1 = new Complex(17, 18);
		//System.Console.Write("{0}\n",complex1);
	}
}
