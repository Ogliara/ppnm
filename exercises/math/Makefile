Out.txt : main.exe
	mono $< > $@  #This syntax is used to avoid typing things multiple time. #mono main.exe > Out.txt, otherwise.

main.exe : main.cs sfunc.dll
	mcs -out:main.exe -target:exe main.cs -reference:sfunc.dll

sfunc.dll : sfunc.cs
	mcs -target:library -out:sfunc.dll sfunc.cs


.PHONEY:clean
clean:
	rm -f Out.txt main.exe sfunc.dll
