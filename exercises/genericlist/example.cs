class main{

	static double a = 17;

	public static System.Func<double,double> make_power(int i){
		System.Func<double,double> f = delegate(double x){return System.Math.Pow(a,i);};
		return f;  //always captured as reference
		}


	public static int Main(){
		genlist<double> list = new genlist<double>();
		list.add(1.2);
		list.add(2.0); //and so on
		for(int i=0; i<list.size; i++) System.Console.WriteLine(list[i]);
		
		list[0] = 0;
		list[1] = 0;
		for(int i=0; i<list.size; i++) System.Console.WriteLine(list[i]);

		//Just convincing myself of how redirecting objects works
		System.Console.WriteLine($"list has size {list.size} and data length {list.data.Length}.");
		
		//Testing my remove method
		System.Console.WriteLine("Before removal");
		for(int i=0; i<list.size; i++) System.Console.WriteLine(list[i]);		
		list.remove(1);
		System.Console.WriteLine("After removal");
		for(int i=0; i<list.size; i++) System.Console.WriteLine(list[i]);
		System.Console.WriteLine($"list now has size {list.size} and data length {list.data.Length}.");


		//Function list example
		double x=10;
		a=7;
		System.Func<double,double> f = delegate(double tmp){return a;};  //captures by reference
		a = 9; 
		System.Console.WriteLine($"f({x}) = {f(x)}");  //meaning this prints f(x) = 9

		var flist = new genlist<System.Func<double,double>>();
		flist.add(f);
		flist.add(System.Math.Sin);
		flist.add(System.Math.Cos);

		//Showing that a is only captured by reference, meaning that only the last value of a
		//before you call it matters		
		a=1;
		var f1 = make_power(1);
		flist.add(f1);
		a=2;
		var f2 = make_power(1);
		flist.add(f2);

		a = 666;

		for(int i=0; i<flist.size; i++){
			System.Console.WriteLine($"f[{i}]({x}) = {flist[i](x)}");
			}

		return 0;
		}

}
