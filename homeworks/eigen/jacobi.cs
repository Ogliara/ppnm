using System;
using static System.Console;

//For all the jacobi things
public static class jacobi{
	//A couple of casts to make life easier
	public static double s(double theta) => Math.Sin(theta);
	public static double c(double theta) => Math.Cos(theta);
	public static double pow(double a, double b) => Math.Pow(a,b);

	public static void timesJ(matrix A, int p, int q, double theta){
		double st = s(theta);
		double ct = c(theta);
		//A <- AJ
		for(int i=0; i<A.amountrows; i++){
			double aip = A[i,p];
			double aiq = A[i,q];
			A[i,p] = ct*aip - st*aiq; //A's new element aip is the ith row of A times the pth column of J
			A[i,q] = st*aip + ct*aiq;
		}
	}//timesJ function

	public static void Jtimes(matrix A, int p, int q, double theta){
		double st = s(theta);
		double ct = c(theta);
		//A <- J^TA. I am not certain if J should be transposed or not. If not, flip signs on st
		for(int j=0; j<A.amountrows; j++){
			double apj = A[p,j];
			double aqj = A[q,j];
			A[p,j] = ct*apj - st*aqj; //A's new element apj is the pth row of J times the jth column of A
			A[q,j] = st*apj + ct*aqj;
		}
	}//Jtimes function

	public static matrix cyclical(matrix A){
		//Must go through A col by col and apply Jtimes and timesJ to them all
		//Have to loop over all off-diagonal p's and q's
		//When through all cols, must check convergence by testing if any col has changed over that sweep
		//If just one col has changed, repeat the sweep
		//If nothing has changed, end the loop

		int n = A.amountcols;
		matrix V = matrix.identity(n);
		bool changed;
		do{//This repeats as long as changed is equal to true
			changed = false;
			for(int p=0; p<n-1; p++)  //going only to n-1 to 'make space' for the qth col
				for(int q=p+1; q<n; q++){
					double apq = A[p,q];
					double aqq = A[q,q];
					double app = A[p,p];
					double theta = 1d/2d*Math.Atan2(2*apq,aqq - app);
					double st = s(theta);
					double ct = c(theta);
					double new_app = pow(ct,2)*app - 2*st*ct*apq + pow(st,2)*aqq;
					double new_aqq = pow(st,2)*app - 2*st*ct*apq + pow(ct,2)*aqq;
					if(new_app!=app || new_aqq!=aqq){
						changed = true;
						timesJ(A,p,q,theta);
						Jtimes(A,p,q,theta);
					}
				}
		}while(changed == true);
		return V;
	}







}//jacobi class
