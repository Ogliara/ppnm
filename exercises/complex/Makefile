Out.txt: main.exe Makefile
	mono main.exe > Out.txt

main.exe: main.cs cmath.dll
	mcs -reference:cmath.dll -target:exe -out:main.exe main.cs

cmath.dll: cmath.cs complex.cs
	mcs -target:library -out:./cmath.dll $^

PHONEY: clean
clean:
	rm -f cmath.dll main.exe Out.txt
