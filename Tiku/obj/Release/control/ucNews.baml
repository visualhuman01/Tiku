   M S B A M L   `   `   `  ���� ?  ;Tiku, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Tiku.controlTiku.control      Tiku.control.ucNews   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:Tiku.control     .���   � ColumnDefinitions  �� $	��100 ��� .+��� -    ��Name$ imgNews��$��0��� $��1��$��10q� � RowDefinitions �� $��30 ��� .+�� $��0��  �� �� $	��150 ��� $��80 ��� $��80 �.+��� -    ��Name$ txtTitle��$��0��$��Center=�$��18(�$��CharacterEllipsis=�title�� -   $ txtTime��$��1��$��Center=�$��14(�$��Center=����	#FF3E3E420000-00-00 00:00:00�� -    ��Name$ btnCollection��$��2��$��收藏�� � Cursor$
 Hand��$��Center=�$��Right=�����  �� 
TargetType" ��.R��� $��	Underline{��� ����  �� 
TargetType" ��.���  �� Property � ��	 �� Value
	 ��  �
 �� Triggers
 P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
	 �  ���� -   $ btnLink��$��3��$��查看详情>>��$
 Hand��$��Center=�$��Right=����� " ��.R��� $��	Underline{��� ���� " ��.���  � ��
	 ��  �
 P�  �@J�IsMouseOver . . ���  � ��
	 �  ��� $��1��.+��� $
��Auto=�$
��Auto=����� -   $ 
txtContent��$
��Auto=�$
��Wrap=�$��14(�test