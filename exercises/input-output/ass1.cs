using static System.Math;

public class ass1{
	static int Main(string[] args){
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
		
		char[] split_delimiters = {' ', '\t', '\n'};
		//var split_options = StringSplitOptions.RemoveEmptyEntries;
		for(string line = System.Console.ReadLine(); line != null; line = System.Console.ReadLine()){
			var numbers = line.Split(split_delimiters);
			foreach(var number in numbers){
				double x = double.Parse(number);
				System.Console.Error.WriteLine($"${x} {Sin(x)} {Cos(x)}");
			}
		}

		return 0;
	}//main func
}//main class
