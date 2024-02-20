class main3{
	public static int Main(){
		double dx=1.0/64;
		for(double x=0+dx/2; x<=10+dx/2; x+=dx){//If doing for loop over double, do it in binary representaion
			System.Console.WriteLine($"{x} {sfuns.lngamma(x)}");
			}


		return 0;
	}
}
