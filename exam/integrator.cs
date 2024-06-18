//Version 18.06.2024 -- Exam

using System;
using static System.Math;

public static class integrator{
	public static double integrate2d(
	 Func<double, double, double> f, 
	 double a, double b,
	 Func<double,double> d,
	 Func<double,double> u,
	 double delta = 0.001,
	 double epsilon = 0.001){
		Func<double,double> g = x => {
			Func<double,double> fy = y => f(x,y);
			return integrate(fy, d(x), u(x), delta, epsilon);
		};
		double res = integrate(g, a, b, delta, epsilon);
		return res;
	}//integrate2d function


	//Integration rutine using the points and and weights that Dimitri used in his example.
	public static double integrate
	(Func<double,double> f, double a, double b, 
	double delta=0.001, double epsilon=0.001, double f2=Double.NaN, double f3=Double.NaN){
		double h = b-a;
		if(Double.IsNaN(f2) && Double.IsNaN(f3)){
			f2 = f(a+2*h/6);
			f3 = f(a+4*h/6);
		}
		double f1 = f(a+h/6);
		double f4 = f(a+5*h/6);
		double Q = (2*f1 + f2 + f3 + 2*f4)/6*h; //Multiplying with h=b-a to scale weights.
		double q = (f1 + f2 + f3 + f4)/4*h; //In the notes, this isn't times h, but it is in the example.
		double err = Abs(Q-q);
		if(err <= delta+epsilon*Abs(Q)){
			return Q;
		}
		else{
			//Note: a+(b-a)/2 = a+b/2-a/2 = a/2+b/2 = (a+b)/2.
			//Therefore, this splits the interval in two.
			return integrate(f,a,(a+b)/2,delta/Sqrt(2),epsilon,f1,f2) + 
				integrate(f,(a+b)/2,b,delta/Sqrt(2),epsilon,f3,f4);
		}
	}//integrate function

	public static double erf(double z){
		Func<double,double> func1 = t => Exp(-Pow(t,2));
		Func<double,double> func2 = t => Exp(-Pow((z+(1-t)/t),2))/t/t;
		if(z<0){return -erf(-z);}
		if(z>0 && z<1){return 2/Sqrt(PI)*integrate(func1,0,z);}
		else{return 1-2/Sqrt(PI)*integrate(func2,0,1);}
	}//error function
}//integrator class
