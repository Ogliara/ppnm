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
		get {return data[j*amountcols + i];}
		set {data[j*amountcols + i] = value;}
		}

	public vector this[int j]{
		get{vector colj = new vector(amountrows);
			for(int i=0; i<amountrows; i++){colj[i] = this[i,j];}
			return colj;
			}//get
		set{for(int i=0; i<amountrows; i++){this[i,j] = value[i];}
			}//set
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
		for(int i=0; i<this.amountrows; i++){
			for(int j=0; j<this.amountcols; j++){
				trans[j,i] = this[i,j];
				}
			}
		return trans;
		}//transpose method

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

	//public static vector solve(matrix Q, matrix R)
}//QRGS class
