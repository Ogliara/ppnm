Project number 7: Least-squares signal declipping.

Goal: Implement least-squares minimization for declipping following Dmitri's notes on the subject.

Description of project: Using my own matrix, vector and QR-decomposition classes found in matrix.cs, the 
declipping function found in leastsquares.cs takes a clipped signal vector, y, and an int array containing 
the positions of clipped data points in y, m. With these, it then calculates the M-matrix and builds the third 
derivative matrix, D, such that these can be multiplied together in order to apply my QRGS.solve() function, 
thus finding the z-vector, which it then returns. The user can then plug this into y in order to form the x-vector, 
which is the declipped signal.
	The figure declipping.gnuplot.svg shows a graphic comparison between the original signal, the signal 
after being clipped, and the restored signal for a signal given by 2sin(t)+3cos(t). The approximation found by the 
routine holds very well except for at the very beginning and the very end, as is to be expected. 

Self-evaluation: With the understanding that it is hard to judge my own work reasonably, I'd give my work here an 
8 out of 10 score. I have accomplished the task fully, though I wouldn't be surprised if there are plenty of 
places where the runtime can be optimized that I just can't see currently. Thus, I would give myself a score 
close to, but not quite reaching, maximum points.


							INITIAL PLAN:
Step 1) Do research on subject and formulate goal. DONE

Step 2) Bring in matrix.cs and other scripts. DONE

Step 3) Construct initial draft. DONE

Step 4) Debug the hell out of it. Figure out its limits so it can be fixed or reported on. DONE

Step 5) Make a couple of plots to go with it. DONE

Step 6) Write an explanation/overview and a self-evaluation of the project. DONE

Step 7) Make sure it (and all Homeworks) are built and fully accessible, as well as linked in the correct place.
