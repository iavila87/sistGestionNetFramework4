using SistemaIndumaq.Resources.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataDB.Repositories;
using DataDB.Models;

namespace SistemaIndumaq
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // instancias Y faltan las demas
            //IMainView view = new FormMain();
            //IProductRepository repository = new ProductRepository();
            //new MainPresenter(view);
            // ...
            // ...

            Application.Run(new FormLogin());
            //Application.Run((Form)view);
        }
    }
}
