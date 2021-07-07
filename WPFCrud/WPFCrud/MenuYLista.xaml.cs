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

namespace WPFCrud
{
    /// <summary>
    /// Lógica de interacción para MenuYLista.xaml
    /// </summary>
    public partial class MenuYLista : Page
    {
        public MenuYLista()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh() {
            List<PersonViewModel> lst = new List< PersonViewModel>();
            using (Model.WPFCrudEntities db = new Model.WPFCrudEntities()) {
                lst = (from d in db.person
                       select new PersonViewModel
                       {
                           Name = d.Name,
                           Age = d.Age,
                           Id = d.Id
                       }).ToList();
            }
            GrdDatos.ItemsSource = lst;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.StaticMainFrame.Content = new Formulario();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;
            using (Model.WPFCrudEntities db = new Model.WPFCrudEntities()) {
                var oPerson = db.person.Find(Id);
                db.person.Remove(oPerson);
                db.SaveChanges();
            }
            Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;
            Formulario pFormulario = new Formulario(Id);
            MainWindow.StaticMainFrame.Content = pFormulario;
        }
    }

    public class PersonViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
    }
}
