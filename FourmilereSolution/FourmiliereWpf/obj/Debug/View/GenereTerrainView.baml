   M S B A M L   `   `   `  ����I  EFourmiliereWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:FourmiliereWpf.ViewFourmiliereWpf.View  5   	   +    %FourmiliereWpf.View.GenereTerrainView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:FourmiliereWpf.View     5   	   -   5          � Title$  Définition du terrain��5   	    � SizeToContent$ WidthAndHeight=�5
   	   .��5      � $��5q�6   $��Center=�6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5        $��labelX��5      $��0��5      $��Center=�5      .��6-   Nombre de lignes :6A   �� 5   
   -   5        $��X��5      $��1��5      $��Center=�5      $	��100��5      6    �� 5   
   -   5        $��labelY��5      $��2��5       $��Center=�5!      .��6-   Nombre de colonnes :6C   �� 5"   
   -   5        $��Y��5"      $��3��5#      $��Center=�5$      $	��100��5%      6    � 5'   
   $��4��6   $��10q�5(       5)      �� 5*      $��* �6#   �� 5+      $��* �6#   �� 5,      $��* �6#   .+�5.      �� -   5        $��btnDialogOk��5/       �� 	IsDefault . $��0��51      .��6%   Ok6)   �� 52      -   5        $��btnDialogCancel��53       �� IsCancel . $��2��55      .��6%   	Annuler6.   56      57      58      