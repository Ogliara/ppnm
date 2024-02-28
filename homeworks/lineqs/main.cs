using System;

static class main{
	//Function to show all elements of a matrix
	static void showmatrix(matrix A){
		for(int i=0; i<A.amountrows; i++){
			for(int j=0; j<A.amountcols; j++){
				Console.WriteLine($"{i}{j} = {A[i,j]}");
				}
			}
		Console.WriteLine();
	}//showmatrix function


	static int Main(){
		matrix A = new matrix(2,2);
		A[0,0] = 1;
		A[0,1] = 2;
		A[1,0] = 3;
		A[1,1] = 4;
		
		matrix B = new matrix(2,2);
		B[0,0] = 5;
		B[0,1] = 6;
		B[1,0] = 7;
		B[1,1] = 8;

		showmatrix(A);	
		showmatrix(B);

		matrix C = matrix.product(A,B);
		showmatrix(C);

		vector Acol0 = A[0];		
		Console.WriteLine(Acol0[0]);
		Console.WriteLine(Acol0[1]);
		vector prodtest = matrix.product(A,Acol0);
		Console.WriteLine($"Testing matrix times vector, A*Acol0 = {prodtest[0]} {prodtest[1]}");

		
		Console.WriteLine($"Testing decomp");
		(matrix AQ, matrix AR) = QRGS.decomp(A);
		showmatrix(AQ);
		showmatrix(AR);
		
		matrix AQt = AQ.transpose();
		showmatrix(matrix.product(AQt,AQ));

		showmatrix(matrix.product(AQ,AR));


		return 0;
	}//Main func

}//main class
