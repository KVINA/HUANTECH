   M S B A M L   `   `   `  ����D  @HUAN_TECH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:HUAN_TECH.ViewHUAN_TECH.View  5   	        HUAN_TECH.View.Bill_Submit   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:HUAN_TECH.View     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Bill_Submit��5	   	   $	��650��6   $
��1200��6*   .��5
      �  � 	Resources 5   
    �� 
TargetType "  MaterialDesignOutlinedComboBox �� BasedOn �� Property �� Value(  "System.Windows.Controls.DatePicker $  MaterialDesignOutlinedDatePicker ! MaterialDesignOutlinedTextBox��%�  '��       7   '  q     7  '�� �     7  �� 5      " ��6   8   .�5      ��  � ��$ 2q�6+   �� 5       � ��$	 150��6*   5      �� 5      "  6   8   .�5      ��  � ��$ 2q�6+   �� 5       � ��$	 150��6*   5      �� 5      " ��6   8   .�5      ��  � ��$ 2q�6+   �� 5       � ��$	 150��6*   �� 5       � ��$ Center=�66   5      5       � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5      .+�5"   
   �� $��Thông tin khách hàng��6   $��2q�61   .��5#      �  � RowDefinitions 5$      �� 5%      �� 5&      �� 5'      �� 5(      �� 5)      �� 5*      �� 5+      .+�5-      �� -   5        $��
txt_billId��5-      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Số hóa đơn��6,   $��0��6X   $
��Auto��6e   ${�False��6r     5.      -   5        $��dpk_billDate��5.      $ 	Ngày mua��61   $
��Auto��6[   ${�False��6h   $��1��6z   �� 5/      -   5        $��txt_nameCustomer��5/      $ Tên khách hàng��62   $��2��6b   $
��Auto��6o   ${�False��6|   �� 50      -   5        $��	txt_phone��50      $ Số điện thoại��6+   $��3��6Z   $
��Auto��6g   ${�False��6t   �� 51      -   5        $��txt_address��51      $ Địa chỉ��6-   $��4��6V   $
��Auto��6c   ${�False��6p   �� 52      -   5        $��	txt_email��52      $ Email��6+   $��5��6S   $
��Auto��6`   ${�False��6m   � 53      $��6��6    54      �� 55      �� 56      .+�58      �� -   5        $��btn_edit��58      $
��Edit��6-   $��0��6S   $��2q�6c   �� 59      -   5        $��Cancel��59      $��1��6C   $��2q�6S   5:      5<      5=      �� 5?   
   $��Thông tin hóa đơn��6   $��1��6.   $��2q�6>   .��5@   
   �  5A      �� 5B      $
��Auto �6    �� 5C      .+�5F      � -	   5        $��wpn_body��5F      .+�5G      �� -
   5        $��txt_commodityGroup��5G   N   $ 
Group Name��6h   �� 5H      -   5        $��txt_commodityName��5H   M   $ Commodity Name��6f   �� 5I      -   5        $��txt_unitPrice��5I      ${�False��6/   $ 
Unit Price��6A   �� 5J      -   5        $��txt_quantity��5J      $ Quantity��6.   �� 5K      -   5        $��80��5K   a   $��2q�6l   	 � ToolTip$	 Thêm vào giỏ hàng��6w   ��6/   0  *MaterialDesignThemes.Wpf.PackIconExtension  
   Kind$
 CartPlus=�6w   �� 5L      -   5        $��80��5L   h   $��2q�6s   $	 In hóa đơn��6~   ��67     $
 Printer=�6~   5M      &   System.Windows.Controls.DataGrid  5O      -   5        $��dtg_exportstork��5O         CanUserAddRows$ False��6.      CanUserDeleteRows$ False��6E      AutoGenerateColumns$ False��6_   $��1��6{      Columns 5P      4  .System.Windows.Controls.DataGridTemplateColumn  5Q         CellTemplate 5R      �� 5S      .R�5T   "   � .+�5U   &   �� -   5        $��18��5U      ��6F     $
 Delete=�   Size 116   5V   #   5W      5Y      0  *System.Windows.Controls.DataGridTextColumn  5[      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã sản phẩm��6)      
IsReadOnly$
 True��6^   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *CommodityId+6^     5\      $ Tên sản phẩm��6)   $
 True��6a    6?   �� *CommodityName+6a     5]      $ 
Đơn giá��6)   $
 True��6X    6:   �� *	UnitPrice+6X     5^      $ Số lượng��6)   $
 True��6X    6;   �� *
Quantity+6X     5_      $ 
Đơn vị��6)   $
 True��6R    69   �� *Unit+6R     5`      $ Thành tiền��6)   $
 True��6]    6=   �� *TotalAmount+6]     5a      $ Thời gian bảo hành��6)    6E   �� *Note+ �� Mode$ TwoWay=�5d      5e      5f      5g      5j      