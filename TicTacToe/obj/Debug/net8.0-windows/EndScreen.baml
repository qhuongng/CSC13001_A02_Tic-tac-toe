   M S B A M L   `   `   `  ����D  @TicTacToe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TicTacToe	TicTacToe  5          TicTacToe.EndScreen   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:TicTacToe     5      $
��Auto��5      $
��Auto��6   .��5      � ��5   
   �� 5        �� Color$  #000000��6    �� Opacity$	 0.3Q�6.   .+�5   
   �� $	��320��6   $	��220��6   
�������
���   �$��2q�5      ._�5      ��  �� Orientation$ Vertical=�6   .+�5      �� $ 
Horizontal=�6   $��Center=�5      $��	0,25,0,20q�6:   .+�5      �� $
��GAME��6    $
��Bold"�6,   $��Comic Sans MS)�5       $��36(�6;   
���  ��$��0,0,10,0q�5       �� 5      $
��OVER��6    $
��Bold"�6,   $��Comic Sans MS)�5       $��36(�6;   
����  �6I   5      � 5      .+�5       �� -   5         ��Name$ WinMsg��5    !   $ 
Horizontal=�61   $��Center=�6J   .+�5!      �� -   5         ��Name$ 
WinnerIcon��5!       $��30��64   $��30��6?   $��0,0,10,0q�5"       �� 5#      $��won! Congrats!��6$   $��18(�6:   $��Comic Sans MS)�5$   $   5%      �� 5'      -   5         ��Name$ TieMsg��5'       $��No one can win...��60   $��18(�6I   $��Comic Sans MS)�5(       $��Center=�6;   $y�	Collapsed=�6X   5)      ]� 5+      $��False��6   $��	0,20,0,10q�62   $	��180��6E   .+�5,      �� -   5         ��Name$ MenuBtn��5,   3   $
��Left=�6   $
��Menu��6D   $��80��6S      TextButtonStyle#��[  5-      6F   �� 5/      -   5        $ OkBtn��5/   4   $��Right=�6   $��OK��6C   $��80��6P   #��[  50      6F   51      53      54      55      56      