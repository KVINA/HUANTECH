   M S B A M L   `   `   `  ����D  @HUAN_TECH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:HUAN_TECH.ViewHUAN_TECH.View  5   	   )    #HUAN_TECH.View.Edit_commodity_group   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:HUAN_TECH.View     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � 
ResizeMode$  NoResize=�5       � Title$ Edit_commodity_group��5	   	   $	��230��6&   $	��500��63   .��5
      � $��2q�6    � 	Resources 5   
    �� 
TargetType !  MaterialDesignOutlinedTextBox �� BasedOn �� Property �� Value��%�   '��       7   �� 5      " ��6   8   .�5      ��  � ��$ 2q�6+   �� 5       � ��$ Center=�66   5      5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �  � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      .+�5      �� -   5        $��txt_id��5      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 GroupID��6$   $��80��6M   
 �� 
IsReadOnly$

 True��6X   �� 5      -   5        $��txt_groupname��5      $	 
Group Name��6+   $��1��6W   5      �� 5!   
   -   5        $��txt_description��5!      $	 Description��6)   $��1��6V   �� 5"   
   -   5        $��2��5"      $��Submit��63   $��2q�6D   5#      5$      