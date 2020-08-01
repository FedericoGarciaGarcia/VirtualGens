# Virtual Gens v0.1

Sega Gensis "Gens" emulator running inside Unity in a virtual room.

This project is an attempt at implementing Sega's "SEGA Genesis Classics" VR room.

## Installation

Download the "VirtualGens" folder and import into a Unity project. Import the prefab into the editor.
Compile for Windows 32-bit; Mac and Linux are not supported.
Place a Sega Genesis ROM in the "VirtualGens" folder. The ROM file should be named "rom.bin".

## Use

Run "VirtualGens.exe". The application will start in fullscreen and the Sega Genesis ROM will be executed immediately.

Controls:
* Esc: close the application.
* Mouse: look around.
* W: move forwards.
* S: move backwards.
* A: strafe left.
* D: strafe right.
* Z: press A button on the controller.
* X: press B button on the controller.
* C: press C button on the controller.
* B: press X button on the controller.
* N: press Y button on the controller.
* M: press Z button on the controller.
* V: press Start button on the controller.

## Description

The Sega Gensis [Gens KMod](https://segaretro.org/Gens_KMod) source code was compiled as a 32-bit DLL with a new interface to allow communication from outside. Gens is run on a separate thread, and receives input from Unity. After each frame is rendered, the screen buffer is sent to Unity and rendered on a texture. Since audio is handeled directly by Gens, there is no 3D audio as of yet.

A virtual room was created, where the user can move and look around. The player carries a wireless Sega Genesis controller, animated when the user presses any button.

## Legal

I do not condone the use of ilegally obtained roms.

## Author

Federico Garcia