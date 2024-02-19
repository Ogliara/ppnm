using System;

class main{
	static void Main(){
		//square root of -1
		complex minus1 = new complex(-1, 0);
		Console.WriteLine($"sqrt(-1) = {cmath.sqrt(minus1)}");
		Console.WriteLine($"Real part of -1 = {minus1.Re}");
		Console.WriteLine($"Img part of -1 = {minus1.Im}");


		//Doing this with i
		complex i = new complex(0,1);
		Console.WriteLine($"sqrt(i) = {cmath.sqrt(i)}");
		Console.WriteLine($"argument of i = {complex.argument(i)}");
		
				
		
		
	}

}
