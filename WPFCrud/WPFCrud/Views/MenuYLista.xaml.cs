using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFCrud.Model;
using WPFCrud.ViewModels;

namespace WPFCrud.Views
{
    /// <summary>
    /// Lógica de interacción para MenuYLista.xaml
    /// </summary>
    public partial class MenuYLista : Page
    {
        private PersonViewModel2 personViewModel = new PersonViewModel2();
        public MenuYLista()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh() {
            GrdDatos.ItemsSource = personViewModel.GetAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.StaticMainFrame.Content = new Formulario();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;
            await personViewModel.delete(Id);
            Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;
            Formulario pFormulario = new Formulario(Id);
            MainWindow.StaticMainFrame.Content = pFormulario;
        }

        private async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selected = (ComboBoxItem)e.AddedItems[0];
            person selectedPerson = (person)GrdDatos.SelectedItem;

            switch (selected.Content)
            {
                case "Eliminar":
                    await personViewModel.delete(selectedPerson.Id);
                    Refresh();
                    break;
                case "Editar":
                    Formulario pFormulario = new Formulario(selectedPerson.Id);
                    MainWindow.StaticMainFrame.Content = pFormulario;
                    break;
            }
        }
    }
}
