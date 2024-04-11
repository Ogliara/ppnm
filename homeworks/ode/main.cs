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

	static vector osc_f(double x,vector y){
		double b = 0.25;
		double c = 5.0;
		vector z = new vector(y.size);
		z[0] = y[1];
		z[1] = -b*y[1] - c*Math.Sin(y[0]);
		return z;
	}

	static vector lokvol_f(double x,vector y){
		double a = 1.5;
		double b = 1;
		double c = 3;
		double d = 1;
		vector z = new vector(y.size);
		z[0] = a*y[0] - b*y[0]*y[1];
		z[1] = d*y[0]*y[1] - c*y[1];
		return z;
	}
	static void Main(string[] args){
		//Setting up some output streams so we can send plot data to different files
		var outfiles = new List<string>();
		foreach(var arg in args){
			var words = arg.Split(':');
			if(words[0] == "-output"){
				string filename = words[1].ToString();
				outfiles.Add(filename);
			}
		}
		foreach(string outfile in outfiles){
			WriteLine(outfile);
		}
		//With these files set up, we can then open streams when needed to write out results.



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



		//Oscillator system.
		var osc_interval = (0,10);
		vector osc_ystart = new vector(2);
		osc_ystart[0] = Math.PI - 0.1;
		osc_ystart[1] = 0;
		(List<double> osc_xlog, List<vector> osc_ylog) = ode.driver(osc_f, osc_interval, osc_ystart);
		var osc_outstream = new System.IO.StreamWriter(outfiles[0], append:true);
		for(int i=0; i<osc_xlog.Count; i++){
			osc_outstream.WriteLine($"{osc_xlog[i]} {osc_ylog[i][0]} {osc_ylog[i][1]}");
		}
		osc_outstream.Close();

		//Lotka-Volterra system.
		var lokvol_interval = (0,15);
		vector lokvol_ystart = new vector(2);
		lokvol_ystart[0] = 10;
		lokvol_ystart[1] = 5;
		(List<double> lokvol_xlog, List<vector> lokvol_ylog) = ode.driver(lokvol_f, lokvol_interval, lokvol_ystart);
		var lokvol_outstream = new System.IO.StreamWriter(outfiles[1], append:true);
		for(int i=0; i<lokvol_xlog.Count; i++){
			lokvol_outstream.WriteLine($"{lokvol_xlog[i]} {lokvol_ylog[i][0]} {lokvol_ylog[i][1]}");
		}
		lokvol_outstream.Close();

	}//Main function
}//main class
