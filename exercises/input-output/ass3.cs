using static System.Math;

public class ass3{
	static int Main(string[] args){
		string infile = null, outfile = null;
		foreach(var arg in args){
			var words = arg.Split(':');
			if(words[0] == "-input") infile=words[1];
			if(words[0] == "-output") outfile=words[1];
			}
		if(infile==null || outfile==null){
			System.Console.Error.WriteLine("Wrong filename argument");
			return 1;
			}
		var instream = new System.IO.StreamReader(infile);
		var outstream = new System.IO.StreamWriter(outfile, append:true);

		outstream.WriteLine($"From assignment part 3");
		
		for(string line=instream.ReadLine(); line!=null; line=instream.ReadLine()){
			double x = double.Parse(line);
			outstream.WriteLine($"{x} {Sin(x)} {Cos(x)}");
			}

		instream.Close();
		outstream.Close();		
	
		return 0;
	}	
}