using System;
using static System.Math;
using static System.Console;

public static class main{
	public static void Main(){
		//Making a neural network. I'm naming her Annie, you can't stop me.
		ann annie = new ann(2);
		WriteLine("Annie's parameter vector pre training.");
		annie.p.show();
		WriteLine("");

		//Making some data to train Annie on.
		Func<double,double> g = x =>{
			return Cos(5*x-1) * Exp(-x*x);
		};

		int Ndata = 10;
		vector xs = vector.random(Ndata, -1, 1); //Random numbers from -1 to 1.
		vector ys = new vector(Ndata);
		WriteLine("Training data");
		for(int i=0; i<xs.size; i++){
			ys[i] = g(xs[i]);
			WriteLine($"{xs[i]}  ,  {ys[i]}");
		}
		WriteLine("");

		//Training Annie.
		annie.train(xs,ys);
		WriteLine("Annie's parameter vector post training.");
		annie.p.show();
		WriteLine("");
		WriteLine($"Training took {annie.traincount} loops to complete.");
		WriteLine("");

		//Comparing Annie's response function to g(x).
		vector annie_ys = new vector(xs.size);
		double ssd = 0;
		WriteLine("Annie's answers and the correct answers");
		for(int i=0; i<xs.size; i++){
			annie_ys[i] = annie.response(xs[i], annie.p);
			WriteLine($"{annie_ys[i]}  ,  {ys[i]}");
			ssd += Pow(annie_ys[i] - ys[i],2);
		}
		ssd = ssd/ys.size;
		WriteLine("");
		WriteLine($"SSD = {ssd}.");
		WriteLine("");

	}//Main function.
}//main class.
