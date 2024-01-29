Out.txt : hello.exe         # Out.txt depends on bytecode executable hello.exe
	mono hello.exe > Out.txt  # run hello.exe in mono, redirect output into Out.txt

hello.exe : hello.cs           # bytecode hello.exe depends on source-code hello.cs
	mcs -out:hello.exe hello.cs   # compile hello.cs, output goes to hello.exe

.PHONEY:clean           # clean is a phoney target
clean:                  # does not depend on anything
	rm --force Out.txt hello.exe # remove the files produced by making
