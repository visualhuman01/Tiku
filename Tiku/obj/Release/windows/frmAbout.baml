   M S B A M L   `   `   `  ���� ?  ;Tiku, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Tiku.windowsTiku.windows      Tiku.windows.frmAbout   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:Tiku.windows     -     � Title$  关于我们��$	��300��$	��500�� � WindowStyle$ 
ToolWindow=� � WindowStartupLocation$ CenterScreen=�.��� $��10q� � RowDefinitions �� $��50 ��� $��50 ��� $��50 ��� $��50 ��� �� $��50 �.+��� $��0�� �� Orientation$ 
Horizontal=�$��Center=�.+��� $��14(�$��10q�售前客服QQ：�� -    ��Name$ txt_pre��$��14(�$��10q�
0000000000�� $��14(�$��10q�售后客服QQ：�� -   $ 	txt_after��$��14(�$��10q�
0000000000�� $��1��$ 
Horizontal=�$��Center=�.+��� $��14(�$��10q�咨询热线电话：�� -   $ txt_tel��$��14(�$��10q�000-00000000�� $��14(�$��10q�移动版下载：�� -    ��Name$ 
btnAndroid��$��14(�$��Android�� � Cursor$
 Hand��$��10q�����  �� 
TargetType" ��.R��� $��	Underline{��� ���� 	 �� 
TargetType"	 ��.��� 
 �� Property
 � �� �� Value
 ��  � �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ��� 
 � ��
 �  ���� -   $ btnIOS��$��14(�$	��IOS��$
 Hand��$��10q����� " ��.R��� $��	Underline{��� ���� "	 ��.��� 
 � ��
 ��  � P�  �@J�IsMouseOver . . ��� 
 � ��
 �  ���� $��2��$ 
Horizontal=�$��Center=�.+��� $��14(�$��10q�	官网：�� -   $ btnWeb��$��14(�$!��http://www.tikuzhuanjia.com��$
 Hand��$��10q����� " ��.R��� $��	Underline{��� ���� "	 ��.��� 
 � ��
 ��  � P�  �@J�IsMouseOver . . ��� 
 � ��
 �  ���� $��3��$ 
Horizontal=�$��Center=�.+��� $��14(�$��10q�备案号：�� -   $ 
txt_record��$��14(�$��10q�XXXXXXXXXXXXXXX�� -	   $ btnClose��$��5��$��80��$��30��$��Right=�$��10q�.��关闭