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
		zs = vector.linspace(N,x[0],x[x.size-1]);
		linterp_ys = new vector(zs.size);
		integ_ys = new vector (zs.size);
		for(int i=0; i<zs.size; i++){
			linterp_ys[i] = this.linterp(zs[i]);
			integ_ys[i] = this.integ(zs[i]);
		}
	}
/* Commenting this out, since I put a copy of it in the matrix.cs file under vector
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
*/
	public double linterp(double z){
		int i = vector.binsearch(x,z);
		return y[i] + p[i]*(z-x[i]);
	}//linterp

	public double integ(double z){
		int i = vector.binsearch(x,z);
		double sum = 0;
		for(int n=0; n<i; n++){
			sum = sum + y[n]*(x[n+1]-x[n]) + 0.5*p[n]*Math.Pow((x[n+1]-x[n]),2);
		}
		sum = sum + y[i]*(z-x[i]) + 0.5*p[i]*Math.Pow((z-x[i]),2);
		return sum;
	}//integ
}//linspline class



public class quadspline{
	//Vectors x and y are for data, b, c and p are coefficents for the spline
	vector x,y,b,c,p;
	public vector zs, quadterp_ys, derived_ys;

	public quadspline(vector xs, vector ys, int N=100){//constructor
		x = xs;
		y = ys;

		//Building b, c and p vectors
		c = new vector(x.size-1);
		b = new vector(x.size-1);
		p = new vector(x.size-1);
		p[0] = (y[1]-y[0])/(x[1]-x[0]);

		//Forward recursion and building p
		vector c_forward = new vector(c.size);
		c_forward[0] = 0;
		for(int i=0; i<c_forward.size-1; i++){
			double dxi = x[i+1]-x[i];
			double dxi1 = x[i+2]-x[i+1];
			double dyi1 = y[i+2]-y[i+1];
			p[i+1] = dyi1/dxi1; //With this, all of p gets built
			c_forward[i+1] = 1d/dxi1 * (p[i+1] - p[i] - c_forward[i]*dxi);
		}

		//Backward recursion
		vector c_backward = new vector(c.size);
		c_backward[c_backward.size-1] = 0;
		for(int i=c_backward.size-2; i>-1; i--){
			double dxi = x[i+1]-x[i];
			double dxi1 = x[i+2]-x[i+1];
			c_backward[i] = 1d/dxi * (p[i+1] - p[i] - c_backward[i+1]*dxi1);
		}
		
		//Build c as average of the two recursions, then build b
		for(int i=0; i<c.size; i++){
			c[i] = (c_forward[i] - c_backward[i])/2d;
			b[i] = p[i] - c[i]*(x[i+1]-x[i]);
		}

		//Make the zs, spline values, derived and integral values
		zs = vector.linspace(N,x[0],x[x.size-1]);
		quadterp_ys = new vector(zs.size);
		derived_ys = new vector(zs.size);		
		for(int i=0; i<zs.size; i++){
			quadterp_ys[i] = quadterp(zs[i]);
			derived_ys[i] = derived(zs[i]);
		}

	}

	public double quadterp(double z){
		int i = vector.binsearch(x,z);
		double spline_y = y[i] + b[i]*(z-x[i]) + c[i]*Math.Pow((z-x[i]),2);
		return spline_y;
	}

	public double derived(double z){
		int i = vector.binsearch(x,z);
		return b[i] + 2*c[i]*z - 2*c[i]*x[i];
	}
}//quadspline class
