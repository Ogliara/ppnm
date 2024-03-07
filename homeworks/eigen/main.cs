using System;
using static System.Console;

public static class main{
	public static void Main(){
		WriteLine("Make random symmetrical matrix A");
		int n = 3;
		matrix A = matrix.random(n,n);
		for(int i=0; i<A.amountrows; i++){
			for(int j=0; j<A.amountcols; j++){
				A[i,j] = A[j,i];
			}
		}
		WriteLine("Matrix A");
		A.show();
		matrix D = A.copy();
		WriteLine("-----");

		WriteLine("Apply Jacobi rotations cyclically to get matrix V with eigenvector cols");
		matrix V = jacobi.cyclical(D);
		WriteLine("Matrix V");
		V.show();
		WriteLine("Matrix D, which is A diagonalized");
		D.show();
		WriteLine("-----");
		
		matrix VtAV = V.transpose()*A*V;
		WriteLine("Matrix V^t*A*V");
		VtAV.show();
		WriteLine($"Is V^t*A*V==D? {matrix.compare(VtAV,D)}");
		WriteLine("-----");
		
		matrix VDVt = V*D*V.transpose();
		WriteLine("Matrix V*D*V^t");
		VDVt.show();
		WriteLine($"Is V*D*V^t==A? {matrix.compare(VtAV,D)}");
		WriteLine("-----");
		
		matrix VVt = V*V.transpose();
		WriteLine("Matrix V*V^t");
		VVt.show();
		matrix id = matrix.identity(n);
		WriteLine($"Is V*V^t==I? {matrix.compare(VVt,id)}");
		WriteLine("-----");

		matrix VtV = V.transpose()*V;
		WriteLine("Matrix V^t*V");
		VtV.show();
		WriteLine($"Is V^t*V==I? {matrix.compare(VtV,id)}");
		WriteLine("-----");

		WriteLine($"Is V^t*V==V*V^t? {matrix.compare(VtV,VVt)}");
		WriteLine("-----");

		
		
	}//Main func
}//main class
