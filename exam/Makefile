Out.txt: main.exe
	mono $< 1>$@

main.exe: main.cs integrator.dll matrix.dll
	mcs -target:exe -reference:integrator.dll -reference:matrix.dll -out:$@ $<

integrator.dll: integrator.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:$@ $<

matrix.dll: matrix.cs
	mcs -target:library -out:$@ $<
