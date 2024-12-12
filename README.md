This WinForms app is for checking whether a file (must be xml, csv or txt) is dropped into the provided directory and writes their content into dataviewgrid.

• Used System.Windows.Forms.Timer for setting up the timer.

• Used System.IO.FileSystemWatcher for raising event when a change occurs in the directory.

• Used TPL for keeping window responsive.


How to start ?
1. First Set Path
2. Start Monitoring (also starts FileWatcher)
3. Drop new files into the directory
