   M S B A M L   `   `   `  ����D  @TicTacToe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TicTacToe	TicTacToe  5          TicTacToe.BoardSizeDialog   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:TicTacToe     5      $
��Auto��5      $
��Auto��6     � 	Resources  5
      #   TicTacToe.BoardSizeRestrictor   SizeRestrictor��%   &	          5   
   6$   5      .��5      � ��5   
   �� 5       �� Color$ #000000��6    �� Opacity$	 0.3Q�6.   .+�5   
   �� $	��320��6   $	��220��6   
�������
���   �$��2q�5      ._�5      ��  �� Orientation$ Vertical=�6   .+�5      �� $��Board dimensions��6   $��SemiBold"�64   $��Comic Sans MS)�5      $��22(�67   $��Center=�5      $��	0,10,0,20q�69   � 5      $��30,20,30,20q�6    � ColumnDefinitions 5      �� 5      6-   �� 5      6-   �� 5      6-   �� 5      6-   .+�5"      �� -   5         ��Name$ RowTxtInput��5"   .   $��0��6   $��12��6C    �� TextAlignment$ Center=�5$      $��0,0,10,0q�65   �� 5&      $��1��6    $��rows ×��60   $��18(�5'       $��Comic Sans MS)�6.   $��Center=�5(       �� 5*      -   5        $ ColTxtInput��5*   .   $��2��6   $��12��6C   $ Center=�5,      $��0,0,10,0q�65   �� 5.      $��3��6    $��columns��60   $��18(�5/       $��Comic Sans MS)�6.   $��Center=�50       51      ]� 53      $��False��6   $��	0,20,0,10q�62   $	��180��6E   .+�54      �� -   5         ��Name$ 	CancelBtn��54   3   $
��Left=�6   $��Cancel��6F   $��80��6W     TextButtonStyle#��[ 55      6F   �� 57      -   5        $ PlayBtn��57   4   $��Right=�6   $
��Play��6E   $��80��6T   #��[ 58      {�59      `� 5:       `� 	Converter# [  6+   .1�5;   "   �� 	 �� ElementName$	 RowTxtInput��6*   
 �� Path$

 Text�6D   �� 5<   "   $	 ColTxtInput��6*   $

 Text�6D   5=      5?      5@      5B      5C      5D      5E      