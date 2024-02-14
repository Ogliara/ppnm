#Takeaways: The pipe takes the output from a command (i.e. echo) and redirects it to mono to run.
#This detaches it from the keyboard, so no input is required.
#This lets us control the input without editing the cs files.
#It's very clever, and I really like how neat this setup is.
#We can also see how the contents of a file can be piped into the program this way.

Out.txt: ass1.exe ass2.exe ass3.exe Makefile
	mono ass1.exe -numbers:1,2,3,4,5 > $@
	echo 6 7 8 9 10 | mono ass2.exe 2>> $@  #double arrow so it appends instead of overriding
	mono ass3.exe -input:input.txt -output:Out.txt

ass1.exe: ass1.cs
	mcs -target:exe -out:$@ $<

ass2.exe: ass2.cs
	mcs -target:exe -out:$@ $<

ass3.exe: ass3.cs
	mcs -target:exe -out:$@ $<



.PHONEY: clean
clean:
	rm -f ass1.exe ass2.exe ass3.exe Out.txt
