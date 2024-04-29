using System;
using static System.Math;

public static class roots{
	public static vector newton(Func<vector,double>[] fs, vector x0s, double tol=1){
		int n = x0s.size;
		vector xns = new vector(n); //Vector for optimal xns.
		xns = x0s;
		matrix jacobi = new matrix(n,n);
		vector newt_step = new vector(n);
		vector fsx = eval_func_vector(fs,xns);
		do{//Do until converged.
			//Calculating Jacobian.
			for(int i=0; i<n; i++){
				for(int k=0; k<n; k++){
					double dxk = Abs(xns[k])*Pow(2,-26);
					vector xns_stepped = xns.copy();
					xns_stepped[k] = xns[k] + dxk;
					jacobi[i,k] = (fs[i](xns_stepped) - fs[i](xns)) / dxk;
				}
			}
			//Solving J*dx=-f(x).
			(matrix JQ, matrix JR) = QRGS.decomp(jacobi);
			newt_step = QRGS.solve(JQ,JR,-fsx);
			//Adjusting xns.
			double lambda = 1.0;
			vector fsx_stepped = eval_func_vector(fs,xns+lambda*newt_step);
			while(fsx_stepped.length() > (1.0 - lambda/2.0)*fsx.length() && lambda >= 1.0/64.0){
				lambda = lambda/2.0;
			}
			xns = xns + lambda*newt_step;
			fsx = eval_func_vector(fs,xns); //Updating fsx.
		}while(fsx.length() < tol); //Convergence criteria loop.
		return xns;
	}//newton func


	public static vector eval_func_vector(Func<vector,double>[] fs, vector xs){
		int n = xs.size;
		vector fsx = new vector(n);
		for(int i=0; i<n; i++){
			fsx[i] = fs[i](xs);
		}
		return fsx;
	}//eval_func_vector
}//roots class
