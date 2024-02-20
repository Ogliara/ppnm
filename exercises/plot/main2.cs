class main2{
	public static int Main(){
		double dx=1.0/64;
		for(double x=-4+dx/2; x<=6+dx/2; x+=dx){//If doing for loop over double, do it in binary representaion
			System.Console.WriteLine($"{x} {sfuns.gamma(x)}");
			}


		return 0;
	}
}
