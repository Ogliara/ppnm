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

	public static (double, double) lowdis(Func<vector,double> f, vector a, vector b, int N){
		int dim = a.size;
		//I think each coordinate still has the same weight, so the V/N thing still holds.
		double V = 1;
		for(int i=0; i<dim; i++){
			V *= b[i] - a[i];
		}
		double sum_halton = 0;
		double sum_additive = 0;
		vector xn_halton = new vector(dim);
		vector xn_additive = new vector(dim);
		for(int i=0; i<N; i++){
			halton(i, dim, xn_halton);
			xn_halton = a + xn_halton*(b - a);
			sum_halton += f(xn_halton);

			additive(i, dim, xn_additive);
			xn_additive = a + xn_additive*(b - a);
			sum_additive += f(xn_additive);
		}
		double err = Abs(sum_halton - sum_additive);
		return (V/N*sum_halton, err);
	}//lowdis func

	public static double corput(int n, int b){
		double q = 0;
		double bk = 1d/b;
		while(n>0){
			q += (n % b)*bk; //using modulo here is so clever, Dimitri, goddamn.
			n /= b;  //And dividing by the base to get the next digit.
			bk /= b;
		}
		return q;
	}//corput func

	public static void halton(int n, int d, vector xn){//This way, it changes xs instead of making a new object.
		int[] bases = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61};
		if(bases.Length >= d){
			for(int i=0; i<d; i++){
				xn[i] = corput(n, bases[i]);
			}
		}
	}//halton func

	public static void additive(int n, int d, vector xn){
		int[] primes = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61};
		for(int i=0; i<d; i++){
			double irrational = Sqrt(primes[i]) % 1;
			xn[i] = (n*irrational) % 1;
		}
	}
}//montecarlo class
