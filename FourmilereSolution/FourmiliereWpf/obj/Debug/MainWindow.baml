   M S B A M L   `   `   `  ����I  EFourmiliereWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:FourmiliereWpf.View.UserControls FourmiliereWpf.View.UserControls  5   	   c6clr-namespace:FourmiliereWpf.View.UserControls.Details(FourmiliereWpf.View.UserControls.Details  5   	       FourmiliereWpf.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?view.clr-namespace:FourmiliereWpf.View.UserControls     5   	   Jdetails6clr-namespace:FourmiliereWpf.View.UserControls.Details     5   	     � Title$  
MainWindow��5	   	    � WindowState$ 	Maximized=�5
   	    � 
ResizeMode$ CanMinimize=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��* �6   6*    � ColumnDefinitions 5   
   �� 5      $
��0.7* �6   �� 5      $
��1.5* �6   .+�5   
   �� -   5         ��Name$ TabControlView��5      $��0��5      .@�5      �� -   5         ��Name$ TabItemMenu��5      $
��auto��5      $
��auto��5      $
��Menu��5      .��5      �  5      �� 5      $
��Auto �6(   �� 5       $��* �6(   �� 5!      $
��Auto �6(   .+�5$      �  5%      �� 5&      $��* �6,   69   �� 5'      $��* �6,   69   �� 5(      $��* �6,   69   �� 5)      $��* �6,   69   �� 5*      $��* �6,   69    5,      �� 5-      $��* �6/   .+�5/      �� -   5        $��0��5/   !   $��10q�50   !   .��51   5   Générer le plateau6I   �� 52      -   5         ��Name$ BtnLancerSimu��52   !   $��1��53   !   $��10q�54   !   {�.  .��56   4   Lancer la simulation6J   �� 57      -   5        $ BtnSave��5:   !   $��2��57   !   $��10q�59   !   {�.  .��5;   3   Sauvegarder6@   �� 5<      -   5        $��3��5<   !   $��10q�5>   !   .��6-   
A propos67   �� 5?      -   5        $��4��5?   !   $��10q�5A   !   .��6-   	Quitter66   5C      5D      5E      �� 5F      -   5        $ TabItemFourmi��5F      $
��auto��5G      $
��auto��5H      $��Liste Fourmis��5I      .��5J      1   +FourmiliereWpf.View.UserControls.FourmiView  -	   5          Name$ 
FourmiView��5J   "   $��0��5K   "   5L      �� 5M      -
   5        $ TabItemCombatante��5M      $
��auto��5N      $
��auto��5O      $��Liste Combatantes��5P      .��5Q      5   /FourmiliereWpf.View.UserControls.CombatanteView  -   5        	  Name$	 CombatanteView��5Q   &   $��0��5R   &   5S      �� 5T      -   5        $ TabItemCueilleuse��5T      $
��auto��5U      $
��auto��5V      $��Liste Cueilleuses��5W      .��5X      5   /FourmiliereWpf.View.UserControls.CueilleuseView  -   5        
  Name$
 CueilleuseView��5X   &   $��0��5Y   &   5Z      5]      ?   9FourmiliereWpf.View.UserControls.Details.DetailFourmiView  5^   
   -   5          Name$ DetailFourmiView��5^   #   $��0��5_   #   $��1��5`   #   $��Center=�5a   #   5b      C   =FourmiliereWpf.View.UserControls.Details.DetailCombatanteView  5c   
   -   5          Name$ DetailCombatanteView��5c   '   $��0��5d   '   $��1��5e   '   $��Center=�5f   '   5g      C   =FourmiliereWpf.View.UserControls.Details.DetailCueilleuseView  5h   
   -   5          Name$ DetailCueilleuseView��5h   '   $��0��5i   '   $��1��5j   '   $��Center=�5k   '   5l      � 5m   
   -   5        $��Plateau��5n      $��0��5m       � ShowGridLines . $��1��5p      $��2��5q      
�������5r   (   5s      5t      