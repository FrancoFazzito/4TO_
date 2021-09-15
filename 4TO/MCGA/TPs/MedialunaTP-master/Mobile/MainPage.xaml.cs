using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=391641

namespace Mobile
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<Producto> lista { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            lista = new List<Producto>();
            cargarProductos();
        }

        private void cargarProductos()
        {
            Producto Medialuna = new Producto();
            Medialuna.ID = 1;
            Medialuna.descripcion = "Medialuna";
            Medialuna.imagen = "1.png";

            Producto Vigilante = new Producto();
            Vigilante.ID = 2;
            Vigilante.descripcion = "Vigilante";
            Vigilante.imagen = "2.png";

            Producto Tortita = new Producto();
            Tortita.ID = 3;
            Tortita.descripcion = "Tortita Negra";
            Tortita.imagen = "3.png";

            Producto Bolita = new Producto();
            Bolita.ID = 4;
            Bolita.descripcion = "Bolita de Fraile";
            Bolita.imagen = "4.png";

            lista.Add(Medialuna);
            lista.Add(Vigilante);
            lista.Add(Tortita);
            lista.Add(Bolita);
        }

      
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
