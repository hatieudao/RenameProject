   M S B A M L   `   `   `  ����H  DRenameProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RenameProjectRenameProject  5   	       RenameProject.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:RenameProject     5   	   -   5          � Title$  
MainWindow��5	   	   $	��500��6   $
��1000��6)    � 	Resources 5
      %  RenameProject.RuleNameConverter   RuleNameConverter%  RenameProject.ArgumentConverter  ArgumentConverter��%:   &	        &	        5   
   6"     5   
   6"   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��85 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��0��6,   $��0 0 0 0q�69   .+�5      `� .�5      c� .@�5      �� $ 
Horizontal=�6!   .+�5      �� -   5        $��RefreshButton��5   �     MyButton#��[ 6!   $��20��6C   $��8,0,10,0q�6O   $��Center=�6a   $��Center=�6|   .��5      �� $ 
Horizontal=�6)   $��Center=�6B   $��Center=�6]   .+�5   "   �� $��/Images/refresh.png��6(   $��16��6E   $��16��6Q    �� BitmapScalingMode$ HighQuality=�6\   �� 5   "   $�� Refresh��6,   $��12(�6<   6L   5      5      �� 5       #��[ 6!   $��20��6C   $��5,0,10,0q�6O   $��Center=�6a   $��Center=�6~   .��5!      �� $ 
Horizontal=�6)   $��Center=�6B   $��Center=�6]   .+�5"   "   �� $��/Images/help.png��6(   $��16��6B   $��16��6N   $ HighQuality=�6Y   �� 5#   "   $�� Help��6,   $��12(�69   6I   5$      5%      �� 5&      -   5        $��StartBatchButton��5&   �   #��[ 6!   $��20��6C   $��5,0,10,0q�6O   $��Center=�6a   $��Center=�6~   .��5'      �� $ 
Horizontal=�6)   $��Center=�6B   $��Center=�6]   .+�5(   "   �� $��/Images/start.png��6(   $��16��6C   $��16��6O   $ HighQuality=�6Z   �� 5)   "   $�� START BATCH��6,   $��12(�6@   6P   5*      5+      5,      5-      5.      `� 5/      .�50      c� -   5         c�Name$ 	MethodBar��50      $��30��6-   
�������.@�51      �� $ 
Horizontal=�6!   .+�52      �� $��Method: ��6    �� 53      -   5        $��actionCombobox��53   /   $	��125��6#   $��20��6E   ��54      �� 55   "   .R�56   &   �� ��60   �� *	Details+ �� 	Converter# [  57   #   59      �� 5:      -   5        $��AddMethodButton��5:   T   #��[ 6!   $��5,0,7,0q�6C   .��5;      �� $ 
Horizontal=�6)   .+�5<   "   �� $$��/Images/icons8-add-file-64.png��6(   $��20��6P   $��20��6\   �� 5=   "   $��
Add method��6,   5>      5?      �� 5@      -   5        $��DeleteButotn��5@   T   #��[ 6!   $��0,0,7,0q�6C   .��5A      �� $ 
Horizontal=�6)   .+�5B   "   �� $+��%/Images/icons8-delete-database-48.png��6(   $��0 0 3 2q�6W   �� 5C   "   $+��%/Images/icons8-delete-document-64.png��6(   $��0 1 0 2q�6W   �� 5D   "   $��Clear��6,   $��1 3 0 0q�69   5E      5F      �� 5G      #��[ 6!   $��20��6C   .��5H      �� $��/Images/GoToTop_16x.png��6$   $
��None=�6E   5I      �� 5J      #��[ 6!   $��20��6C   .��5K      �� $%��/Images/ExpandChevronUp_16x.png��6$   $
��None=�6M   5L      �� 5M      #��[ 6!   $��20��6C   .��5N      �� $'��!/Images/ExpandChevronDown_16x.png��6$   $
��None=�6O   5O      �� 5P      #��[ 6!   $��20��6C   .��5Q      �� $ ��/Images/GoToBottom_16x.png��6$   $
��None=�6H   5R      5S      5T      5U      `� 5V      .�5W      c� -   5        $��	PresetBar��5W      
�������.@�5X      �� $ 
Horizontal=�6!   $��25��6:   .+�5Y      �� -	   5        $��
LoadPreset��5Y   C   #��[ 6!   $��5,0,5,0q�6n   .��5Z      �� $ 
Horizontal=�6)   .+�5[   "   �� $��/Images/LoadPreset.png��6(   $��20��6H   $��20��6T   $ HighQuality=�6_   5\      5]      �� 5^      -
   5        $��
SavePreset��5^   C   #��[ 6!   $��2,0,0,0q�6n   .��5_      �� $ 
Horizontal=�6)   .+�5`   "   �� $��/Images/SavePreset.png��6(   $��20��6H   $��20��6T   $ HighQuality=�6_   5a      5b      �� 5c      -   5        $��ChoosePreset��5c   C   #��[ 6!   $��5,0,5,0q�6W   .��5d      �� $ 
Horizontal=�6)   .+�5e   "   �� $��	Presets: ��6(   �� 5f   "   -   5        $��PresetCombobox��5f   +   $	��100��6A   $��0 2 0 2 q�6M   5h   #   5i      5j      5k      5l      5m      5n      � 5o   
   $��1��6   $��0 0 0 0 q�6    5p      �� 5q      $	��300 �6#   �� 5r      $��* �6#   .+�5t      �� -   5        $��ActionListBox��5t      $��0��6+   $��Disabled=�6;    � ContextMenu 5u      �� 5v      .@�5w      m� -   5        $
��Edit��5w   #   61   5x      ��5z      �� 5{      .R�5|      � $��40��6$   .+�5}      �� $��Comic Sans MS)�6o   $��15(�6�   ��6(   �� *	Details+# [  6�   �� 5~      $��: ��6(   $��Comic Sans MS)�62   $��15(�6M   �� 5      $��Comic Sans MS)�6o   $��15(�6�   ��6(   �� *	Details+# [ 6�   5�      5�      5�      �� 5�      $��1��6   .@�5�      �� ��5�      �� 5�      $ 
Horizontal=�6%   .+�5�      �� $��Rename Files��6(   5�      .��5�      �� $ Vertical=�6!   .+�5�      `� .�5�      c� .@�5�   "   �� $ 
Horizontal=�6-   .+�5�   &   �� -   5        	 ��Name$	 AddFileButtons��5�   -   #��[ 6E   $��5 0 5 0q�6g   .��5�   *   �� $ 
Horizontal=�65   .+�5�   .   �� $��/Images/Add.png��64   $��16��6M   $��16��6Y   $ HighQuality=�6d   $��0 0 2 0q�6�   �� 5�   .   $	��Add��68   5�   +   5�   '   �� 5�   &   #��[ 6-   $��20��6O   .��5�   *   �� $��/Images/GoToTop_16x.png��60   $
��None=�6Q   5�   '   �� 5�   &   #��[ 6-   $��20��6O   .��5�   *   �� $%��/Images/ExpandChevronUp_16x.png��60   $
��None=�6Y   5�   '   �� 5�   &   #��[ 6-   $��20��6O   .��5�   *   �� $'��!/Images/ExpandChevronDown_16x.png��60   $
��None=�6[   5�   '   �� 5�   &   #��[ 6-   $��20��6O   .��5�   *   �� $ ��/Images/GoToBottom_16x.png��60   $
��None=�6T   5�   '   5�   #   5�      5�      &   System.Windows.Controls.DataGrid  5�      -   5        $��FileTab��5�   #   
������ 
   GridLinesVisibility$	
 All=�6K      Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Filename��65      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6G   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6S   �� *
Filename+  5�   "   $ New Filename��65   $	 150 6K    6W   �� *Newfilename+  5�   "   $
 Path��65   $	 150 6C    6O   �� *Path+  5�   "   $ Error��65   $ * 6D    6N   �� *Error+5�      5�      5�      �� 5�      ��5�      �� 5�      $ 
Horizontal=�6%   .+�5�      �� $��Rename Folders��6(   5�      .��5�      �� $ Vertical=�6!   .+�5�      `� .�5�      c� .@�5�   "   �� $ 
Horizontal=�6-   .+�5�   &   �� -   5        $	 AddFolderButtons��5�   -   #��[ 6G   $��5 0 5 0q�6i   .��5�   *   �� $ 
Horizontal=�65   .+�5�   .   �� $��/Images/Add.png��64   $��16��6M   $��16��6Y   $ HighQuality=�6d   $��0 0 2 0q�6�   �� 5�   .   $	��Add��68   5�   +   5�   '   �� 5�   &   #��[ 6-   $��20��6O   .��5�   *   �� $��/Images/GoToTop_16x.png��60   $
��None=�6Q   5�   '   �� 5�   &   #��[ 6-   $��20��6O   .��5�   *   �� $%��/Images/ExpandChevronUp_16x.png��60   $
��None=�6Y   5�   '   �� 5�   &   #��[ 6-   $��20��6O   .��5�   *   �� $'��!/Images/ExpandChevronDown_16x.png��60   $
��None=�6[   5�   '   �� 5�   &   #��[ 6-   $��20��6O   .��5�   *   �� $ ��/Images/GoToBottom_16x.png��60   $
��None=�6T   5�   '   5�   #   5�      5�        5�      -   5        $��	FolderTab��5�   #   
������ $	
 All=�6M    5�        5�   "   $ 
Foldername��65   $	 150 6I    6U   �� *
Foldername+  5�   "   $ New Foldername��65   $	 150 6M    6Y   �� *	Newfolder+  5�   "   $ Folder Path��65   $	 150 6J    6V   �� *Path+  5�   "   $ Error��65   $ * 6D    6N   �� *Error+5�      5�      5�      5�      5�      5�      5�      