default: solution.gnuplot.svg oscillator.gnuplot.svg lotkavolterra.gnuplot.svg

solution.gnuplot.svg: solution.txt main.exe Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key right ;\
		set xlabel "x" ;\
		set ylabel "y" ;\
		set tics out ;\
		set grid ;\
		set title "Solution" ;\
		plot \
			"$<" using 1:2 with lines title "u(x)" \
			,"$<" using 1:3 with lines title "u(x) derived" ;\
	' | gnuplot

oscillator.gnuplot.svg: main.exe Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key right ;\
		set xlabel "t" ;\
		set ylabel "y" ;\
		set tics out ;\
		set grid ;\
		set title "Oscillator" ;\
		plot \
			"oscillator.txt" using 1:2 with lines title "theta(t)" \
			,"oscillator.txt" using 1:3 with lines title "omega(t)" ;\
	' | gnuplot

lotkavolterra.gnuplot.svg: main.exe Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key right ;\
		set xlabel "t" ;\
		set ylabel "y" ;\
		set tics out ;\
		set grid ;\
		set title "Lotka Volterra" ;\
		plot \
			"lokvol.txt" using 1:2 with lines title "x(t)" \
			,"lokvol.txt" using 1:3 with lines title "y(t)" ;\
	' | gnuplot

solution.txt: main.exe
	mono $< -output:oscillator.txt -output:lokvol.txt 1>Out.txt 2>$@

main.exe: main.cs ode.dll matrix.dll
	mcs -target:exe -reference:matrix.dll -reference:ode.dll -out:$@ $<

ode.dll: ode.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:$@ $<

matrix.dll: matrix.cs
	mcs -target:library -out:$@ $<

PHONEY: clean
clean:
	rm -f *.dll *.exe *.txt *.gnuplot.svg
