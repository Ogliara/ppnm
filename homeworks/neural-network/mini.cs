//Version 11.06.2024

using System;
using static System.Math;
using static System.Console;

public static class mini{
	public static (vector,int) newton(Func<vector,double> phi, vector x, double acc=1e-3){
		int loop_count = 0;
		do{
			//Make gradient, check condition.
			vector grad = gradient(phi, x);
			if(grad.norm() < acc){ //If this condition is met, then end the loop.
				break;
			}
			//Make Hessian matrix, solve for Newton's step called delta_x.
			matrix hess = hessian(phi, x);
			(matrix hessQ, matrix hessR) = QRGS.decomp(hess);
			vector delta_x = QRGS.solve(hessQ, hessR, -grad);
			//Find lambda to scale Newton's step.
			double lambda = 1;
			double phi_x = phi(x);
			do{
				if(phi(x+lambda*delta_x) < phi_x) break; //Accept.
				if(lambda < 1d/1024d) break; //Lambda is less than minimum, so accept anyway.
				lambda = lambda/2;
			}while(true);
			//Update x.
			x = x + lambda*delta_x;
			//Break loop if convergence can't be achieved.
			loop_count += 1;
			if(loop_count >= 100000) break;
		}while(true);
		return (x, loop_count);
	}//newton function


	public static vector gradient(Func<vector,double> phi, vector x){
		vector grad = new vector(x.size);
		for(int i=0; i<x.size; i++){
			double dx = Max(Abs(x[i]),1)*Pow(2,-26);
			vector x_step = x.copy();
			x_step[i] = x_step[i] + dx;
			grad[i] = (phi(x_step) - phi(x)) / dx;
		}
		return grad;
	}//gradient function

	public static matrix hessian(Func<vector,double> phi, vector x){
		matrix hess = new matrix(x.size,x.size);
		vector grad = gradient(phi, x);
		for(int i=0; i<x.size; i++){
			double dxi = Max(Abs(x[i]),1)*Pow(2,-13); //Works way better than -26 for some reason.
			vector x_step = x.copy();
			x_step[i] = x_step[i] + dxi;
			vector grad_step = gradient(phi, x_step);
			for(int j=0; j<x.size; j++){
				hess[i,j] = (grad_step[j] - grad[j]) / dxi;
			}
		}
		return hess;
	}//hessian function

}//mini class
