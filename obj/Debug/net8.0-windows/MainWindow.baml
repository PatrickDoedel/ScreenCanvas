   M S B A M L   `   `   `  ����G  CScreenCanvas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ScreenCanvasScreenCanvas  5   	       ScreenCanvas.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ScreenCanvas     5   	   -   5          � Title$  
MainWindow��5	   	   $��20(�5
   	   
������  � AllowsTransparency$
 True��5   	    � WindowStyle$
 None=�5   	    � WindowState$ 	Maximized=�5   	    � ContextMenu 5      �� 5   
   -   5         ��Name$ AppContextMenu��5       �� 	StaysOpen$
 true��5      .@�5      m� -   5         m�Name$ 
ExitButton��5      $
��Exit��5      5      m� 5      -   5        $ ClearButton��5      $��Clear��5      5      �� 5"      -   5         ��Name$ rainbowSlider��5"      $	��500��5#      	 � Minimum$	 0Q�5$      
 � Maximum$	
 100Q�5%       �� IsMoveToPointEnabled$
 True��5'      ��5(      �� 5)      -   5        rainbowBrush�� �� 
StartPoint$ 0,0.5&�5*   *    �� EndPoint$ 1,0.5&�5+   *   .��5,      �  � Color$	 Red��6'    � Offset$	 0.0Q�5-   '   � 5.      $ Orange��6'   $ 0.166Q�5/   '   � 50      $ Yellow��6'   $ 0.332Q�51   '   � 52      $ Green��6'   $ 0.498Q�53   '   � 54      $
 Blue��6'   $ 0.664Q�55   '   � 56      $ Indigo��6'   $ 0.830Q�57   '   � 58      $ Violet��6'   $	 1.0Q�59   '   5:      5<      5=      .��5@      � -   5         �Name$ MainGrid��5@      .+�5A   
   �� -   5        $��PaintCanvas��5A      ���	#01FFFFFF5B      5C      5D      