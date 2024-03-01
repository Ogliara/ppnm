using System;

static class main{
	static int Main(){
		//proper testing of decomp
		Console.WriteLine("Properly testing decomp");
		matrix A = matrix.random(7,3);
		Console.WriteLine($"Matrix A");
		A.show();
		//decomp
		(matrix Q, matrix R) = QRGS.decomp(A);
		Console.WriteLine($"Matrix Q");
		Q.show();
		Console.WriteLine($"Matrix R");
		R.show();
		//QtQ=1
		matrix Qt = Q.transpose();
		Console.WriteLine($"Matrix Q transposed");		
		Qt.show();
		Console.WriteLine($"Matrix product QtQ");
		matrix QtQ = matrix.product(Qt,Q);
		QtQ.show();
		matrix id = matrix.identity(QtQ.amountrows);
		Console.WriteLine($"QtQ compared to identity = {matrix.compare(QtQ,id)}");
		Console.WriteLine();		
		//QR=A
		matrix QR = matrix.product(Q,R);
		Console.WriteLine($"Matrix product QR");		
		QR.show();
		Console.WriteLine($"QR compared to A = {matrix.compare(QR,A)}");
		Console.WriteLine();


		//proper testing of solve
		Console.WriteLine("Properly testing solve");
		int n = 5;
		A = matrix.random(n,n);
		Console.WriteLine("Matrix A");		
		A.show();
		vector b = vector.random(n);
		Console.WriteLine("Vector b");		
		b.show();
		Console.WriteLine("");
		(Q,R) = QRGS.decomp(A);
		vector x = QRGS.solve(Q,R,b);
		Console.WriteLine("Solutions vector x");
		x.show();
		Console.WriteLine("");
		vector Ax = matrix.product(A,x);
		Console.WriteLine("Vector Ax");
		Ax.show();
		Console.WriteLine("");
		Console.WriteLine($"Ax compared to b = {vector.compare(Ax,b)}");
		Console.WriteLine();

		//proper testing of det_tri
		Console.WriteLine("Properly testing det_tri");
		A = matrix.random(4,3);
		Console.WriteLine("Matrix A");		
		A.show();
		(Q,R) = QRGS.decomp(A);
		Console.WriteLine("Matrix R");		
		R.show();
		double detR = QRGS.det_tri(R);
		Console.WriteLine($"Determinant of R is {detR}");
		

		return 0;
	}//Main func
}//main class
