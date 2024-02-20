using System;
using static System.Console;

class main{
	static void Main(){
		//square root of -1
		complex minus1 = new complex(-1, 0);
		Console.WriteLine($"sqrt(-1) = {cmath.sqrt(minus1)}");
		Console.WriteLine();


		//Doing this with i
		complex i = new complex(0,1);
		complex sqrti = cmath.sqrt(i);
		Console.WriteLine($"sqrt(i) = {sqrti}");
		Console.WriteLine($"argument of i = {complex.argument(i)}");
		Console.WriteLine();
		
		complex expi = cmath.exp(i);
		double cos1 = Math.Cos(1d);
		double sin1 = Math.Sin(1d);		
		Console.WriteLine($"e^i = {expi}");
		Console.WriteLine($"Comparing Re to cos(1) gives {cmath.approx(expi.Re,cos1)}");
		Console.WriteLine($"Comparing Im to sin(1) {cmath.approx(expi.Im,sin1)}");
		Console.WriteLine();

		complex expipi = cmath.exp(i*Math.PI);
		double cospi = Math.Cos(Math.PI);
		double sinpi = Math.Sin(Math.PI);
		Console.WriteLine($"e^(i*pi) = {expipi}");
		Console.WriteLine($"Comparing Re to cos(pi) gives {cmath.approx(expipi.Re,cospi)}");
		Console.WriteLine($"Comparing Im to sin(pi) gives {cmath.approx(expipi.Im,sinpi)}");
		Console.WriteLine();
		
		
		
		
	}

}
