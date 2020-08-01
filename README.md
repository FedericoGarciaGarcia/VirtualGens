# Virtual Gens v0.1

Sega Genesis emulator *Gens KMod* running in Unity.

This project is an attempt at implementing Sega's *SEGA Genesis Classics* VR room.

![VirtualGens](https://raw.githubusercontent.com/FedericoGarciaGarcia/VirtualGens/master/Screenshots/screen1.jpg)

## Installation

1. Download the *VirtualGens* folder and copy it to a Unity project folder.
2. Add the prefab *VirtualGens* to a scene.
3. Build the Unity project for Windows 32-bit; Mac and Linux are not supported.
4. Put a Sega Genesis ROM in the build folder, where the executable is. The ROM file should be named *rom.bin*

## Use

*VirtualGens* cannot be run on the Editor, only as an application.

The application will start in fullscreen and the Sega Genesis ROM will be executed immediately. Configuration and log files will be created. For the best experience, the application should run at a minimum of 60 frames per second.

## Controls

* **Esc**: close the application.
* **Mouse**: look around.
* **W**: move forwards.
* **S**: move backwards.
* **A**: strafe left.
* **D**: strafe right.
* **Z**: press A button on the gamepad.
* **X**: press B button on the gamepad.
* **C**: press C button on the gamepad.
* **B**: press X button on the gamepad.
* **N**: press Y button on the gamepad.
* **M**: press Z button on the gamepad.
* **V**: press Start button on the gamepad.

## Description

[Gens KMod](https://segaretro.org/Gens_KMod) source code was compiled as a 32-bit DLL, *gens.dll*, with a new interface to allow communication with an application. The DLL code is run on a separate thread, and receives input from Unity. After each frame, the DLL sends the screen buffer as an array to Unity, where it is rendered to a texture. Since audio is handled directly by Gens, there is no 3D audio as of yet.

A virtual room was created with a TV where the execution of the emulator can be seen. The player can move, look around, and play the Sega Genesis with a wireless gamepad.

## Legal

* I do not condone the use of ilegally obtained roms.

## Authors

* *Virtual Gens*: [Federico Garcia Garcia](http://federicogarcia.site)
* *Gens KMod*: [Kaneda](http://gendev.spritesmind.net/page-gensK.html)
* *Furbished Cabin asset*: [Johnny Kasapi](https://assetstore.unity.com/packages/3d/environments/urban/furnished-cabin-71426)
* *Sega Genesis console model*: [niklas.glosen](https://sketchfab.com/niklas.glosen)
* *Sega Genesis gamepad model*: [Armen.Gevorgyan](https://sketchfab.com/Armen.Gevorgyan)

## Special Thanks

* [*SEGA*](https://www.sega.com)