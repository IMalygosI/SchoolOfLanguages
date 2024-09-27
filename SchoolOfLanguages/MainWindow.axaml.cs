using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SchoolOfLanguages.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolOfLanguages
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            sill();
        }
        private void sill()
        {
            List<Client> ClientsCruzer = Helper.DataBase.Clients.Include(x => x.VisitLists).Include(x => x.ListTags).ToList();
            
            if (SearchTextBox == null) return;
            if (!string.IsNullOrEmpty(SearchTextBox.Text))
            {
                ClientsCruzer = ClientsCruzer.Where(z =>
                    z.Name.ToLower().Contains(SearchTextBox.Text!.ToLower()) ||
                    z.LastName.ToLower().Contains(SearchTextBox.Text!.ToLower()) ||
                    z.Patronymic.ToLower().Contains(SearchTextBox.Text!.ToLower()) ||
                    z.Email.ToLower().Contains(SearchTextBox.Text!.ToLower()) ||
                    z.Phone.ToLower().Contains(SearchTextBox.Text!.ToLower())).ToList();
            }
            if (ComboxOne == null) return;
            switch (ComboxOne.SelectedIndex)
            {
                case 0:
                    ClientsCruzer = ClientsCruzer.ToList();
                    break;
                case 1:
                    ClientsCruzer = ClientsCruzer.Where(x => x.gender == "Ìóæ.").ToList();
                    break;
                case 2:
                    ClientsCruzer = ClientsCruzer.Where(x => x.gender == "Æåí.").ToList();
                    break;
                default: ClientsCruzer = ClientsCruzer.ToList(); break;
            }
            if (ComboxTwo == null) return;
            switch (ComboxTwo.SelectedIndex)
            {
                case 0:
                    ClientsCruzer = ClientsCruzer.ToList();
                    break;
                case 1:
                    ClientsCruzer = ClientsCruzer.OrderBy(x => x.Name).ToList();
                    break;
                case 2:
                    ClientsCruzer = ClientsCruzer.OrderBy(x => x.Last_visit_date).ToList();
                    break;
                case 3:
                    ClientsCruzer = ClientsCruzer.OrderByDescending(x => x.Countvisit).ToList();
                    break;
                default: ClientsCruzer = ClientsCruzer.ToList(); break;
            }

            switch (PageNavig.SelectedIndex)
            {
                case 0:
                    ClientsCruzer = ClientsCruzer.ToList(); 
                    break;
            }
            if (galoschka == null) return;
            if (galoschka.IsChecked == true)
            {
                ClientsCruzer = ClientsCruzer.Where(x => x.DateOfBirth.Month == DateAndTime.Now.Month).ToList();
            }
            else
            {
                ClientsCruzer = ClientsCruzer.ToList();
            }
            List_Box.ItemsSource = ClientsCruzer.ToList();
        }
        private void DeliteServices_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)(sender as Button)!.Tag!;
            var client = Helper.DataBase.Clients.Find(id);

            if (client != null)
            {
                if (client.VisitLists.Count <= 0)
                {
                    Helper.DataBase.Clients.Remove(client);
                    Helper.DataBase.SaveChanges();
                    sill();
                }
                else
                {
                    Console.WriteLine("Óäàëåíèå êëèåíòîâ ñ ïîñåùåíèÿìè çàïðåùåíî");
                }
            }
        }
        private void New_Pokz_Button(object sender, RoutedEventArgs e)
        {
            Redact redandAdd = new Redact();
            redandAdd.Show();
            Close();
        }
        public void Redact(object? sender, PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            var client = List_Box.SelectedItem as Client;
            Redact redandAdd = new Redact(client);
            redandAdd.Show();
            Close();
        }
        private void ComboBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e) => sill();
        private void SortCombobox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e) => sill();
        private void TextBox_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e) => sill();
        private void CheckBox_Checked(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => sill();
        private void CheckBox_Unchecked(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => sill();
        private void PageNavig_Selection(object? sender, Avalonia.Controls.SelectionChangedEventArgs e) => sill();
    }
}
