   M S B A M L   `   `   `  ����D  @HUAN_TECH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:HUAN_TECH.ViewHUAN_TECH.View  5   	   %    HUAN_TECH.View.Commodity_Submit   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   (localclr-namespace:HUAN_TECH.View  5   	     � WindowStartupLocation$  CenterScreen=�64    � WindowStyle$ 
ToolWindow=�5       � Title$ Commodity_Submit��5	   	   $	��330��6"   $	��500��6/   .��5
      � -   5        $��	grid_body��5
       � 	Resources 5   
    �� 
TargetType !  MaterialDesignOutlinedTextBox �� BasedOn �� Property �� Value " MaterialDesignOutlinedComboBox��%  '��       7   '�� t     7  �� 5      " ��6   8   .�5      ��  � ��$ Center=�66   �� 5       � ��$ 5q�6+   5      �� 5      " ��6   8   .�5      ��  � ��$ Center=�66   �� 5       � ��$ 5q�6+   5      5       � ColumnDefinitions 5   
   �� 5      �� 5      	 � RowDefinitions	 5   
   �� 5      �� 5      �� 5      �� 5       �� 5!      .+�5$   
   �� -   5        $��txt_commodityGroup��5$      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Nhóm hàng��6-   �� 5%   
   -   5        $��txt_commodityName��5%      $
 Tên sản phẩm��6+   $��1��6Y   �� 5'   
   -   5        $��txt_description��5'      $
 Mô tả sản phẩm��6)   $��1��6Y   $��2��6f   �� 5)   
   -   5        $��	txt_price��5)      $
 	Giá bán��6#   $��2��6L   �� 5*   
   -   5        $��txt_quantity��5*      $
 Số lượng tồn kho��6&   $��3��6X   $��0��6e   �� 5+   
   -   5        $��txt_unit��5+      $
 
Đơn vị��6"   $��3��6J   $��1��6W   �� 5,   
   -   5        $��
btn_submit��5,      $��Submit��6#   $��4��6I   $��2��6V   $��5q�6j   5-      5.      