   M S B A M L   `   `   `  ����S  O301037418(yoonseop)_Lab2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:_301037418_yoonseop__Lab2_301037418_yoonseop__Lab2  5   	   S.clr-namespace:_301037418_yoonseop__Lab2.Models _301037418_yoonseop__Lab2.Models  5   	   *    $_301037418_yoonseop__Lab2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:_301037418_yoonseop__Lab2     5   	   AModels.clr-namespace:_301037418_yoonseop__Lab2.Models     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5
      � .+�5   
   �� -   5         ��Name$ createTableButton��5      $��Create table��6,   $
��Left=�6C   $��
317,61,0,0q�6^   $	��Top=�6r   $��75��6�   6�   �� 5   
   $��User email:��6   $
��Left=�6&   $��	30,61,0,0q�6A   $	��Top=�6T   �� 5   
   $��Book Information��6   $
��Left=�6-   $	��275��6H   $��
19,119,0,0q�6U   $	��Top=�6i   $	��320��6�    J� RenderTransformOrigin$ 
-0.56,0.53&�6�   �� 5   
   $��GroupBox��6   $
��Left=�6%   $	��275��6@   $��344,119,0,0q�6M   $	��Top=�6b   $	��438��6z   $ 
-0.56,0.53&�6�   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ DataGrid��5         AutoGenerateColumns . $
��Left=�6D   $	��226��6_   $��	10,10,0,0q�6l   $	��Top=�6   $	��406��6�   5      �� 5   
   -   5        $ getBookListButton��5      $��Get your book list��6,   $
��Left=�6I   $��
409,61,0,0q�6d   $	��Top=�6x   $	��107��6�   $ 	0.103,0.4&�6�   6�   �� 5   
   -   5        $ addSnapsnotButton��5      $��Add snapshot��6,   $
��Left=�6C   $��
534,61,0,0q�6^   $	��Top=�6r   $��92��6�   6�   �� 5   
   -   5        $ displaySnapShotButton��5      $��Display snapshot��60   $
��Left=�6K   $��
643,61,0,0q�6f   $	��Top=�6z   $	��104��6�   6�   �� 5   
   -   5         ��Name$ emailTextbox��5      $
��Left=�6(   $��23��6C   $��
124,64,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��120��6�   �� 5   
   $
��ISBN��6   $
��Left=�6   $��
41,178,0,0q�6:   $	��Top=�6N   $ 0.971,0.308&�6f   �� 5   
   -   5        $ ISBNTextbox��5      $
��Left=�6'   $��23��6B   $��159,181,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��120��6�   �� 5   
   $��Author1��6   $
��Left=�6"   $��
41,215,0,0q�6=   $	��Top=�6Q   �� 5   
   -   5        $ Author1Textbox��5      $
��Left=�6*   $��23��6E   $��159,218,0,0q�6Q   $
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��120��6�   �� 5   
   $��Author2��6   $
��Left=�6"   $��
41,255,0,0q�6=   $	��Top=�6Q   �� 5   
   -	   5        $ Author2Textbox��5      $
��Left=�6*   $��23��6E   $��159,258,0,0q�6Q   $
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��120��6�   �� 5   
   $��Author3��6   $
��Left=�6"   $��
41,288,0,0q�6=   $	��Top=�6Q   �� 5   
   -
   5        $ Author3Textbox��5      $
��Left=�6*   $��23��6E   $��159,291,0,0q�6Q   $
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��120��6�   �� 5   
   $��Title��6   $
��Left=�6    $��
40,324,0,0q�6;   $	��Top=�6O   $ 1.312,1.077&�6g   �� 5   
   -   5        $ TitleTextbox��5      $
��Left=�6(   $��23��6C   $��159,327,0,0q�6O   $
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ clearButton��5      $��Clear��6&   $
��Left=�66   $��
41,360,0,0q�6Q   $	��Top=�6e   $��75��6}   6�   �� 5    
   -   5        $ addToMyBookshelfButton��5       $��Add to my bookshelf��61   $
��Left=�6O   $��159,360,0,0q�6j   $	��Top=�6   $	��156��6�   $ 	0.481,0.8&�6�   6�   5"      5#      