using static System.Console;

public class myclass{
	public string s;
}//myclass


public struct mystruct{
	public string s;
}//mystruct

static class main{
	static void set_to_7(double x) {x = 7;}
	static void set_to_7(double[] x) {for(int i=0; i<x.Length; i++) x[i] = 7;}  //Overloading is allowed.

	static int Main(){
		myclass A = new myclass();
		mystruct b = new mystruct();
		A.s = "Hello";
		b.s = "Hello";
		WriteLine($"A.s = {A.s}");
		WriteLine($"b.s = {b.s}");

		myclass B = A;  //The equal sign is a copy constructor. For classes, this is a reference type.
		mystruct a = b;  //For structures, the copy constructor is a value type.
		WriteLine($"A.s = {A.s}");
		WriteLine($"b.s = {b.s}");
		
		B.s = "new string";
		b.s = "new string";
		WriteLine($"B.s = {B.s}");
		WriteLine($"a.s = {a.s}");
		WriteLine($"A.s = {A.s}");
		WriteLine($"b.s = {b.s}");
		
		double x = 1;
		set_to_7(x);
		Write($"x = {x}\n");  //Since double is a struc, it writes 1. 
					//Add ref to the funtion to make it a reference. set_to_7(ref double x).
					//According to Dimitri: Don't use ref unless you know what you are doing.

		double[] v = new double[5];
		set_to_7(v);
		foreach(var vi in v) Write(vi);  //This writes 7's because array is a class.
		Write("\n");

		return 0;
		
	}
}//main class
