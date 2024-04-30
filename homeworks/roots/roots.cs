using System;
using static System.Math;

public static class roots{
	public static vector newton(Func<vector,double>[] fs, vector x0s, vector dxs=null, double tol=1e-6){
		int n = x0s.size;
		vector xns = new vector(n); //Vector for optimal xns.
		xns = x0s;
		vector newt_step = new vector(n);
		vector fsx = eval_func_vector(fs,xns);
		int loop_count = 1;
		do{//Do until converged.
			//Calculating Jacobian.
			matrix jacobi = jacobian(fs, xns, dxs);
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
			loop_count += 1; //Using loopcount to make sure that the loop is exited at some point.
		}while(fsx.length() > tol); //Convergence criteria loop.
		return xns;
	}//newton func

	public static matrix jacobian(Func<vector,double>[] fs, vector xs, vector dxs=null){
		int n = xs.size;
		if(dxs == null){
			dxs = new vector(n);
			for(int i=0; i<n; i++){
				dxs[i] = Abs(xs[i])*Pow(2,-26);
			}
		}
		matrix jacobi = new matrix(n,n);
		for(int i=0; i<n; i++){
			for(int k=0; k<n; k++){
				vector xs_stepped = xs.copy();
				xs_stepped[k] = xs[k] + dxs[k];
				jacobi[i,k] = (fs[i](xs_stepped) - fs[i](xs)) / dxs[k];
			}
		}
		return jacobi;
	}//jacobian func

	public static vector eval_func_vector(Func<vector,double>[] fs, vector xs){
		int n = xs.size;
		vector fsx = new vector(n);
		for(int i=0; i<n; i++){
			fsx[i] = fs[i](xs);
		}
		return fsx;
	}//eval_func_vector
}//roots class
