   M S B A M L   `   `   `  ����D  @HUAN_TECH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:HUAN_TECH.ViewHUAN_TECH.View  5   	   '    !HUAN_TECH.View.ImportStock_Submit   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:HUAN_TECH.View     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ ImportStock_Submit��5
   	   $	��600��6$   $
��1200��61   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��300 �6   �� 5      .+�5   
   � -   5        $��	grid_body��5       � 	Resources 5      (  "System.Windows.Controls.DatePicker �� 
TargetType $   MaterialDesignOutlinedDatePicker �� BasedOn �� Property �� Value ! MaterialDesignOutlinedTextBox " MaterialDesignOutlinedComboBox��%�  '        7   '�� t     7  '�� �     7  �� 5      "  6   8   .�5      ��  � ��$ 5q�6/   �� 5       � ��$ Center=�6:   5      �� 5      " ��6   8   .�5      ��  � ��$ 5q�6/   �� 5       � ��$ Center=�6:   5      �� 5      " ��6   8   .�5      ��  � ��$ 5q�6/   �� 5       � ��$ Center=�6:   5      5        � RowDefinitions 5"      �� 5#      $
��Auto �6    �� 5$      $
��Auto �6    �� 5%      $
��Auto �6    �� 5&      $
��Auto �6    �� 5'      $
��Auto �6    �� 5(      $
��Auto �6    �� 5)      $
��Auto �6    .+�5+        -   5        $��dpk_importDate��5+      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Ngày nhập hàng��6/   �� 5,      -   5        $��txt_commodityGroup��5,      $	 Nhóm hàng hóa��6d   $��1��6�   �� 5-      -   5        $��txt_commodityName��5-   )   
 �� 
IsEditable$

 True��6   $	 Tên hàng hóa��6B   $��2��6q   �� 5.      -   5        $��txt_importFrom��5.      $	 Nơi nhập hàng��6,   $��3��6\   �� 5/      -   5        $��txt_importQuantity��5/      $	 Số lượng nhập��60   $��4��6`   �� 50      -   5        $��txt_importPrice��50      $	 
Đơn giá��6-   $��5��6W   � 52      $��6��6    53        Style_ButtomBiding ! MaterialDesignFlatMidBgButton �� Triggers �� Binding �� ElementName �� Path �� Value��%�   &	       7  �� 54      " ��6   8    55      �� 56       6*   �� $ btn_add��$ 	IsEnabled� True6c   .a�57   "   ��  � {�$ False��6>   58      5:      5;       5=      �� 5>      �� 5?      �� 5@      .+�5C      �� -   5        $��btn_add��5C      $	��Add��6;   $��5q�6I   �� 5D      -	   5        $��btn_edit��5D      #��[ 6<   $
��Edit��6h   $��1��6w   $��5q�6�   �� 5E      -
   5        $��
btn_cancel��5E      #��[ 6A   $��Cancel��6m   $��2��6~   $��5q�6�   5F      5H      � 5J   
   $��1��6    5K      �� 5L      $
��Auto �6    �� 5M      .+�5P      � .+�5Q      �� -   5        $��5q�5Q   j   ��63   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ HomeGroupPlus=�6j   �� 5R      $���}Nhấp vào đây để đồng bộ dữ liệu vào kho, sau khi đồng bộ dữ liệu vào kho sẽ không thể sửa.��6   $��Center=�6~   5S      &   System.Windows.Controls.DataGrid  5U      -   5        $��dtg_waitImport��5U      $��1��6-   $��5q�6:      
IsReadOnly$
 True��6E    5V      ��%[   'm�       �� 5W      " m�6   .�5X      ��  �@�Cursor$
 Hand��63   5Y      5Z       � ContextMenu 5\      �� 5]      ��6"   Z� .@�5^      m� -   5        $
��Edit��5^   #    m� Icon 6M     $
 Edit=�m� 5_      $��Delete��6#    63     $ Delete=�5`      5b      5c      5e      5f      