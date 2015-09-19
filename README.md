# PBrickIcons
Windows Device Icons for Programmable Bricks

This is a small program for Windows that adds pretty icons so that when you
plug in your LEGO® MINDSTORMS NXT or EV3 or your WeDo USB Hub, it will display
in the *Printers and Devices* window in the *Control Panel*.

![Demo 1][demo1]

## Installation

* Download the latest [release].
* Unzip the `.zip` file.
* Run the `PBrickInstaller.msi` file.
* Read notes below.

## Notes

* After installing or uninstalling, you will have to manually remove any
  existing devices and reinstall them to get the correct icons. To do this,
  plug in the device so that it appears in *Printers and Devices*. Then right-
  click on it and select *Remove*. Finally, physically unplug the device and
  plug it in again.
* Only works when plugged in via USB. It does **not** work when connecting via
  bluetooth (and for technical reasons, it is not possible to add support for
  bluetooth).
* Works on Windows 7 or higher only.

[demo1]: ./demo1.png
[release]: https://github.com/ev3dev/PBrickIcons/releases

