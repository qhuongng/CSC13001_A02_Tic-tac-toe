   M S B A M L   `   `   `  ����D  @TicTacToe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TicTacToe	TicTacToe  5          TicTacToe.GameScreen   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:TicTacToe     5      -   5        $
��Auto��5      $
��Auto��6,   .��5
      ]� $
��True��6   .+�5   
   �� $	��Top=�6   $��0,0,0,5q�6&   
���   �$��0,0,0,2q�5   %   ._�5      ]� $��50��6   
�������$��False��5   ,   .+�5      �� -   5          ��Name$  BackBtn��5   /   $
��Left=�6   $|�False��5   /      ImageButtonStyle#��[  5      .��5      �� $-��'pack://application:,,,/icons/return.png��6    5      �� 5      -   5         ��Name$ CurrentPlayer��5      $
��Left=�5      $��40��6.   $��40��69   $��60,5,5,5q�6E   $|�False��5   /   �� 5      $
��Left=�6   $|�False��62   $��'s turn��5      $��Comic Sans MS)�6+   $��18(�5      $��Center=�6*   �� 5      -   5        $  HelpBtn��5   0   $��Right=�6   $|�False��5   /   #��[  5      $��20,5,5,5q�6C   .��5      �� $+��%pack://application:,,,/icons/help.png��6   5       �� 5"      -   5        $  MusicBtn��5"   0   $��Right=�6   $|�False��5#   0   #��[  5$      .��5%      �� -   5        $ 	MusicIcon��5%      $/��)pack://application:,,,/icons/music_on.png��5&      5'      �� 5)      -   5        $  SoundBtn��5)   0   $��Right=�6   $|�False��5*   0   #��[  5+      .��5,      �� -   5        $ 	SoundIcon��5,      $/��)pack://application:,,,/icons/sound_on.png��5-      5.      �� 50      -	   5        $  SaveBtn��50   0   $��Right=�6   $��5,5,15,5q�51   /   $|�False��6A   #��[  52      .��53      �� -
   5        $ SaveIcon��53      $+��%pack://application:,,,/icons/save.png��6.   54      �� 56      -   5        $  
RestartBtn��56   0   $��Right=�6   $|�False��57   +   #��[  58      .��59      �� $.��(pack://application:,,,/icons/restart.png��6   5:      5;      5<      �� 5>   
   -   5         ��Name$ 
GameCanvas��5>      
�������$��0,0,0,5q�68   $
|�True��5?   B   5@      5A      