using static System.Math;

public class ass1{
	static int Main(string[] args){
		System.Console.WriteLine($"From assignment part 1");	
		foreach(var arg in args){
			var words = arg.Split(':');
			if(words[0] == "-numbers"){
				var numbers = words[1].Split(',');
				foreach(var number in numbers){
					double x = double.Parse(number);
					System.Console.WriteLine($"{x} {Sin(x)} {Cos(x)}");
				}
			}
		}
		System.Console.WriteLine("");	
		return 0;
	}//main func
}//main class
