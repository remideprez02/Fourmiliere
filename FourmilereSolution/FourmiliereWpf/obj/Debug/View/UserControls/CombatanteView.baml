   M S B A M L   `   `   `  ����I  EFourmiliereWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FourmiliereWpf.ViewModelsFourmiliereWpf.ViewModels  5      5    /FourmiliereWpf.View.UserControls.CombatanteView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =	ViewModel'clr-namespace:FourmiliereWpf.ViewModels     5      $
��Auto��5      $
��Auto��5        � 	Resources  5
       �� DataType3   -FourmiliereWpf.ViewModels.CombatanteViewModel �� Orientation��%�   (��       5      *, +)�� 6
   "  6   .R�5      �� $ 
Horizontal=�6   .+�5      �� ��6   �� *Nom+�� 5      $��0,0,10,0q�5      ��5      �� *Num+5      �� 5      ��6   �� *Vie+5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ]� $��0��6   .+�5      �� $��Recherche :��6   �� 5      $��5q�5      ��5      �� *SearchTextCombatante+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��5   !   ��5       �� 5!       �� Triggers 5"      �� 5#       �� Binding 6*   �� *!SearchContainsNoMatchCombatante+ �� Value True5$   *   a�5%   "   �� 5&   &   	 �� Property	 � ��
 �� Value
 �	#68FF00005'   -   �� 5(   &   	 �@�ToolTip$
 No result found��5)   -   5+      5-      .��5.   !   5/      50      �� 52   
   $��1��6   $ �� IsSynchronizedWithCurrentItem$
 TrueY�54      ��53      �� *Combatantes+54      A� 56   
   $��2��6    A� Columns$ 4��57      .+�58      �� $	��Add��6   ��59      �� *AddCommandCombatante+�� 5:      $��Remove��6   ��5;      �� *RemoveCommandCombatante+�� 5<      $��Previous��6   ��5=      �� *PreviousCommandCombatante+�� 5>      $
��Next��6   ��5?      �� *NextCommandCombatante+5@      5A      5B      