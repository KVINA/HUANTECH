   M S B A M L   `   `   `  ����D  @HUAN_TECH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:HUAN_TECH	HUAN_TECH  5   	       HUAN_TECH.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:HUAN_TECH     5   	     � WindowStartupLocation$  CenterScreen=�5       � Title$ Hello��5   	   $	��700��6   $
��1200��6$   .��5	      �  � 	Resources 5
   
    �� 
TargetType �� BasedOn �� Property �� Value �� Triggers P� Property	 P� Value��%�  'm�       'o� ,    '�� �    '�� I    �� 5      " m�6    6*   Z� .�5      ��  �@�Cursor$
 Hand��6+   �� 5       � ��$ 14(�6-   �� 5       � ��$ Segoe UI)�6/   �� 5       � ��$ 
UltraLight"�6/   �� 5       � ��$ UltraExpanded&�60   �� 5       � ��$ 28��6+   5      �� 5      " o�6    6&   Z� .�5      ��  � ��$ 2q�6+   5      �� 5      " ��6    6)   Z� .�5      ��  � ��$
 -2 0q�6+    5      P� 5       �@��
IsSelected$
	 True��64   . �5      ��  � ��$
 -2 0q�63   5      5      �� 5!      " ��6    6,   Z� .�5"      ��  �@��TabStripPlacement$ Bottom=�66   5#      5%      
 � RowDefinitions
 5&   
   �� 5'      $
��Auto �6   �� 5(      .+�5+   
   o� .@�5,      m� $��_Hệ thống��6   .@�5-      m� -   5        
 � Tag$ 
UC_Account��5-      $��Quản lý tài khoản��6,   6G   m� 5.      -   5        $��Cài đặt��5.      6,   m� 5/      -   5        $��Đăng xuất��5/      6.   m� 50      -   5        $��Thoát��50      6*   51      m� 53      $��
_Khai báo��6   .@�54      m� -   5        $ UC_CommodityGroup��54      $��Danh mục nhóm hàng��63   6O   m� 55      -   5        $ UC_Commodity��55      $��Danh mục hàng hóa��6.   6I   56      m� 58      $��_Quản lý kho��6   .@�59      m� -   5        $ UC_ImportStock��59      $��
Nhập kho��60   6B   m� 5:      -   5        $ UC_ExportStock��5:      $��
Xuất kho��60   6B   5;      m� 5=      $��
_Báo cáo��6   .@�5>      m� -	   5        $��
Công nợ��5>      6,   m� 5?      -
   5        $��Doanh thu tháng��5?      64   m� 5@      -   5        $��Thời hạn sử dụng��5@      65   m� 5A      -   5        $��Thời hạn nhắc mua��5A      66   5B      m� 5D      $��
_Tra cứu��6   .@�5E      m� -   5        $��
Hóa đơn��5E      6,   5F      5G      �� 5I   
   -   5        $��tct_body��5I   "   $��1��6   $��2q�62   5K      5L      5M      