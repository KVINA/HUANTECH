   M S B A M L   `   `   `  ����D  @HUAN_TECH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HUAN_TECH.User_ControlsHUAN_TECH.User_Controls  5      *    $HUAN_TECH.User_Controls.UC_Commodity   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HUAN_TECH.User_Controls     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      .+�5   
   �� .+�5      � $��2q�6   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  
��� � �   Kind$ RhombusSplit=�6=   $��Center=�6Q   $	��2 0q�6l   �� 5      $��	Khai báo��6   
����  �$
��Bold"�6>   $��16(�6P   �� 5      $	�� / ��6   $��16(�6'   �� 5      $��Danh mục hàng hóa��6   
����  �$
��Bold"�6G   $��16(�6Y   5      �� 5      $
��0 10q�6   5      � 5   
   $��1��6   .+�5      �� -   5        $��txt_commodityGroup��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nhóm hàng��61   $	��200��6\   $��5q�6h    "  MaterialDesignOutlinedComboBox#��[  6s   �� 5      -   5        $��txt_commodityName��5      $ 
Tên hàng��6/   $	��200��6Y   $��5q�6e    ! MaterialDesignOutlinedTextBox#��[ 6p   �� 5       -   5        $��Search��5       $��5q�6;   $	��100��6F   �� 5!      -   5        $	��Add��5!      $��5q�65   $	��100��6@   5"      &   System.Windows.Controls.DataGrid  5$   
   -   5        $��dtg_commodity��5$   %      
IsReadOnly$
 True��6   $��2��6:    � ContextMenu 5%      �� 5&      ��6   Z� .@�5'      m� -   5        $
��Edit��5'       m� Icon 6@   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$
 Edit=�m� 5(      -   5        $��Delete��5(       6D     $ Delete=�5)      5+      5,      5.      