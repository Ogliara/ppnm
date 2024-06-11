ann.dll: ann.cs matrix.dll mini.dll
	mcs -target:library -reference:matrix.dll -reference:mini.dll -out:$@ $<

mini.dll: mini.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:$@ $<

matrix.dll: matrix.cs
	mcs -target:library -out:$@ $<
