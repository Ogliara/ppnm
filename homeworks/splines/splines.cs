//To contain interpolation methods

using System;
public class linspline{
	//Vector x and y are data points, while p is a vector of all the pi-values needed for splines
	vector x,y,p;
	//Vector zs holds a linspace for z-values, linterp_ys and integ_ys are spline values and integrant values
	public vector zs, linterp_ys, integ_ys;
	
	public linspline(vector xs, vector ys, int N=100){//constructor
		x = xs;
		y = ys;
		p = new vector(x.size);
		for(int i=0; i<x.size-1; i++){//setting each p-value
			double dx = x[i+1]-x[i];
			double dy = y[i+1]-y[i];
			if(!(dx>0)){
				throw new Exception("dx is not greater than 0, for some reason");
			}
			p[i] = dy/dx;
		}
		zs = new vector(N);
		linterp_ys = new vector(zs.size);
		integ_ys = new vector (zs.size);
		for(int i=0; i<zs.size; i++){
			zs[i] = x[0] + i*(x[x.size-1]-x[0])/Convert.ToDouble(N);
			linterp_ys[i] = this.linterp(zs[i]);
			integ_ys[i] = this.integ(zs[i]);
		}
	}

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
	}//binsearch

	public double linterp(double z){
		int i = binsearch(x,z);
		return y[i] + p[i]*(z-x[i]);
	}//linterp

	public double integ(double z){
		int i = binsearch(x,z);
		double sum = 0;
		for(int n=0; n<i; n++){
			sum = sum + y[n]*(x[n+1]-x[n]) + 0.5*p[n]*Math.Pow((x[n+1]-x[n]),2);
		}
		sum = sum + y[i]*(z-x[i]) + 0.5*p[i]*Math.Pow((z-x[i]),2);
		return sum;
	}//integ

}//linspline class
