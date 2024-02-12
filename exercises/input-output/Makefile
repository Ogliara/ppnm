out-ass1.txt: ass1.exe
	#echo "-numbers:1,2,3,4,5" > inputfile
	#mono ass1.exe $(echo inputfile) > out-ass1.txt
	mono ass1.exe -numbers:1,2,3,4,5 > $@

out-ass2.txt: ass2.exe
	mono ass2.exe $@

ass1.exe: ass1.cs
	mcs -target:exe -out:$@ $<

ass2.exe: ass2.cs
	mcs -target:exe -out:$@ $<

.PHONEY: clean
clean:
	rm -f out-ass1.txt ass1.exe out-ass2.txt ass2.exe
