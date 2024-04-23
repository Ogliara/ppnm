default: fit.gnuplot.svg Testresults.txt

fit.gnuplot.svg: plotdata.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key right;\
		set xlabel "z" ;\
		set ylabel "erf(z)" ;\
		set tics out ;\
		set grid ;\
		set title "Error Function" ;\
		plot \
			"$<" using 1:2 notitle ;\
	' | tee log.gpi | gnuplot

Testresults.txt: main.exe
	mono $< 1>$@ 2>plotdata.txt

main.exe: main.cs integrator.dll matrix.dll
	mcs -target:exe -reference:integrator.dll -reference:matrix.dll -out:$@ $<

integrator.dll: integrator.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:$@ $<

matrix.dll: matrix.cs
	mcs -target:library -out:$@ $<

PHONEY: clean
clean:
	rm -f *.dll *.exe Testresults.txt
