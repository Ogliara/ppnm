Out.txt: main.exe
	mono $< >$@

main.exe: main.cs ann.dll matrix.dll mini.dll
	mcs -target:exe -reference:matrix.dll -reference:mini.dll -reference:ann.dll -out:$@ $<

ann.dll: ann.cs matrix.dll mini.dll
	mcs -target:library -reference:matrix.dll -reference:mini.dll -out:$@ $<

mini.dll: mini.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:$@ $<

matrix.dll: matrix.cs
	mcs -target:library -out:$@ $<

PHONEY: clean
clean:
	rm -f *.dll main.exe Out.txt
