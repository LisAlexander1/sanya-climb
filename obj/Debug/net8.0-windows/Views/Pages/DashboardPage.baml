   M S B A M L   `   `   `  ����D  @Skalalazy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Skalalazy.Views.PagesSkalalazy.Views.Pages  5      )    #Skalalazy.Views.Pages.DashboardPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Skalalazy.Views.Pages     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      A =Wpf.Ui, Version=3.0.4.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5         TextFillColorPrimaryBrush  N� 
Foreground#  �   5       N� Title$ DashboardPage��5        ApplicationBackgroundBrush  Wpf.Ui.Markup.Design   
Background# �  5	         
Foreground# �   5
      .��5      �� $��Center=�6   $��Center=�6.   .+�5   
   �� $��
Логин��6   $
��Left=�6      Wpf.Ui.Controls.TextBox  5   
   $	��Top=�5      $��0,0,0,10q�5      $	��300��5      �� 5   
   $��Пароль��6   $
��Left=�6!   !  Wpf.Ui.Controls.PasswordBox  5   
   $	��Top=�5      $��0,0,0,24q�5      $	��300��5        Wpf.Ui.Controls.Button  5   
      
Appearance$ Primary=�5       $��
Войти��5"      $��Center=�5#         Icon*  $Wpf.Ui.Controls.IconElementConverter$ Fluent24 5$      $	��300��5%      ��5!      �� *ViewModel.AuthCommand+ �� Mode$ OneWay=�5%      5&      5'      