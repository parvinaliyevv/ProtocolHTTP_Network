   M S B A M L   `   `   `  ����  ProtocolHTTP.Client.    (ProtocolHTTP.Client.Views.InsertUserView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � WindowStyle$
  None=�5   	    � 
ResizeMode$ NoResize=�6    � AllowsTransparency$
 True��62   
������  � WindowStartupLocation$ CenterOwner=�5   	   $	��400��6-   $	��500��6:   .��5
      ��    FirstBgColor#��[  6   ._�5   
   �  � RowDefinitions 5      �� 5      $��50��6    �� 5      .+�5      �� -   5          SecondBgColor#��[ 5       �� CornerRadius$ 
7, 7, 0, 0��6A   ._�5      ]� $��False��6    � 	Resources 5       �� 
TargetType . *MaterialDesignFloatingActionMiniDarkButton �� BasedOn	 �� Property
 �� Value��%  '��       7  �� 5      " ��6    8   .�5      �� 	 � ��

 �����6;   �� 5      	 � ��

 ���� 6;   �� 5      	 � ��

 ���� 6<   �� 5      	 � ��$
 40��67   �� 5      	 � ��$
 40��66   �� 5      	 � ��$
 0, 0, 10, 0q�67   5!      5"      .+�5$      �� -   5        $��Right=�5$   k   ��6   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Close=�6k   �� 5&      $��Center=�6    $��30(�6;   $��20, 0, 0, 0q�6I   �� 5(      $	�●��6   ���#ee6a5f6'    �� 5)      $	�●��6   ���#f5be516'    �� 5*      $	�●��6   ���#63c7576'   5,      5.      5/      � 51      $��1��6    53      �� 54      �� 55      �� 56      �� 57      $��70 �6$   .+�5:      �� 
�������)  #MaterialDesignThemes.Wpf.HintAssist   
Background# [  6P      Hint$
 Name��6�   $��10q�6�   $��0��6�   ��6   �� *	User.Name+6�   �� 5;      
�������# [  6S   $ Surname��6�   $��10q�6�   $��1��6�   ��6   �� *User.Surname+6�   �� 5<      
�������# [  6O   $	 Age��6�   $��10q�6�   $��2��6�   ��6   �� *
User.Age+6�   �� 5>      -   5        $
��Save��5>      $��50, 0q�6F   $��3��6U   5@      5B      5C      5E      