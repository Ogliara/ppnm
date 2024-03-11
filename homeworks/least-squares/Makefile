Out.txt: main.exe Makefile
	mono $< -input:data.txt -output:Out.txt

main.exe: main.cs
	mcs -target:exe -reference:matrix.dll -out:$@ $<

matrix.dll: matrix.cs #Note: The matrix.cs here is a copy from /eigen. Merge later.
	mcs -target:library -out:$@ $<

PHONEY: clean
clean:
	rm -f matrix.dll main.exe Out.txt
