//To contain interpolation methods

using System;
public static class linsplin{
	public static int binsearch(vector x, double z){
		int i = 0;
		int j = x.size - 1;
		//If z isn't contained in x, throw an exception
		if(z<x[i] || z>x[j]){
			throw new ArgumentException("z is not contained in x. Choose new z");
		}
		//Continue to cut away the half of all indicies that z isn't contained in
		//Stop when we have x[i]<z<x[i+1], where i+1=j
		while(j-i>1){
			int mid = (i+j)/2;
			if(z > x[mid]){i = mid;}
			else{j=mid;}
		}
		return i;
	}



	public static double linterp(vector x, vector y, double z){
		int i = binsearch(x,z);
		double dx = x[i+1]-x[i];
		double dy = y[i+1]-y[i];
		return y[i] + (dy/dx)*(z-x[i]);
	}
}
