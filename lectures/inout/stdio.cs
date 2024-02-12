class main{
	static int Main(){
		double x = 7;
		System.Console.Out.Write($"This goes to stdout: x={x}\n");
		System.Console.Error.Write($"This goes to stderr: x={x}\n");
		
		string line = System.Console.In.ReadLine();
		
		System.Console.Error.Write($"This also goes to stderr: {line}\n");
		x = double.Parse(line);
		System.Console.Out.Write($"This goes to stdout: x={x}\n");


		
		return 0;
	}//main func
}
