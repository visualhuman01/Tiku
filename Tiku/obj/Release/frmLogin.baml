   M S B A M L   `   `   `  ���� ?  ;Tiku, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TikuTiku      Tiku.frmLogin   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     $localclr-namespace:Tiku       � Title$  登录��$	��250��$	��500�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � WindowStyle$ 
ToolWindow=�.��� .+�� $��50,20q� � RowDefinitions �� �� �� $��15 ��� .+�� $��0�� � ColumnDefinitions �� $��70 ��� .+��� $��0��$��Center=�$��Center=�	手机号�� -    ��Name$ txtPhone��$��1��$��10q�$��Center=�$��18181366398��� $��1�� �� $��70 ��� .+��� $��0��$��Center=�$��Center=�密码� -    �Name$
 gPwd��$��1��.+��� -   $ txtPwd��$��10q�$��Center=�$��123456��� -   $ gCode��$��1��$y�Hidden=� �� �� $	��100 �.+��� -   $ txtCode��$��0��$��10q��� -    ��Name$ btnSend��$��1��$��10q�.��发送验证码� $��2��$��Center=�.+��� -   $ 
btnPwdCode��$��手机验证码登录��	 � Cursor$
	 Hand��$��Right=�$��Center=�$��0,0,20,0q����� 
 �� 
TargetType"
 ��.R��� $��	Underline{��� ����  �� 
TargetType" ��.���  �� Property � �� �� Value
 ��  � �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
 �  ��� $��3�� �� �� .+��� -   $ 	btnCancel��$��0��$��10q�.��取消�� -	   $ btnOk��$��1��$��10q�.��确定