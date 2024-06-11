using System;
using static System.Console;
using static System.Math;

public class ann{
	public int n; //number of hidden neurons.
	public Func<double,double> f = x => x*Exp(-x*x); //Doesn't have to be this function.
	public vector p; //Vector of network parameters.

	//Constructor:
	public ann(int N){
		n = N;
		p = new vector(n);
	}

	public void train(){
		//Minimize the cost function.
	}

}//ann class
