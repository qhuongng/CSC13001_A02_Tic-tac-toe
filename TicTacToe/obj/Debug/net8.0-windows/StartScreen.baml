   M S B A M L   `   `   `  ����D  @TicTacToe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TicTacToe	TicTacToe  5          TicTacToe.StartScreen   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:TicTacToe     5      .��5	      �   � RowDefinitions  5
   
   �� 5      6   �� 5      $��50 �6   6*   .+�5   
   � $��0��6   $��
60,40,60,0q�6     5      �� 5      6"   �� 5      6"   .+�5      �� $��0��6   $��Center=�6&   $��Center=�5       �� Orientation$ 
Horizontal=�66   .+�5      �� $��C��6   
���  ��$	��130(�5      $
��Bold"�6+   $��Comic Sans MS)�5      �� 5      $��a��6   
����  �$	��130(�5      $
��Bold"�6+   $��Comic Sans MS)�5      �� 5      $��r��6   
���  ��$	��130(�5      $
��Bold"�6+   $��Comic Sans MS)�5      �� 5       $��o��6   
����  �$	��130(�5!      $
��Bold"�6+   $��Comic Sans MS)�5"      5#      �� 5%      $��1��6   $��Center=�6"   ._�5&      �� $	��200��6   $ Vertical=�6-   .+�5'      �� -   5         ��Name$ NewBtn��5'      $��New game��6-   $��0,0,0,20q�6@      TextButtonStyle#��[  5(      6F   �� 5*      -   5        $ LoadBtn��5*      $��	Load game��6.   $��0,0,0,20q�6B   #��[  5+      6F   �� 5-      -   5        $ QuitBtn��5-      $
��Quit��6.   #��[  5.      6F   5/      50      51      �� 53   
   -   5        $ MusicBtn��54      $��1��53      $��Right=�6     ImageButtonStyle#��[ 55      .��56      �� -   5         ��Name$ 	MusicIcon��56      $/��)pack://application:,,,/icons/music_on.png��57      58      59      5:      