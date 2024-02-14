using System;
using static System.Math;

public class ass2{
	static void Main(){
		System.Console.Error.WriteLine($"From assignment part 2");
		char[] split_delimiters = {' ', '\t', '\n'};
		var split_options = StringSplitOptions.RemoveEmptyEntries;
		for(string line = System.Console.ReadLine(); line != null; line = System.Console.ReadLine()){
			var numbers = line.Split(split_delimiters, split_options);
			foreach(var number in numbers){
				double x = double.Parse(number);
				System.Console.Error.WriteLine($"{x} {Sin(x)} {Cos(x)}");
			}
		}

		System.Console.Error.WriteLine("");		

	}//Main func
}//ass2 class
