using System;
using static System.Console;

public static class main{
	public static void Main(){
		matrix A = matrix.random(3,3);
		jacobi.timesJ(A,2,2,Math.PI/2);
	}//Main func
}//main class
