   M S B A M L   `   `   `  ����V  RDemeshkanОТКПривет, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:DemeshkanОТКПриветDemeshkanОТКПривет  5   	   ,    &DemeshkanОТКПривет.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:DemeshkanОТКПривет     5   	     � Title$0  *Окно добавления заказа��5   	   $	��550��6(   $	��800��65   $	��550��6A   $	��800��6Q   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Код пасуды��6   $��Center=�6&   $��Right=�6A   $��15q�6]   �� 5   
   -   5        $��Vessel��5      $��1��6D   ��6    �� *LaboratoryVesselId+6D   �� 5   
   $��Клиент��6   $��1��6"   $��Center=�6/   $��Right=�6J   $��15q�6f   �� 5   
   $��1��6   $��1��6#    �� Orientation$ 
Horizontal=�63   .+�5      �� -   5        $��CBClient��5       �� DisplayMemberPath$	 FIO��6J   $��15q�6b    �� SelectedItem 6'   �� *	Clients+6n   �� 5      -   5        $��AddNewClient��5   h   $��Новый клиент��6   $��5��6,   $��2��69   $	��100��6|   5      �� 5   
   $��Выбор услуги��6   $��2��6(   $	��Top=�65   $��Right=�6M   $��15q�6i   &   System.Windows.Controls.DataGrid  5   
   -   5        $��ServDataGrid��5   0   $��2��6   $��1��6       AutoGenerateColumns .  ��5      �� *listServicesViemodel+ 6@   �� *SelectedElement+   Columns 5       4  .System.Windows.Controls.DataGridComboBoxColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ Услуги��6)   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 69   -   5        Serv��
   DisplayMemberPath$

 Name��5!   �      SelectedItemBinding 6C   �� *selectedService+6�   5#      �� 5$   
   $��3��6   $��Дата заказа��6!   $��Center=�64   $��Right=�6O   $��15q�6k   �� 5%   
   -   5        $��	OrderDate��5%      $��1��6]   $��3��6m   ��6#   �� *	StartDate+ �� StringFormat$ {0:dd.MM.yyyy}��6m   �� 5&   
   $��4��6   $��Цена заказа��6!   $��Center=�64   $��Right=�6O   $��15q�6k   �� 5'   
   -   5        $��OrederPrice��5'      $��1��6<   $��4��6L   {�.  ��6%   �� *Price+6Y   �� 5(   
   -   5        $��Сохранить��5(      $��5��6%   $��2��62   6F   5)      5*      