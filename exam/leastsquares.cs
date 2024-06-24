//Version 21-06-2024 -- Exam

public static class leastsquares{
	public static vector declipping(int[] m, vector y){
		int N = y.size;
		int n = m.Length;

		//Making D.
		matrix D = new matrix(N,N);
		for(int i=0; i<N; i++){
			if(i==0 || i==1) {D[i,i] = -1; D[i,i+1] = 3; D[i,i+2] = -3; D[i,i+3] = 1;}
			if(i>=2 && i<=N-3) {D[i,i-2] = -0.5; D[i,i-1] = 1; D[i,i] = 0; D[i,i+1] = -1; D[i,i+2] = 0.5;}
			if(i==N-2 || i==N-1) {D[i,i-3] = -1; D[i,i-2] = 3; D[i,i-1] = -3; D[i,i] = 1;}
		}

		//Making M.
		matrix M = new matrix(N,n);
		for(int k=0; k<n; k++){
			M[m[k],k] = 1;
		}

		//Calculate A, decomp, then solve.
		matrix A = matrix.product(D,M);
		(matrix Q, matrix R) = QRGS.decomp(A);
		vector b = -1*matrix.product(D,y);

		vector z = QRGS.solve(Q,R,b);


		return z;
	}//declipping function




	//EXAM NOTE: The lsfit function is from the homework. It isn't used for the exam at all.
	public static (vector,matrix) lsfit(System.Func<double,double>[] fs, vector x, vector y, vector yerr){
		int n = x.size;
		int m = fs.Length;
		matrix A = new matrix(n,m);
		vector b = new vector(n);
		for(int i=0; i<n; i++){
			b[i] = y[i]/yerr[i];
			for(int k=0; k<m; k++){
				A[i,k] = fs[k](x[i])/yerr[i];
			}
		}
		(matrix Q, matrix R) = QRGS.decomp(A);
		vector c = QRGS.solve(Q,R,b);
		matrix Rinv = QRGS.inverse(R);
		matrix sigma = Rinv*Rinv.transpose();
		return (c,sigma);
	}//lsfit function
}//leastsquare class
