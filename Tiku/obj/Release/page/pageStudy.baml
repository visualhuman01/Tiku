   M S B A M L   `   `   `  ���� ?  ;Tiku, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Tiku.controlTiku.control      Tiku.page.pageStudy   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:Tiku.control     -   .���   � RowDefinitions  �� $��80 ��� �� $��2 ��� $��80 �.+�� $��0��$��10q� � ColumnDefinitions �� $��60 ��� .+��� $&�� /Tiku;component/image/学习.png��$
��Fill=�$��5q�� $��1��  �� �� .+��� $��0��$��Center=�$��20(�最近学习章节>>�� $��1��$��Center=�$��16(���这里记录你最近学习的章节和学习时间，点击一下列表中的某一章节，即可进入相应章节继续答题。>>� $��1��.+�   Tiku.control.ucTable  -     Name$ tbStudy��$��50q�   Columns    Tiku.control.TableColumn     
field_name$ 	题库名��   field$ 	good_name��  $ 题目数量��$	 num��   type$ Pixel=�   width$	 100X�	   ha$ Center=�  $ 当前做到第几题��$
 sign��$ Pixel=�$	 100X�$ Center=�� $��2�����	#FF007ACC� $��3�� �� $��80 ��� $	��200 ��� .+��� $��0��$)��#/Tiku;component/image/14-时间.png��$
��Fill=�$��10q��� $��1��$��20(�$��Center=�题库题目总进度>>� $��2��  �� ��  �� �� �� �� .+��� $��0��$��0��$��Center=�	 �� Orientation$	 
Horizontal=�.+��� $��14(�
总题数:�� -   
 ��Name$
 txt_all��$��14(�$��5,0,0,0q�0�� $��0��$��1��$��Center=�$	 
Horizontal=�.+��� $��14(�已做题数:�� -   $
 txt_do��$��14(�$��5,0,0,0q�0�� $��0��$��2��$��Center=�$	 
Horizontal=�.+��� $��14(�未做题数:�� -   $
 txt_done��$��14(�$��5,0,0,0q�0�� $��0��$��3��$��Center=�$	 
Horizontal=�.+��� $��14(�学习进度:�� -   $
 txt_all_pre��$��14(�$��5,0,0,0q�0�� $��1��$��0��$��Center=�$	 
Horizontal=�.+��� $��14(�正确题数:�� -   $
 	txt_right��$��14(�$��5,0,0,0q�0�� $��1��$��1��$��Center=�$	 
Horizontal=�.+��� $��14(�答错题数:�� -   $
 	txt_wrong��$��14(�$��5,0,0,0q�0�� $��1��$��2��$��Center=�$	 
Horizontal=�.+��� $��14(�
正确率:�� -	   $
 txt_right_pre��$��14(�$��5,0,0,0q�0