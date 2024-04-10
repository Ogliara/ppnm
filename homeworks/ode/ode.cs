using System;
using System.Collections.Generic;
using static System.Math;

public static class ode{
	//Following midpoint euler method using Butcher tableaux and formulae on page 6 in notes.
	public static (vector, vector) rkstep12(Func<double,vector,vector> f, double x, vector y, double h){
		vector k0 = f(x,y);
		vector k1 = f(x+h/2,y+k0*h/2);
		vector yh = y + k1*h;
		vector dy = (k1-k0)*h;
		return (yh,dy);
	}

	//Driver must calculate the next step size h by comparing the error to accuracy.
	//It must log the previous step sizes in a vector.
	//It must repeatedly call the stepper until it reaches the required value.
	public static (List<double>, List<vector>) driver(
		Func<double,vector,vector> f, 
		(double, double) interval,
		vector ystart,
		double h = 0.125,
		double abs_acc = 0.01,
		double rel_acc = 0.01
	){
		var (a,b) = interval;
		double x = a;
		vector y = ystart.copy();
		var xlog = new List<double>(); xlog.Add(x);
		var ylog = new List<vector>(); ylog.Add(y);

		do{
			if(x >= b) return (xlog, ylog);
			if(x+h > b) h = b-x;
			(vector yh, vector dy) = rkstep12(f,x,y,h);
			double tol = (rel_acc*yh.norm() + abs_acc)*Sqrt(h/(b-a));
			double err = dy.norm();
			//Accept criteria.
			if(tol>err){
				x = x+h; xlog.Add(x);
				y = yh; ylog.Add(y);
			}
			//Accept or reject, h is adjusted and the new step is taken.
			//Using the Min here to either adjust according to tol/err or just by times 2,
			//depending on if step was rejected or not. This prevents an accidental massive step.
			h = h*Min(Pow(tol/err,0.25)*0.95 , 2);
		}while(true);

	}
}
