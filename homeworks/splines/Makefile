default: linspline.gnuplot.svg quadspline.gnuplot.svg

linspline.gnuplot.svg: plotdata.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key right ;\
		set xlabel "x" ;\
		set ylabel "y" ;\
		set tics out ;\
		set grid ;\
		set title "Linear Splines" ;\
		plot \
			"$<" using 1:2 title "Data" \
			,"$<" using 3:4 with lines title "Linear Splines" \
			,"$<" using 3:5 with lines title "Linear Anti-Derivative" ;\
	' | gnuplot

quadspline.gnuplot.svg: plotdata.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key right ;\
		set xlabel "x" ;\
		set ylabel "y" ;\
		set tics out ;\
		set grid ;\
		set title "Quadratic Splines" ;\
		plot \
			"$<" using 1:2 title "Data" \
			,"$<" using 3:6 with lines title "Quadratic Splines" \
			,"$<" using 3:7 with lines title "Quadratic Derived" \
			,"$<" using 3:8 with lines title "Quadratic Anti-Derived" ;\
	' | gnuplot

plotdata.txt: main.exe
	mono $< 1>Out.txt 2>$@

main.exe: main.cs matrix.dll splines.dll
	mcs -target:exe -reference:matrix.dll -reference:splines.dll -out:$@ $<

splines.dll: splines.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:$@ $<

matrix.dll: matrix.cs
	mcs -target:library -out:$@ $<

PHONEY: clean
clean:
	rm -f *.dll *.exe Out.txt plotdata.txt *.gnuplot.svg
