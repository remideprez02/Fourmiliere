   M S B A M L   `   `   `  ����I  EFourmiliereWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FourmiliereWpf.ViewModelsFourmiliereWpf.ViewModels  5      5    /FourmiliereWpf.View.UserControls.CueilleuseView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      >
viewModels'clr-namespace:FourmiliereWpf.ViewModels     5      $
��Auto��5      $
��Auto��5        � 	Resources  5       �� DataType3   -FourmiliereWpf.ViewModels.CueilleuseViewModel �� Orientation��%�   (��       5	      *, +)�� 6
   "  6   .R�5
      �� $ 
Horizontal=�6   .+�5      �� ��6   �� *Nom+�� 5      $��0,0,10,0q�5      ��5      �� *Num+5      �� 5      ��6   �� *Vie+5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ]� $��0��6   .+�5      �� $��Recherche :��6   �� 5      $��5q�5      ��5      �� *SearchTextCueilleuse+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��5   !   ��5      �� 5       �� Triggers 5       �� 5!       �� Binding 6*   �� *!SearchContainsNoMatchCueilleuse+ �� Value True5"   *   a�5#   "   �� 5$   &   	 �� Property	 � ��
 �� Value
 �	#68FF00005%   -   �� 5&   &   	 �@�ToolTip$
 No result found��5'   -   5)      5+      .��5,   !   5-      5.      �� 50   
   $��1��6   $ �� IsSynchronizedWithCurrentItem$
 TrueY�52      ��51      �� *Cueilleuses+52      A� 54   
   $��2��6    A� Columns$ 4��55      .+�56      �� $	��Add��6   ��57      �� *AddCommandCueilleuse+�� 58      $��Remove��6   ��59      �� *RemoveCommandCueilleuse+�� 5:      $��Previous��6   ��5;      �� *PreviousCommandCueilleuse+�� 5<      $
��Next��6   ��5=      �� *NextCommandCueilleuse+5>      5?      5@      