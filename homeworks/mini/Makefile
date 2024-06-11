Out.txt: main.exe
	mono $< >$@

main.exe: main.cs mini.dll matrix.dll
	mcs -target:exe -reference:mini.dll -reference:matrix.dll -out:$@ $<

mini.dll: mini.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:$@ $<

matrix.dll: matrix.cs
	mcs -target:library -out:$@ $<
