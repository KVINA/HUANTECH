   M S B A M L   `   `   `  ����D  @HUAN_TECH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HUAN_TECH.User_ControlsHUAN_TECH.User_Controls  5      /    )HUAN_TECH.User_Controls.UC_CommodityGroup   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:HUAN_TECH.User_Controls     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $��Segoe UI)�5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      .+�5   
   �� .+�5      � $��2q�6   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  
��� � �   Kind$ RhombusSplit=�6=   $��Center=�6Q   $	��2 0q�6l   �� 5      $��	Khai báo��6   
����  �$
��Bold"�6>   $��16(�6P   �� 5      $	�� / ��6   $��16(�6'   �� 5      $��Danh mục nhóm hàng��6   
����  �$
��Bold"�6H   $��16(�6Z   5      �� 5      $
��0 10q�6   5      � 5   
   $��1��6    � 	Resources 5       �� 
TargetType !  MaterialDesignOutlinedTextBox �� BasedOn �� Property �� Value��%Z   '��       7   �� 5      " ��6   8   .�5       ��  � ��$ 2q�6/   5!      5"       � ColumnDefinitions 5$      �� 5%      $
��Auto �6#   �� 5&      �� 5'      $
��Auto �6#   .+�5*      �� -   5        $��txt_groupname��5*      $	��150��6+   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Group Name��67   �� 5,      -   5        $��txt_description��5,      $��1��6-   $ Description��6=   �� 5.      -   5        $��btn_add��5.      $��5q�6:   $	��100��6E   $	��Add��6Q   $��2��6_   5/      &   System.Windows.Controls.DataGrid  51   
   -   5        $��dtg_commodity_group��51      $��2q�6   $��2��69   	   
IsReadOnly$
	 True��6F   
 � ContextMenu
 52      �� 53      ��6   Z� .@�54      m� -   5        $
��Edit��54       � Cursor$
 Hand��6o    m� Icon 6D   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$
 Edit=�6o   m� 55      $��Delete��6   $
 Hand��6\    6/     $ Delete=�6\   56      58      59      5;      