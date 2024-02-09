using static System.Console;
using static System.Math;

class main{
	public static void findmax(){
		int i = 1;
		while(i+1 > i){i++;}
		Write($"Max int = {i}\n");
	}

	public static void findmin(){
		int i = -1;
		while(i-1 < i){i--;}
		Write($"Min int = {i}\n");
	}

	public static bool approx(double an, double bn, double acc=1e-9, double eps=1e-9){
		if (Abs(an-bn) <= acc) return true;
		if (Abs(an-bn) <= Max(Abs(an), Abs(bn))*eps) return true;
		return false;
	}


	static void Main(){
		findmax();
		findmin();
		
		//Machine epsilon, double
		double x = 1;
		while(1+x != 1){x /= 2;}
		x *= 2;
		Write($"Machine epsilon, double = {x}\n");
		Write($"Compare to Pow(2,-52) = {Pow(2,-52)}\n");

		//Machine epsilon, float
		float y = 1F;
		while((float)(1F+y) != 1F){y /= 2F;}
		y *= 2F;
		Write($"Machine epsilon, float = {y}\n");
		Write($"Compare to Pow(2,-23) = {Pow(2,-23)}\n");

		
		//Part 3 of assignment
		double epsilon = Pow(2,-52);
		double tiny = epsilon/2d;
		double a = 1+tiny+tiny;
		double b = tiny+tiny+1;

		Write($"tiny = {tiny}\n");
		Write($"a = {a}\n");
		Write($"b = {b}\n");
		Write($"a==b ? {a==b}\n");
		Write($"a>1 ? {a>1}\n");
		Write($"b>1 ? {b>1}\n");
		Write($"a==1 ? {a==1}\n");
		Write($"b==1 ? {b==1}\n");
		Write($"The variable a gets saved in the memory as 1 to begin with, after which \n");
		Write($"Tiny is added to it. This then gets rounded down to 1, since 1 is so much \n");
		Write($"greater than Tiny. The variable b, however, gets saved first as Tiny, after which \n");
		Write($"1 is added to it. This then doesn't get rounded, I'm guessing since Tiny is \n");
		Write($"stored in the variable.\n");
		


		//Part 4
		double d1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
		double d2 = 0.1*8;

		Write($"d1 = {d1:e15}\n");
		Write($"d2 = {d2:e15}\n");
		Write($"d1==d2 gives {d1==d2}\n");
		
		bool compd1d2 = approx(d1,d2);
		Write($"Is d1 and d2 similar? {compd1d2}\n");

	}//main func
}//main class
