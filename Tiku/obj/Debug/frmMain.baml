   M S B A M L   `   `   `  ����?  ;Tiku, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TikuTiku  5   	       Tiku.frmMain   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Tiku     5   	   -   5          � Title$  frmMain��5   	   $	��800��6   $
��1280��6&    � WindowStyle$
 None=�63    � WindowStartupLocation$ CenterScreen=�6F    � AllowsTransparency .  � Icon$ image/1071924714.jpg��6�   .��5	      �  � RowDefinitions 5
   
   �� 5      $��84 �6   6*   �� 5      6   �� 5      $��35 �6   6*   .+�5   
   � $��0��6   .+�5      � .+�5       � -   5          �Name$ fmTitle��5        � NavigationUIVisibility$ Hidden=�6)   6K   o� 5      $��2��6   $	��Top=�6'   $��Center=�6?   $��Right=�6a   $��Right=�6}   .@�5      m� -   5         m�Name$ 	menu_main��5   +   $��菜单��6   .@�5      m� -   5        $ menu_register��5   #   $��注册��6:   6F   m� 5      -   5        $ menu_setpass��5   #   $��修改密码��69   6G   m� 5      -   5        $ menu_logout��5   #   $��登录/注销��68   6G   m� 5      -   5        $ 	menu_exit��5   #   $��退出��66   6B   5      m� 5      -   5        $ menu_min��5      $��_��61   6<   m� 5      -	   5        $ menu_max��5      $	��☐��61   6<   m� 5      -
   5        $ 	menu_Exit��5      $��X��62   6=   5      5      5       � 5   
   -   5        $ fmMain��5      $��1��6    $ Hidden=�6-   ���	#FF1267A7$��3,0,3,0q�6e   5!      �� 5"   
   $��2��6   ���	#FF1267A7	 �� Orientation$	 
Horizontal=�69   .+�5#      �� -   5        
 ��Name$
 labCompanyName��5#      $
��Left=�60   $��Center=�6K   $��20,0,0,0q�6f   '%@汤沐科技有限公司版权所有6�   �� 5$      -   5        $
 labUrl��5$      $
��Left=�6(   $��Center=�6C   $��30,0,0,0q�6^   75官方主页：http://www.kszhuanjia.com/html/jianyi/6�   5%      �� 5&   
   $��2��6   $	 
Horizontal=�6"   $��Right=�6;   .+�5'      �� -   5         ��Name$ imgQQ��5'      $	��170��6#   $��image/图层15.png��6/   $
��Fill=�6G   $��5q�6V   6{   5(      5)      5*      