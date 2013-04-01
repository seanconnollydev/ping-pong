ping-pong
=========

A simple C# program that uses threads to alternate display of the words "ping" and "pong".

Instructions
==========

You are to design a simple C# program where you create two threads, Ping and Pong, to alternately display “Ping” and “Pong” respectively on the console.  The program should create output that looks like this: 
 Ready… Set… Go!

Ping!
Pong!
Ping!
Pong!
Ping!
Pong!
Done!

 It is up to you to determine how to ensure that the two threads alternate printing on the console, and how to ensure that the main thread waits until they are finished to print: “Done!”  The order does not matter (it could start with "Ping!" or "Pong!").

 Consider using any of the following concepts discussed in the videos:

·      wait() and notify()

·      Semaphores

·      Mutexes

·      Locks

Please design this program using the .NET framework 3.5 or higher (and no special libraries except System.Threading) and contain the code in a single file.  Someone should be able to compile it like "csc /out:program.exe program.cs"  and execute it with './program.exe' and your program should successfully run! Please add the used C# compiler version and framework you used as a comment into the source code.  
For information on installing the latest IDE onto your computer please see:
http://www.microsoft.com/visualstudio/eng/products/visual-studio-express-for-windows-desktop
(also, please note that this is a 1-month free trial!)
