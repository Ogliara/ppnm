using System;
using static System.Console;
using static System.Math;

//There is gonna be n*3 parameters (a_i, b_i and w_i).
//The networks job is to find the vector consisting of these that minimizes the cost function.
//Thus, the parameters are the closet to the training values.
//The network needs to be constructed, and then the user should be able to train it with their own data.

public class ann{
	public int n; //number of hidden neurons.
	public Func<double,double> f = x => x*Exp(-x*x); //Doesn't have to be this activation function.
	public vector p; //Vector of ALL network parameters. It goes {a1,b1,w1,a2,b2,w2,...an,bn,wn}.
	public int traincount;

	//Constructor.
	public ann(int N){
		n = N;
		p = new vector(3*n);
		for(int i=0; i<p.size; i+=3){ //If any b-parameter is 0, we get a lot of NaN's...
			p[i] = 0.5;
			p[i+1] = 0.5;
			p[i+2] = 0.5;
		}
		traincount = 0;
	}

	//Response function.
	public double response(double x, vector para){ //Para is basically p.
		double res = 0;
		for(int i=0; i<para.size; i+=3){ //This way p[i]=ai, p[i+1]=bi and p[i+2]=wi.
			res += f(  (x-para[i])/para[i+1]  ) * para[i+2];
		}
		return res;
	}


	public void train(vector xs, vector ys){ //The set {xs,ys} is the training data.
		if(xs.size != ys.size) throw new ArgumentException("xs and ys are not the same length!");

		//Costfunc needs to take parameter vector as argument.
		Func<vector,double> costfunc = para =>{
			double res = 0;
			for(int i=0; i<xs.size; i++){
				double part = Pow(response(xs[i], para) - ys[i],2);
				res += part;
			}
			return res/xs.size; //In the chapter on ANN, the cost function is scaled with 1/N.
		};//costfunc

		(vector ptrained, int trainloopcount) = mini.newton(costfunc, this.p, 1e-9);

		this.p = ptrained;
		traincount = trainloopcount;
		
	}//train function

}//ann class
