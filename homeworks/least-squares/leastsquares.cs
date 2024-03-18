public static class leastsquares{
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
