   M S B A M L   `   `   `  ����A  =FA.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:FA.WPFFA.WPF  5   	   F BPieControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:PieControls;assembly=PieControlsPieControls 5   	   1clr-namespace:FA.WPF.ControlsFA.WPF.Controls  5   	       FA.WPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:FA.WPF     5   	   >pie.clr-namespace:PieControls;assembly=PieControls     5   	   2Controlsclr-namespace:FA.WPF.Controls     5   	     � Title$   Beslist.nl - Feed Analyzer��5
   	   $��706.029��6,   $��857.153��6=   .��5      � .+�5   
   �� -   5         ��Name$ 
tabControl��5      $
��Left=�6)   $��	13,80,0,0q�6D   $	��Top=�6W    J� RenderTransformOrigin$ 0.5,0.5&�6o   $	��586��6�   $	��825��6�   $y�Visible=�6�   z�5      V� 5      .~�5      �� �� 5       �� AngleX$ 0.505Q�6$   �� 5      T� 5       T� X$ -0.983Q�6)   5      .@�5      �� -   5         ��Name$ 
PieTabItem��5      $��	Pie chart��6*   {�.  .��5        PieControls.PieChart  -   5          Name$ chart1��5   0   $��1��6    $	��380��6@   $	��340��6L      PieWidth$	 330Q�6Y      	PieHeight$	 330Q�6h   $��5,5,5,15q�6x   $
��Left=�6�   5      �� 5      -   5        $ GridTabItem��5      $
��Grid��6+   {�.  .��5      )   #FA.WPF.Controls.ProductsGridControl  -   5        	  Name$	 ProductsGridCtrl��5   /   $
��Auto��6I   $
��Auto��6W   5      �� 5      -   5        $ BarCharItem��5      $��	Bar chart��6+   5      �� 5   
   -   5        
 ��Name$
 BtnSelectFeed��5      $��Kies feedbestand��6(   $
��Left=�6C   $��	10,10,0,0q�6^   $	��Top=�6q   $	��121��6�   6�   �� 5    
   -   5         ��Name$ 
TxtCSVPath��5       $
��Left=�6&   $��20��6A   $��
136,10,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $$��Geen CSV bestand geselecteerd.��6u   $	��Top=�6�   $	��703��6�   A� 5!   
   -	   5         A�Name$ EllipseStatus��5!      
���  ��$
��Left=�64   $��16��6O   $��	10,40,0,0q�6[   
���   �$	��Top=�6}   $��16��6�    J� OpacityMask
 �   �6�   �� 5"   
   -
   5         ��Name$ LblFileStatus��5"      $��Bestand nog niet geladen.��6'   $
��Left=�6K   $��	31,35,0,0q�6f   $	��Top=�6y   $	��476��6�   $��49��6�   5#      5$      