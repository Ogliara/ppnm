class hello{
	static double f(int x){
		return 1.0/x;
	}

	static void Main(){ 
		int x = 7; 
		double result = f(x); 
		System.Console.Write("Hello world, I love you\n"); 
		System.Console.Write("You are pretty and nice\n"); 
		System.Console.Write("x equals: {0}\n",x); 
		System.Console.Write("result equals: {0}\n", result);
	}
}
