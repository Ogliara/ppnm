using System;
using System.Collections.Generic;
using static System.Console;
static class main{
	static vector f(double x,vector y){
		vector z = new vector(y.size);
		z[0] = y[1];
		z[1] = -y[0];
		return z;
	}
	static void Main(){
		//Debugging using u''=-u.
		//Rewrite as (y'1=y2 , y'2=-y1).
		var interval = (0,2*Math.PI);
		vector ystart = new vector(2);
		ystart[0] = 1;
		ystart[1] = 0;

		(List<double> xlog, List<vector> ylog) = ode.driver(f, interval, ystart);
		WriteLine($"x10 = {xlog[10]}, y10 = ({ylog[10][0]},{ylog[10][1]})");
		for(int i=0; i<xlog.Count; i++){
			Error.WriteLine($"{xlog[i]} {ylog[i][0]} {ylog[i][1]}");
		}
	}//Main function
}//main class
