default: Out_example.txt out_tablereader.txt

Out_example.txt: example.exe Makefile
	mono $< 1> Out_example.txt 2>log

out_tablereader.txt: tablereader.exe inputfile.txt Makefile
	cat inputfile.txt | mono tablereader.exe 1> $@


example.exe: example.cs genlist.dll
	mcs -out:$@ -target:exe -reference:genlist.dll example.cs

tablereader.exe: tablereader.cs genlist.dll
	mcs -out:$@ -target:exe -reference:genlist.dll tablereader.cs

genlist.dll: genlist.cs
	mcs -out:$@ -target:library genlist.cs


.PHONEY: clean
clean:
	$(RM) genlist.dll *.exe log* [Oo]ut*
