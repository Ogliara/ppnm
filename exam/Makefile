Out.txt: main.exe
	mono $< 1>$@

main.exe: main.cs matrix.dll ls.dll
	mcs -target:exe -reference:matrix.dll -reference:ls.dll -out:$@ $<

ls.dll: leastsquares.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:$@ $<

mini.dll: mini.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:$@ $<

matrix.dll: matrix.cs
	mcs -target:library -out:$@ $<

PHONEY: clean
clean:
	rm -f *.dll main.exe Out.txt
