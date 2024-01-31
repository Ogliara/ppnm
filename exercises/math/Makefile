Out.txt : main.exe
	mono main.exe > Out.txt

main.exe : main.cs
	mcs -out:main.exe -target:exe main.cs

.PHONEY:clean
clean:
	rm -f Out.txt main.exe
