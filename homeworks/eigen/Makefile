Out.txt: main.exe Makefile
	mono $< >$@

main.exe: main.cs jacobi.dll
	mcs -target:exe -reference:jacobi.dll -reference:matrix.dll -out:$@ $<

jacobi.dll: jacobi.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:$@ $<

matrix.dll: matrix.cs #Note: Updated matrix.cs to version 12.06.2024.
	mcs -target:library -out:$@ $<

PHONEY: clean
clean:
	rm -f matrix.dll jacobi.dll main.exe Out.txt
