using System;
using static System.Console;

static class main{
	static int Main(string[] args){
		string infile = null; string outfile = null;
		foreach(var arg in args){
			var words = arg.Split(':');
			if(words[0] == "-input") infile=words[1];
			if(words[0] == "-output") outfile=words[1];
		}

		if(infile==null || outfile==null){
			WriteLine("Wrong filename argument");
			return 1;
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

			/*
			foreach(var number in numbers){
				string elementstring = number.ToString();
				double element = double.Parse(elementstring);
				x.append(element);
			}
			*/
		}
		WriteLine("x starts here");
		x.show();
		WriteLine("y starts here");
		y.show();
		WriteLine("yerr starts here");
		yerr.show();
		

		instream.Close();
		outstream.Close();


		WriteLine();		
		var fs = new System.Func<double,double>[] { z => 1.0, z => z, z => z*z };
		for(int i=0; i<3; i++){WriteLine(fs[i](3));}

		matrix A = matrix.random(4,2);
		WriteLine("Matrix A");
		A.show();
		(matrix Q, matrix R) = QRGS.decomp(A);
		WriteLine("Matrix Q");
		Q.show();
		WriteLine("Matrix R");
		R.show();
		WriteLine($"Does QtQ=I? {matrix.compare(Q.transpose()*Q,matrix.identity(Q.amountcols))}");
		
		return 0;
	}

}
