   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.Window1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDEsign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	    � Title$ Window1��5   	   $	��550��6   $	��800��6&    � WindowStyle$
 None=�62    � AllowsTransparency . '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 34Q�6   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6    60   �� 5      .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ Inverted=�5   !   $��10q�5   !   $��0��5      ���	#FF673AB7.��5      ]� 	   IsHitTestVisibleInChrome	 . .+�5      �� 
 �� Orientation$
 
Horizontal=�5      .+�5      �� -   5         & "MaterialDesignFloatingActionButton#���  5    "   $��30��6_   $��30��6j   .��5!      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ArrowBackCircle=�62   $��20��6I   $��20��6T   5"      �� 5#      $��Center=�5$   %   $��16 0 0 0q�5%   )   Recipes App5'      5(      �� 5)      -   5        $��close��5)   �   $��Right=�6   $��Right=�60   #���  6M   $
��Auto��6�   $
��Auto��6�   $��5,0,5,0q�6�   $��4q�6�   .��5*        $ WindowClose=�6.   $��20��6A   $��20��6L   5+      �� 5,      -   5        $��	maximized��5,   �   $��Right=�6   $��Right=�60   #���  6M   $
��Auto��6�   $
��Auto��6�   $��5,0,5,0q�6�   $��4q�6�   .��5-        $ WindowMaximize=�6.   $��20��6D   $��20��6O   5.      �� 5/      -   5        $��	minimized��5/   �   $��Right=�6   $��Right=�60   #���  6M   $
��Auto��6�   $
��Auto��6�   $��5,0,5,0q�6�   $��4q�6�   .��50        $ WindowMinimize=�6.   $��20��6D   $��20��6O   51      52      53      �� 54   
   -   5        $��scroll��54   $   $��1��6   ��. $��10q�6J   .��55      � -   5         �Name$
 wrap��55   1    � Orientation$ 
Horizontal=�6   57      58      59      5:      