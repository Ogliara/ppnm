default: fit.gnuplot.svg fit_vals.txt

fit.gnuplot.svg: fit_vals.txt
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key right;\
		set xlabel "x" ;\
		set ylabel "ln(y)" ;\
		set tics out ;\
		set grid ;\
		set title "Fit" ;\
		plot \
			"$<" using 1:2:3 with errorbars title "Data" \
			,"$<" using 1:4 with lines title "Fit" ;\
	' | tee log.gpi | gnuplot

fit_vals.txt: main.exe
	rm -f fit_vals.txt
	mono $< -input:data.txt -output:fit_vals.txt !>Out.txt

main.exe: main.cs matrix.dll ls.dll
	mcs -target:exe -reference:matrix.dll -reference:ls.dll -out:$@ $<

ls.dll: leastsquares.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:$@ $<

matrix.dll: matrix.cs
	mcs -target:library -out:$@ $<

PHONEY: clean
clean:
	rm -f *.dll *.exe fit_vals.txt fit.gnuplot.svg log.gpi Out.txt

