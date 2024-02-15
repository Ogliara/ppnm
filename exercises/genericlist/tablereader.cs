//using static genlist.dll;
using System;

class tablereader{
	static void Main(){
		var list = new genlist<double[]>();
		char[] split_delimiters = {' ', '\t'};
		var split_options = StringSplitOptions.RemoveEmptyEntries;
		for(string line = Console.ReadLine(); line != null; line = Console.ReadLine()){
			var words = line.Split(split_delimiters, split_options);
			int n = words.Length;
			double[] numbers = new double[n];
			for(int i=0; i<n; i++){numbers[i] = double.Parse(words[i]);}
			list.add(numbers);
			}//for every non-empty line in input

		for(int i=0; i<list.size; i++){
			var numbers = list[i];
			foreach(var number in numbers){Console.Write($"{number : 0.00e00;-0.00e00} ");}
			Console.WriteLine();
			}



	}
}
