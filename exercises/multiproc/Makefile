TIME = time --output=$@ --append --format "$$nthreads %e %U"


#Out.txt: main.exe Makefile
#	mono $< -nterms:2e8 -nthreads:4 >$@


Out.times.svg: out.times.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		plot  "$<" with lp ;\
		' | tee log-gpi | gnuplot

N = 2e8
out.times.txt: main.exe Makefile
	>$@
	for nthreads in 1 2 3 4 5 6 7 8 9; do\
		$(TIME) mono main.exe -nthreads:$$nthreads -nterms:$(N); \
	done

main.exe: main.cs
	mcs -target:exe -out:$@ $<

test: out1 out2 out3 out4 Makefile
out1: main.exe
	mono $< -nthreads:1 -nterms:2e8
out2: main.exe
	mono $< -nthreads:1 -nterms:2e8
out3: main.exe
	mono $< -nthreads:1 -nterms:2e8
out4: main.exe
	mono $< -nthreads:1 -nterms:2e8

test2: main.exe
	mono $< -nthreads:1 -nterms:2e8 > out1 $
	mono $< -nthreads:1 -nterms:2e8 > out2 $
	mono $< -nthreads:1 -nterms:2e8 > out3 $
	mono $< -nthreads:1 -nterms:2e8 > out4 $


.PHONEY: clean
clean:
	$(RM) *.exe [Oo]ut* [Ll]og*
