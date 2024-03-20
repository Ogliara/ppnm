splines.gnuplot.svg: plotdata.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key right ;\
		set xlabel "x" ;\
		set ylabel "y" ;\
		set tics out ;\
		set grid ;\
		set title "Splines" ;\
		plot \
			"$<" using 1:2 title "Data" \
			,"$<" using 1:3 with lines title "Linear Splines" \
			,"$<" using 1:4 with lines title "Linear Anti-Derivative" ;\
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
	rm -f *.dll *.exe Out.txt plotdata.txt splines.gnuplot.svg
