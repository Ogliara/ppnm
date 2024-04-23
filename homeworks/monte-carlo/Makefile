plot.gnuplot.svg: plotdata.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key right;\
		set logscale x;\
		set xlabel "N" ;\
		set ylabel "Error" ;\
		set tics out ;\
		set grid ;\
		set title "Error as Function of N" ;\
		plot \
			"$<" using 1:2 with linespoint pointtype 2 title "Estimated Error" \
			,"$<" using 1:3 with linespoint pointtype 2 title "Actual Error" ;\
	' | tee log.gpi | gnuplot

plotdata.txt: main.exe
	mono $< 1>Out.txt 2>$@

main.exe: main.cs montecarlo.dll matrix.dll
	mcs -target:exe -reference:montecarlo.dll -reference:matrix.dll -out:$@ $<

montecarlo.dll: montecarlo.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:$@ $<

matrix.dll: matrix.cs
	mcs -target:library -out:$@ $<

PHONEY: clean
clean:
	rm -f *.dll *.exe Out.txt plotdata.txt *.gnuplot.svg
