Out.txt: main.exe
	mono $< >$@

main.exe: main.cs matrix.dll splines.dll
	mcs -target:exe -reference:matrix.dll -reference:splines.dll -out:$@ $<

splines.dll: splines.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:$@ $<

matrix.dll: matrix.cs
	mcs -target:library -out:$@ $<

PHONEY: clean
clean:
	rm -f *.dll *.exe Out.txt
