   M S B A M L   `   `   `  ����L  HAlgoritmoGenetico, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:AlgoritmoGenetico.ConvertersAlgoritmoGenetico.Converters  5   	   "    AlgoritmoGenetico.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   >d2http://schemas.microsoft.com/expression/blend/2008    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   A
converters*clr-namespace:AlgoritmoGenetico.Converters     5   	     � Title$  Algoritmo Genético��5   	   $	��399��5	   	   $	��850��6    � Icon$ ../Resources/icon.ico��5
   	    � WindowStartupLocation$ CenterOwner=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$ SingleBorderWindow=�5   	   
������� � 	Resources 5      C   =AlgoritmoGenetico.Converters.ReverseVisibilityToBoolConverter $   ReverseVisibilityToBoolConverter7   1AlgoritmoGenetico.Converters.ReverseBoolConverter  ReverseBoolConverter<   6AlgoritmoGenetico.Converters.VisibilityToBoolConverter  VisibilityToBoolConverter��%W   &	        &	      &	 &       5   
   6a     5   
   6I     5   
   6S   5      .��5      � $��4q�6    � ColumnDefinitions 5   
   �� 5      $	��352 �6   6-   �� 5      $	��235 �6   6-   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $	��185 �6   6+   �� 5      $��* �6   6)   .+�5"   
   �� 
���   �$��1q�6%   $��0��69   $��0��6I   $	��352��6V   $��2��6c   ._�5#      �� -   5         ��Name$ Canvas��5#      6'   5$      � 5&   
   $��0��6   $��1��6   $��15, 0, 0, 0q�6,   $
��Left=�5'      $	��Top=�6.    5(      �� 5)      $	��175 �6#   61   �� 5*      $��45 �6#   60    5-      �� 5.      $��30 �6    6.   �� 5/      $��30 �6    6.   �� 50      $��30 �6    6.   �� 51      $��30 �6    6.   �� 52      $��30 �6    6.   �� 53      $��30 �6    6.   .+�56      �� $��0��6   $��0��6(   $��Taxa de Crossover��65   $
��Bold"�6N   $��
0, 5, 0 ,0q�6`   6v   �� 57      	 �� 	MaxLength$	 3��6�   
 �� TextAlignment$
 Center=�6�   $��1��6�   $��0��6�   $��22��6�   ��6   �� *CrossoverRate+{�65   �� *IsSearching+ �� 	Converter# [ 6�   �� 59      $��0��6   $��1��6(   $��Taxa de Mutação��65   $
��Bold"�6L   $��
0, 5, 0 ,0q�6^   6t   �� 5:      $	 3��6�   $
 Center=�6�   $��1��6�   $��1��6�   $��22��6�   ��6   �� *MutationRate+{�64   �� *IsSearching+# [ 6�   �� 5<      $��0��6   $��2��6(   $��Tamanho da População��65   $
��Bold"�6Q   $��
0, 5, 0 ,0q�6c   6y   �� 5=      $
 Center=�6�   $��1��6�   $��2��6�   $��22��6�   ��6   �� *PopulationSize+{�66   �� *IsSearching+# [ 6�   �� 5?      $��0��6   $��3��6(   $#��Número máximo de gerações��65   $
��Bold"�6V   $��
0, 5, 0 ,0q�6h   6~   �� 5@      $
 Center=�6�   $��1��6�   $��3��6�   $��22��6�   ��6   �� *MaxNumberOfGenerations+{�6>   �� *IsSearching+# [ 6�   �� 5B      $��0��6�   $��4��6�   $��Elitismo��6�   $
��Bold"�6�   $��
0, 5, 0 ,0q�6�    d� 	IsChecked 6   �� *ElitismEnabled+{�6<   �� *IsSearching+# [ 6�   �� 5D      $��Buscar melhor caminho��6   $��SemiBold"�5E      $��2q�6+   $��0��6?   $��2��6O   $��5��6c   
���������5D   5   �� *SearchMazePathCommand+y�6_   �� *IsSearching+# [  5E   �   �� 5G      $��Cancelar��6   $��SemiBold"�5H      $��2q�6+   $��0��6?   $��2��6O   $��5��6c   
���������5G   (   �� *CancelCommand+y�6J   �� *IsSearching+# [ 5H   �   5J      �� 5L   
   $��1��6   $��1��6    $��5 0 0 0q�60   $��Detalhes do Individuo��6A   $
��Bold"�6`   .��5M      �  5N      �� 5O      $��* �6'   63   �� 5P      $��60 �6'   64    5S      �� 5T      $��30 �6$   62   �� 5U      $��30 �6$   62   �� 5V      $��30 �6$   62   �� 5W      $��30 �6$   62   �� 5X      $��30 �6$   62   .+�5[      �� $��Geração do individuo:��6   $��0��68   $��Normal"�6E   6[   �� 5\      $��0��6J   $��1��6W   
���  ����6   �� *SelectedIndividual.Generation+6z   �� 5^      $��Aptidão do individuo:��6   $��1��68   $��Normal"�6E   6[   �� 5_      $��1��6G   $��1��6T   
���  ����6   �� *SelectedIndividual.Fitness+6w   �� 5a      $��Caminhos percorridos:��6   $��2��68   $��Normal"�6E   6[   �� 5b      $��2��6S   $��1��6`   
���  ����6   �� *(&SelectedIndividual.FieldsTraveledCount+6�   �� 5d      $��Caminhos repetidos:��6   $��3��66   $��Normal"�6C   6Y   �� 5e      $��3��6N   $��1��6[   
���  ����6   �� *#!SelectedIndividual.RepeatedFields+6~   �� 5g      $��Paredes atingidas:��6   $��4��65   $��Normal"�6B   6X   �� 5h      $��4��6H   $��1��6U   
���  ����6   �� *SelectedIndividual.WallHits+6x   5i      5j      �� 5l   
   $��0��6   $��2��6   $��2��6/   $��2q�6?   
�������$��5 0 0 0q�6k   {�6|   �� *IsSearching+# [ ._�5m      �� $
��Auto=�6   $��Disabled=�6>   
������ 
������ $��0q�5n   N   $��0q�6Z   .��5o      �� -   5         ��Name$ ItemsControl��5o      
������ $��0q�6O   ��6c   �� *BestIndividuals+��5p      �� 5q      .R�5r      �� $��1q�6%   ���#E0E0E0._�5s   "   �  5t   &   �� 5u   *   $��* �6;   6G   �� 5v   *   $
��Auto �6;   6J    5y   &   �� 5z   *   $��28 �68   6F   .+�5}   &   �� ��6-   �� *DrawIndividualCommand+��6W   �� .��5~   *   ��  �� Orientation$ 
Horizontal=�65   .+�5   .   �� $��0��64   $��0��6A   $��27��6Q   $
��Left=�6]   $��Center=�6x   $
��Bold"�6�   $��Individuo da geração:��6�   �� 5�   .   $��0��64   $��1��6A   $
��Auto��6Q   $
��Left=�6_   $��Center=�6z   $
��Bold"�5�   4   $��0, -1, 0, 0q�6e   ��6F   �� *
Generation+6e   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      