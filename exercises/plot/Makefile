CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:, $(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

default: Erf.gnuplot.svg Gamma.gnuplot.svg Lngamma.gnuplot.svg

Erf.gnuplot.svg: Out.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key left;\
		set xlabel "x" ;\
		set ylabel "erf(x)" ;\
		set tics out ;\
		set grid ;\
		set title "Error function" ;\
		plot [-3:3]\
			"$<" with lines notitle \
			,"erf.data.txt" using 1:2 with points pointtype 6 notitle \
			,"erf.data.txt" using (-($$1)):(-($$2)) with points pointtype 6 notitle ;\
	' | tee log.gpi | gnuplot



Gamma.gnuplot.svg: Out2.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key left;\
		set xlabel "x" ;\
		set ylabel "gamma(x)" ;\
		set tics out ;\
		set grid ;\
		set title "Gamma function with n-1 factorials" ;\
		plot [-4.1:][-10:10]\
			"$<" with lines notitle \
			,"factorials.txt" using (($$1)+1):2 with points pointtype 6 notitle ;\
	' | tee log2.gpi | gnuplot


Lngamma.gnuplot.svg: Out3.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set key left;\
		set xlabel "x" ;\
		set ylabel "lngamma(x)" ;\
		set tics out ;\
		set grid ;\
		set title "Lngamma function" ;\
		plot [0:][-2:]\
			"$<" with lines notitle ;\
	' | tee log3.gpi | gnuplot




Out.txt: main.exe
	mono $< > $@

Out2.txt: main2.exe
	mono $< > $@

Out3.txt: main3.exe
	mono $< > $@


sfuns.dll: sfuns.cs ; $(MKLIB)
main.exe: main.cs  sfuns.dll; $(MKEXE)
main2.exe: main2.cs  sfuns.dll; $(MKEXE)
main3.exe: main3.cs  sfuns.dll; $(MKEXE)



.PHONEY: clean
clean:
	$(RM) *.exe *.dll [Oo]ut.txt *.svg log.gpi log2.gpi log3.gpi
