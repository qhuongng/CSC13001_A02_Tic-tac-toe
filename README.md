# WPF Generalized Tic-tac-toe Game

This is an assignment from the course **CSC13001 – Windows Programming (21KTPM2)** at VNU-HCM, University of Science.

## General information
This is a simple implementation of a multiplayer [m,n,k-game](https://en.wikipedia.org/wiki/M,n,k-game), with a fixed `k` of $5$ and customizable `m` and `n` values. It includes an algorithm that can detect whether there remains any possible move for either player to win. Players can play using either mouse or keyboard, as well as save unfinished games and load them from a list.

Features to consider for further development include a single-player mode against an AI.

#### Credits for background music used in the game:
- Main theme: *Super Mario: World (SNES) End Theme*
- Game-over theme: *Wii Shop Channel Theme*

## Demo
The demo video for this application is available on [YouTube](https://youtu.be/gdkQVo9UXRM) (in Vietnamese). Due to the assignment's requirements, the game saving and loading system in the demo was modified to use Window's native Save and Open File dialogs. The source code in this repository uses custom save and load dialogs.

## Build & run the application locally
[**Microsoft Visual Studio**](https://visualstudio.microsoft.com/vs/community/) with C# and .NET development packages installed are required to build and run the project source code.

1. Clone this repository to your local machine.

2. Open the solution file in Visual Studio.

3. Build and run the project.

**Note:** If you move the contents of the **TicTacToe/bin/Debug/net8.0-windows** folder elsewhere, you can still run the app without building it in Visual Studio by running **TicTacToe.exe**, as long as all the content in the aforementioned folder is in the same directory at the time of execution, and [**.NET Desktop Runtime 8.0 or above**](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) is installed.
