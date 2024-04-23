using System;
using static System.Math;
public static class montecarlo{
	//Plain Monte Carlo integrator to return the value of the integral along with its error.
	public static (double,double) plain(Func<vector,double> f, vector a, vector b, int N){
		int dim = a.size;  //amount of dimensions to integrate over.
		double V = 1;
		for(int i=0; i<dim; i++){ //Making V the integration volume, remembering that it is rectangular.
			V *= b[i] - a[i];
		}
		double sum_f = 0;
		double sum_fsquared = 0;
		var rnd = new Random();
		vector xs = new vector(dim);
		for(int i=0; i<N; i++){
			for(int j=0; j<dim; j++){
				xs[j] = a[j] + rnd.NextDouble()*(b[j] - a[j]);
			}
			sum_f += f(xs);
			sum_fsquared += f(xs)*f(xs);
		}
		double mean_f = sum_f/N;
		double sigma = Sqrt(sum_fsquared/N - mean_f*mean_f);
		double err = V*sigma/Sqrt(N);
		return (V*mean_f,err);
	}
}//montecarlo class
