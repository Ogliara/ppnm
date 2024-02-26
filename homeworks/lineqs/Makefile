MAKELIB = mcs -target:library -out:$@ $<

Out.txt: main.exe Makefile
	mono $< >$@

main.exe: main.cs matrix.dll
	mcs -target:exe -reference:matrix.dll -out:$@ $<

matrix.dll: matrix.cs
	$(MAKELIB)

PHONEY: clean
clean:
	rm -f matrix.dll main.exe Out.txt
