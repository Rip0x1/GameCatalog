   M S B A M L   `   `   `  ����   GameList    WpfApp1.AdminWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$   Администратор��$	��760��$
��1000��   MaterialDesignWindow#��[   � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.��� ���#F5F5F5$��10q�.+��� $��Segoe UI)�$��14(�.@��� $'��!Управление играми��$��10q�.���� $
��Auto=�.���� $��10q�
������� ! MaterialDesignElevationShadow J� Effect# �  .+��� $��Добавить игру��$��24(�$
��Bold"�$��0,0,0,20q����#333�� $��0,0,0,10q�.+��� $K��EID игры (для редактирования и удаления)��$��0,0,0,5q��� -   $��GameIDTextBox��$��30��$��5q����#888$��1q��� $��0,0,0,10q�.+��� $��Название��$��0,0,0,5q��� -   $��TitleTextBox��$��30��$��5q����#888$��1q��� $��0,0,0,10q�.+��� $��Жанр (ID)��$��0,0,0,5q��� -   $��GenreIDTextBox��$��30��$��5q����#888$��1q��� $��0,0,0,10q�.+��� $��Рейтинг��$��0,0,0,5q��� -   $��RatingTextBox��$��30��$��5q����#888$��1q��� $��0,0,0,10q�.+��� $��Платформа��$��0,0,0,5q��� -   $��PlatformTextBox��$��30��$��5q����#888$��1q��� $��0,0,0,10q�.+��� $��Описание��$��0,0,0,5q��� -   $��DescriptionTextBox��$	��100��$��5q� �� TextWrapping$
 Wrap=� �� AcceptsReturn$
 True�����#888$��1q�" �� VerticalScrollBarVisibility$
 Auto=��� $��0,0,0,20q�.+��� $��Дата выхода��$��0,0,0,5q�(  "System.Windows.Controls.DatePicker  -   $��ReleaseDatePicker��$��30�����#888$��1q���  �� Orientation$ 
Horizontal=�$
��Left=�.+��� -   $��Добавить игру��$��0,0,15,0q�$
��10,5q����#2196F3
�������$��0q� � Cursor$
 Hand��  MaterialDesignRaisedButton#��[ �� -	   $)��#Редактировать игру��$��0,0,15,0q�$
��10,5q����#FF9800
�������$��0q�$
 Hand��#��[ �� -
   $��Удалить игру��$
��10,5q����#F44336
�������$��0q�$
 Hand��#��[ �� $)��#Управление жанрами��$��10q�.���� $��10q�
�������# �  .+��� $��Добавить жанр��$��24(�$
��Bold"�$��0,0,0,20q����#333�� $!��Название жанра��$��0,0,0,5q��� -   $��GenreNameTextBox��$��30��$��5q����#888$��1q�$��0,0,0,15q��� -   $��Добавить жанр��$
��10,5q����#4CAF50
�������$��0q�$
 Hand��#��[ 