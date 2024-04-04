using System;
using static System.Console;
public static class main{
	public static void Main(){
	//Part a) Linear Splines
		WriteLine("----- Linear Splines -----");
		vector x = new vector(10);
		vector y = new vector(x.size);
		WriteLine("x  y");
		for(int i=0; i<x.size; i++){
			x[i] = i;
			y[i] = Math.Cos(x[i]);
			WriteLine($"{x[i]}  {y[i]}");
		}

		linspline spline_lin = new linspline(x,y);
		quadspline spline_quad = new quadspline(x,y);

		for(int i=0; i<x.size; i++){
			Error.Write($"{x[i]} {y[i]} {spline_lin.zs[i]} {spline_lin.linterp_ys[i]} {spline_lin.integ_ys[i]} ");
			Error.Write($"{spline_quad.quadterp_ys[i]}, {spline_quad.derived_ys[i]}, {spline_quad.integral_ys[i]}");
			Error.WriteLine("");
		}
		for(int i=x.size; i<spline_lin.zs.size; i++){
			Error.Write($"NULL NULL {spline_lin.zs[i]} {spline_lin.linterp_ys[i]} {spline_lin.integ_ys[i]} ");
			Error.Write($"{spline_quad.quadterp_ys[i]}, {spline_quad.derived_ys[i]}, {spline_quad.integral_ys[i]}");
			Error.WriteLine("");
		}
	}
}


