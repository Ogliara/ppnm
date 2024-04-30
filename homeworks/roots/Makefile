Out.txt: main.exe
	mono $< 1>$@

main.exe: main.cs roots.dll matrix.dll
	mcs -target:exe -reference:roots.dll -reference:matrix.dll -out:$@ $<

roots.dll: roots.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:$@ $<

matrix.dll: matrix.cs
	mcs -target:library -out:$@ $<

PHONEY: clean
clean:
	rm -f *.dll *.exe Out.txt *.gnuplot.svg *.gpi
