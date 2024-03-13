fit.gnuplot.svg: Out.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key right;\
		set xlabel "x" ;\
		set ylabel "y" ;\
		set tics out ;\
		set grid ;\
		set title "Fit" ;\
		plot \
			"$<" using 1:2:3 with errorbars title "Data" \
			,"$<" using 1:4 with lines title "Fit" ;\
	' | tee log.gpi | gnuplot


Out.txt: main.exe
	rm -f Out.txt
	mono $< -input:data.txt -output:Out.txt

main.exe: main.cs matrix.dll
	mcs -target:exe -reference:matrix.dll -out:$@ $<

matrix.dll: matrix.cs #Note: The matrix.cs here is a copy from /eigen. Merge later.
	mcs -target:library -out:$@ $<

PHONEY: clean
clean:
	rm -f matrix.dll main.exe Out.txt fit.gnuplot.svg

