# WPF Generalized Tic-tac-toe Game

This is an assignment from the course **CSC13001 – Windows Programming (21KTPM2)** at VNU-HCM, University of Science.

## General information
This is a simple implementation of a multiplayer [m,n,k-game](https://en.wikipedia.org/wiki/M,n,k-game), with a fixed `k` of $5$ and customizable `m` and `n` values. It includes an algorithm that can detect whether there remains any possible move for either player to win. Players can play using either mouse or keyboard, as well as save unfinished games and load them from a list.

#### Credits for background music used in the game:
- Main theme: *Super Mario: World (SNES) End Theme*
- Game-over theme: *Wii Shop Channel Theme*

## Demo
The demo video for this application is available on [YouTube](https://youtu.be/gdkQVo9UXRM) (in Vietnamese). Due to the assignment's requirements, the game saving and loading system in the demo was modified to use Window's native Save and Open File dialogs. The source code in this repository uses custom save and load dialogs.

## Build & run the application locally
### Running the pre-built executable file
[**.NET Desktop Runtime 8.0 and above**](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) is required to run the executable file.

1. 1. Clone this repository to your local machine.
[**Microsoft Visual Studio**](https://visualstudio.microsoft.com/vs/community/) with C# and .NET development packages installed are required to build and run the project.

1. Clone this repository to your local machine and unzip the **images** folder.

2. Open the **db.sql** file, bulk replace the paths to the image files with your own paths and run the script. \
    *Example: consider this SQL script for inserting an entry into the Actor table:*
    ```
    INSERT INTO Actor (actorName, avatar, shotDes)
    VALUES (N'Tuấn Trần',
            (SELECT BulkColumn FROM OPENROWSET(BULK 'C:\Users\Caffeine\Desktop\cineImgData\tuấn trần.jpg', SINGLE_BLOB) AS Avatar),
		    N'Diễn viên điện ảnh, người mẫu. Nổi tiếng với các vai diễn trong phim "Bố Già", "Hồn Papa Da Con Gái", "Gái Già Lắm Chiêu V".')
    ```
    *Highlight `C:\Users\Caffeine\Desktop\cineImgData`, press **Ctrl + H** to open the replace menu, put your actual path to the **images** folder in the bottom field, and press **Alt + A** or choose **Replace all**.* 

3. Open the solution file in Visual Studio, open the NuGet Package Manager and run the scaffold script:
    ```
    Scaffold-DbContext "Data Source=<YOUR_SERVER_NAME>;Initial Catalog=cinemaManagement;User ID=<YOUR_USER_ID>;Password=<YOUR_PASSWORD>;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force
    ```
4. Build and run the project.
