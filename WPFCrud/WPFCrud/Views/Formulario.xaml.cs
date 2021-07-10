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
using WPFCrud.ViewModels;
using WPFCrud.Model;

namespace WPFCrud.Views
{
    /// <summary>
    /// Lógica de interacción para Formulario.xaml
    /// </summary>
    public partial class Formulario : Page
    {
        public int Id = 0;
        private PersonViewModel2 personViewModel = new PersonViewModel2();
        public Formulario(int Id=0)
        {
            InitializeComponent();
            this.Id = Id;
            if (this.Id != 0) {

                var person = personViewModel.GetOne(this.Id);
                TxtEdad.Text = person.Age.ToString();
                TxtNombre.Text = person.Name;
            }
        }

        private async Task Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            if (Id == 0)
            {
                var person = new person();
                person.Name = TxtNombre.Text;
                person.Age = int.Parse(TxtEdad.Text);
                await personViewModel.AddAsync(person);
            }
            else {
                var person = new person();

                person.Id = Id;
                person.Name = TxtNombre.Text;
                person.Age = int.Parse( TxtEdad.Text);

                await personViewModel.updateAsync(person);
            }
        }
    }
}
