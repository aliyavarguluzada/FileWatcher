#########
This WinForm app is for checking whether a file (must be xml, csv or txt) is dropped into the provided directory.
Used System.Windows.Forms.Timer for setting up the timer 
Used System.IO.FileSystemWatcher for raising event when a change in directory occurs
Used TPL for keeping window responsive 


How to start ?
1. First Set Path
2. Start Monitoring (also starts FileWatcher)
3. Drop new files into the directory
