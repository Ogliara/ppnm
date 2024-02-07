using static System.Console;
using static System.Math;

class main{
	static void Main(){
		vec v = new vec(2,3,4);
		v.testwrite("v");

		vec u = new vec(2,8,37);
		u.testwrite("u");

		(-v).testwrite("-v");
		(-u*2d).testwrite("-u*2d");
		(v/2d).testwrite("v/2d");
		(v+u).testwrite("v+u");
		(v-u).testwrite("v-u");
		(u-v).testwrite("u-v");
		(-v-u).testwrite("-v-u");

		Write($"v.dot(u) gives {v.dot(u)}\n");
		Write($"v.dot(v) gives {v.dot(v)}\n");
		Write($"v.norm() gives {v.norm()}\n");
		Write($"vec.dot(v,u) gives {vec.dot(v,u)}\n");
		Write($"vec.dot(v,v) gives {vec.dot(v,v)}\n");

	
		double dotprod = vec.dot(v, v*2d);
		Write($"{dotprod}\n");

		double vnorm = v.norm();
		Write($"{vnorm}\n");

		bool approtest = vec.approx(v,u);
		Write($"{approtest}\n");

		Write(v.ToString() + $"\n");
		

	}//Main
}//main class
