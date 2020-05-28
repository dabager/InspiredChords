using InspiredChords.Lib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace InspiredChords.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Progression prog = new Progression(Note.C, ScaleType.Major);

            string s = "";

            foreach (var item in prog.Chords)
            {
                s += item.Root + " " + item.Type + " | ";
            }

            MessageBox.Show(s);
            Application.Current.Shutdown();
        }
    }
}
