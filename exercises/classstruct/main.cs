using System;
using static System.Console;

class main{
	static void Main(string[] args){
		double x=2, y=1;
		if(x>y) Write("x>y\n");  //Don't have to make the statemet a block if it's only one line.
		else Write("y<=x\n");

		for(int i=1; i<10; i++){
			Write($"i={i}\n");
		}//for loop
		
		int n=0;
		do {Write($"n={n}\n"); n++;} while(n<10);  //do while executes at least once. while do doesn't.



		//Arrays
		n = 5;  //Please excuse the reused name, I'm trying to keep up with Dimitri.
		double[] a = new double[n];
		for(int i=0; i<n; i++) a[i] = i+1;
		for(int i=0; i<n; i++) Write($"{a[i]}\n");
		foreach(double ai in a) Write($"ai={ai}\n");
		Write("\n");
		foreach(string arg in args) Write($"arg={arg}\n");
		Write("\n");
	}//Main
}//class main
