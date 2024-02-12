default: Out-stdio.txt out.txt

Out-stdio.txt: stdio.exe input Makefile
	mono $< <input 1> $@ 2> log-stdio.txt
	echo "\n" >> $@
	cat input | mono $< 1>> $@ 2>> log-stdio.txt

stdio.exe: stdio.cs
	mcs -target:exe -out:$@ $<

cmdline.exe: cmdline.cs
	mcs -target:exe -out:$@ $<

out.txt: cmdline.exe input.txt
	mono cmdline.exe -input:input.txt -output:$@ -numbers:2,3.45,6
