   M S B A M L   `   `   `  ����   GameList-    'WpfApp1.ReviewsAndRecommendationsWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$.  (Отзывы и Рекомендации��$	��450��$
��1600��   MaterialDesignWindow#��[   � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=����#FAFAFA.��� $��10q�.+�]� $
��True��.+��� $
��Left=�$
��1000��$��0,0,10,0q�$��1q����#B0BEC5 �� CornerRadius$ 10��
������� " MaterialDesignElevationShadow4 J� Effect# �  ._��� $
��Auto=�$��10q�.���� -   $��ReviewsListView�� �� View �� .P��� $��Пользователь�� �� Width$	 180�� �� DisplayMemberBinding �� *
UserName+�� $��Игра��$	 180�� �� *	GameTitle+�� $��Текст отзыва��$	 400�� �� *
ReviewText+�� $��Рейтинг��$ 80�� �� *Rating+�� $��Дата��$	 200�� �� *
ReviewDate+�� $��Right=�$	��580�� �� Padding$ 20q����#B0BEC5$��1q�$ 10��
�������# �  ._��� 	 �� Orientation$	 Vertical=�.+��� $!��Добавить отзыв��$��24(�$
��Bold"�$��0,0,0,20q����#263238�� $��Рейтинг (1-5)��$��0,0,0,5q�$��SemiBold"��� -   $��RatingTextBox��$��0,0,0,15q�$��30�����#90A4AE$��1q�$��5q��� $��Текст отзыва��$��0,0,0,5q�$��SemiBold"��� -   $��ReviewTextBox��$��0,0,0,15q�$	��120��
 �� TextWrapping$

 Wrap=� �� AcceptsReturn$
 True�����#90A4AE$��1q�$��5q��� $	 
Horizontal=�$��Center=�.+��� -   $!��Добавить отзыв��$	��160��$��35��$��0,0,10,0q����#0288D1
�������$��SemiBold"�$��0q��� -   $��Обновить��$	��120��$��35��$��0,0,10,0q����#0288D1
�������$��SemiBold"�$��0q��� -   $��
Назад��$��90��$��35�����#D32F2F
�������$��SemiBold"�$��0q��� -   $��StatusTextBlock�����#D32F2F$y�	Collapsed=�$��0,20,0,0q�$
��Bold"�