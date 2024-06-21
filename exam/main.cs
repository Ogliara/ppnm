using System;
using static System.Math;
using static System.Console;

public static class main{
	public static void Main(){
		WriteLine("Hello, World!");
		int N = 10;
		vector ytest = vector.random(N,-5,5);
		int[] mtest = {2,4,7};
		for(int i=0; i<mtest.Length; i++){ytest[mtest[i]] = 0;}
		WriteLine("ytest");
		ytest.show();
		WriteLine();

		vector ztest = leastsquares.declipping(mtest,ytest);
		WriteLine("ztest");
		ztest.show();
		WriteLine();

		vector xtest = ytest.copy();
		for(int i=0; i<mtest.Length; i++){xtest[mtest[i]] = ztest[i];}
		WriteLine("xtest");
		xtest.show();
		WriteLine();

		
	}//Main function.
}//main class.
