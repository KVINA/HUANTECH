   M S B A M L   `   `   `  ����D  @HUAN_TECH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HUAN_TECH.User_ControlsHUAN_TECH.User_Controls  5      ,    &HUAN_TECH.User_Controls.UC_ImportStock   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HUAN_TECH.User_Controls     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      .+�5   
   �� .+�5      � $��2q�6   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  
��� � �   Kind$ RhombusSplit=�6=   $��Center=�6Q   $	��2 0q�6l   �� 5      $��Quản lý kho��6   
����  �$
��Bold"�6A   $��16(�6S   �� 5      $	�� / ��6   $��16(�6'   �� 5      $��
Nhập kho��6   
����  �$
��Bold"�6>   $��16(�6P   5      �� 5      $
��0 10q�6   5      � 5   
   $��1��6   .+�5      (  "System.Windows.Controls.DatePicker  -   5        $��dpk_importdate��5   [   $��2q�6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Ngày nhập��6$   $	��150��6O    $   MaterialDesignOutlinedDatePicker#��[  6q   �� 5      -   5        $��txt_commodityGroup��5   "   $��2q�6   $ Nhóm hàng��6<    " MaterialDesignOutlinedComboBox#��[ 6g   $	��150��6�   �� 5       $��Search��6   $��2q�6&   �� 5!      -   5        $��Import stock��5!   *   $��2q�6A   5"      &   System.Windows.Controls.DataGrid  5$   
   -   5        $��dtg_importstock��5$   %      
IsReadOnly$
 True��6   $��2��6<   5&      5'      5(      