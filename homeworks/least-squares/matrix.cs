public class vector{
	public double[] data;

	public int size => data.Length;
	
	public double this[int i]{
		get {return data[i];}
		set {data[i] = value;}
		}
	
	public vector(int n){
		data = new double[n];
		}

	public void append(double element){
		double[] newdata = new double[size+1];
		for(int i=0; i<size; i++){
			newdata[i] = data[i];
		}
		newdata[size] = element;
		data = newdata;
	}

	public static vector random(int n, int range=10){
		var rnd = new System.Random();
		vector v = new vector(n);
		for(int i=0; i<n; i++){
			v[i] = rnd.NextDouble()*range;
			}
		return v;
		}

	public void show(){
		for(int i=0; i<this.size; i++){
			System.Console.WriteLine(this[i]);
			}
		}

	public void print() => show();

	public double norm(){
		double sum = 0;
		for(int i=0; i<size; i++){sum = sum + data[i]*data[i];}
		return System.Math.Sqrt(sum);
		}

	public static double dot(vector a, vector b){
		if(a.size != b.size){
			System.Console.WriteLine("Vectors don't have the same size...");
			return 0;
			}
		double sum = 0;
		for(int i=0; i<a.size; i++){sum = sum + a.data[i]*b.data[i];}
		return sum;
		}

	public static vector operator/(vector v, double a){
		vector newvec = new vector(v.size);
		for(int i=0; i<v.size; i++){
			newvec[i] = v[i]/a;
			}
		return newvec;
		}

	public static vector operator*(vector v, double a){
		vector newvec = new vector(v.size);
		for(int i=0; i<v.size; i++){
			newvec[i] = v[i]*a;
			}
		return newvec;
		}

	public static vector operator-(vector v, vector u){
		vector newvec = new vector(v.size);
		if(v.size != u.size){
			System.Console.WriteLine("Vectors don't have the same size...");
			return newvec;
			}
		for(int i=0; i<v.size; i++){
			newvec[i] = v[i] - u[i];
			}
		return newvec;
		}

	public static bool compare(vector a, vector b){
		if(a.size != b.size){
			System.Console.WriteLine("Vectors must be of the size");
			return false;}
		for(int i=0; i<a.size; i++){
			if(matrix.approx(a[i], b[i])==false) return false;
			}
		return true;
		}
}//vector class

public class matrix{
	public readonly int amountrows, amountcols;
	private double[] data;
	
	public matrix(int n, int m){
		amountrows = n;
		amountcols = m;
		data = new double[amountrows * amountcols];
		}

	public double this[int i, int j]{
		get {return data[j*amountrows + i];}
		set {data[j*amountrows + i] = value;}
		}

	public vector this[int j]{
		get{vector colj = new vector(amountrows);
			for(int i=0; i<amountrows; i++){colj[i] = this[i,j];}
			return colj;
			}//get
		set{for(int i=0; i<amountrows; i++){this[i,j] = value[i];}
			}//set
		}

	public static matrix identity(int n){
		matrix identity = new matrix(n,n);
		for(int i=0; i<n; i++){
			identity[i,i] = 1;
			}
		return identity;
		}

	public static matrix random(int n, int m, int range=10){
		var rnd = new System.Random();
		matrix A = new matrix(n,m);
		for(int i=0; i<n; i++){
			for(int j=0; j<m; j++){
				A[i,j] = rnd.NextDouble()*range;
				}
			}
		return A;
		}

	public void show(){
		for(int i=0; i<this.amountrows; i++){
			for(int j=0; j<this.amountcols; j++){
				System.Console.Write($"{this[i,j]}");
				System.Console.Write($"  ");
				}
			System.Console.WriteLine();
			}
		System.Console.WriteLine();
		}

	public void print() => show();

	public static bool isdiag(matrix A){
		for(int i=0; i<A.amountrows; i++){
			for(int j=0; j<A.amountcols; j++){
				if(i!=j && approx(A[i,j],0)==false){
					return false;
					}
				}
			}
		return true;
		}


	public static matrix product(matrix A, matrix B){
		matrix C = new matrix(A.amountrows, B.amountcols);  //resulting matrix, A*B=C
		for(int i=0; i<C.amountrows; i++){
			for(int j=0; j<C.amountcols; j++){
				//sum of products between A's ith row and B's jth column
				//each are n long
				double element = 0;
				for(int n=0; n<A.amountcols; n++){
					element = element + A[i,n]*B[n,j];
					}
				C[i,j] = element;
				}
			}
		return C;
		}//product function

	public static matrix operator*(matrix A, matrix B){
			return product(A,B);
			}


	public static vector product(matrix A, vector b){ //product overload with vector b
		vector c = new vector(A.amountrows);  //resulting vector, A*b=c
		for(int i=0; i<c.size; i++){
			double element = 0;
			for(int j=0; j<b.size; j++){
				element = element + A[i,j]*b[j];
				}
			c[i] = element;
			}
		return c;
		}//product function overload

	public matrix copy(){
		matrix clone = new matrix(this.amountrows, this.amountcols);
		for(int i=0; i<this.amountrows; i++){
			for(int j=0; j<this.amountcols; j++){
				clone[i,j] = this[i,j];
				}
			}
		return clone;
		}//copy method

	public matrix transpose(){
		matrix trans = new matrix(this.amountcols, this.amountrows);
		for(int i=0; i<trans.amountrows; i++){
			for(int j=0; j<trans.amountcols; j++){
				trans[i,j] = this[j,i];
				}
			}
		return trans;
		}//transpose method

	public static bool approx(double a,double b,double acc=1e-9,double eps=1e-9){
		if(System.Math.Abs(a-b)<acc)return true;
		if(System.Math.Abs(a-b)<(System.Math.Abs(a)+System.Math.Abs(b))*eps)return true;
		return false;
		}

	public static bool compare(matrix A, matrix B){
		if(A.amountrows != B.amountrows){
			System.Console.WriteLine("Matrices must be of same dimensions");
			return false;}
		if(A.amountcols != B.amountcols){
			System.Console.WriteLine("Matrices must be of same dimensions");
			return false;}
		for(int i=0; i<A.amountrows; i++){
			for(int j=0; j<B.amountcols; j++){
				if(approx(A[i,j], B[i,j])==false) return false;
				}
			}
		return true;
		}
}//matrix class



public static class QRGS{
	public static (matrix,matrix) decomp(matrix A){
		matrix Q = A.copy();
		matrix R = new matrix(A.amountcols,A.amountcols);
		
		//orthogonalize Q
		for(int i=0; i<A.amountcols; i++){ //the diagonal
			R[i,i] = Q[i].norm();
			Q[i] = Q[i]/R[i,i];
			for(int j=i+1; j<A.amountcols; j++){
				R[i,j] = vector.dot(Q[i],Q[j]);
				Q[j] = Q[j] - Q[i]*R[i,j];
				}
			}
		return (Q,R);
		}//decomp function

	public static vector solve(matrix Q, matrix R, vector b){  //solve a system R*x=Qt*b, where Qt*b=y
		matrix Qtrans = Q.transpose();
		vector y = matrix.product(Qtrans, b);
		vector x = new vector(y.size);
		for(int i=x.size-1; i>=0; i--){
			double sum = 0;
			for(int k=i+1; k<x.size; k++){
				sum = sum + R[i,k]*x[k];
				}
			x[i] = (1d/R[i,i])*(y[i] - sum);
			}
		return x;
		}

	public static double det_tri(matrix R){
		double det = 1;
		for(int i=0; i<R.amountrows; i++){
			det = det*R[i,i];
			}
		return det;
		}

	public static matrix inverse(matrix A){
		if(A.amountrows != A.amountcols){
			throw new System.ArgumentException("Matrix must be square");
			}
		int n = A.amountrows;
		matrix inv = new matrix(n,n);
		//Have to solve n linear systems, each of n equations
		//Ax_(i+1) = e_(i+1), for i=0,...,(n-1)
		//The set of columns e_(i+1) forms the identity matrix
		//The set of columns x_(i+1) forms the inverse of A

		//To do: Solve the i'th system of equations, save x_(i+1) as the i'th col of inv, repeat for all i
		(matrix Q, matrix R) = decomp(A);
		for(int i=0; i<n; i++){
			vector e = new vector(n);
			e[i] = 1;  //all other elements are 0, since double defaults to 0
			vector x = solve(Q, R, e);
			inv[i] = x;
			}
		return inv;
		}
}//QRGS class

