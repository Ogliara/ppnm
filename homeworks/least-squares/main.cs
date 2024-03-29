using System;
using static System.Console;

static class main{
	static int Main(string[] args){
		string infile = null;
		string outfile = null;
		foreach(var arg in args){
			var words = arg.Split(':');
			if(words[0] == "-input") infile=words[1];
			if(words[0] == "-output") outfile=words[1];
		}


		var instream = new System.IO.StreamReader(infile);
		var outstream = new System.IO.StreamWriter(outfile, append:true);

		vector x = new vector(0);
		vector y = new vector(0);
		vector yerr = new vector(0);
		for(string line=instream.ReadLine(); line!=null; line=instream.ReadLine()){
			var numbers = line.Split('\t');
			x.append(double.Parse(numbers[0]));
			y.append(double.Parse(numbers[1]));
			yerr.append(double.Parse(numbers[2]));

		}

		WriteLine("----------     Loading Data     ----------");
		WriteLine("x starts here");
		x.show();
		WriteLine("y starts here");
		y.show();
		WriteLine("yerr starts here");
		yerr.show();
		


		WriteLine();
		WriteLine("----------     Testing QR on tall matrix     ----------");
		matrix A = matrix.random(4,2);
		WriteLine("Matrix A");
		A.show();
		(matrix Q, matrix R) = QRGS.decomp(A);
		WriteLine("Matrix Q");
		Q.show();
		WriteLine("Matrix R");
		R.show();
		WriteLine($"Does QtQ=I? {matrix.compare(Q.transpose()*Q,matrix.identity(Q.amountcols))}");
		vector btest = vector.random(A.amountrows);
		WriteLine("Vector btest");
		btest.show();
		vector solved = QRGS.solve(Q,R,btest);
		WriteLine("Vector of solutions for system Rx=Qtb");
		solved.show();
		

		WriteLine();
		WriteLine("----------     Performing lsfit     ----------");
		//Log functions, log ys, log yerrs
		var lnfs = new System.Func<double,double>[] { t => 1.0, t => t };
		vector lnys = new vector(y.size);
		vector lnyerrs = new vector(yerr.size);
		for(int i=0; i<lnys.size; i++){
			lnys[i]=Math.Log(y[i]);
			lnyerrs[i] = Math.Abs(yerr[i]/y[i]);
		}
		(vector c, matrix sigma) = leastsquares.lsfit(lnfs,x,lnys,lnyerrs);
		WriteLine("Vector c for logarithmic fit (ln(a), -lambda)");
		c.show();
		WriteLine();
		WriteLine("Covariance matrix sigma for logarithmic fit");
		sigma.show();
		WriteLine();

		WriteLine("Actual ln(y) and fitted ln(y) values");
		vector fitlnys = new vector(lnys.size);
		for(int i=0; i<fitlnys.size; i++){
			fitlnys[i] = c[0]*lnfs[0](x[i]) + c[1]*lnfs[1](x[i]);
			WriteLine($"{lnys[i]} +/- {lnyerrs[i]}, {fitlnys[i]}");
		}
		WriteLine();

		//Calculating the half-life from fit
		double lambda = c[1];
		double lambda_err = Math.Sqrt(sigma[1,1]);
		double halflife = Math.Log(2d)/(-c[1]);
		double halflife_err = halflife*Math.Abs(lambda_err/lambda);
		WriteLine($"Fitted half-life of ThX is found to be {halflife}+/-{halflife_err} days");
		WriteLine("Modern value of the half-life is 3.631(2) days (source is National Institute of Health)");
		WriteLine($"The fitted value over-estimates the half-life by {halflife-halflife_err-3.631} days");
		
		
		//Sending plotting values to the proper file via outstream
		for(int i=0; i<x.size; i++){
			outstream.WriteLine($"{x[i]} {lnys[i]} {lnyerrs[i]} {fitlnys[i]}");
		}


		instream.Close();
		outstream.Close();
		return 0;
	}

}
