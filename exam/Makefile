declipping.gnuplot.svg: plotdata.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key right;\
		set xlabel "x" ;\
		set ylabel "y" ;\
		set tics out ;\
		set grid ;\
		set title "Declipping" ;\
		plot \
			"$<" using 1:2 title "Clipped signal" \
			,"$<" using 1:3 with lines title "Declipped signal" ;\
	' | tee log.gpi | gnuplot

plotdata.txt: main.exe
	mono $< 1>Out.txt 2>$@

main.exe: main.cs matrix.dll ls.dll
	mcs -target:exe -reference:matrix.dll -reference:ls.dll -out:$@ $<

ls.dll: leastsquares.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:$@ $<

mini.dll: mini.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:$@ $<

matrix.dll: matrix.cs
	mcs -target:library -out:$@ $<

PHONEY: clean
clean:
	rm -f *.dll main.exe Out.txt plotdata.txt *.gnuplot.svg log.gpi
