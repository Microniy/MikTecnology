using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace MikTecnologyNew
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        private ICollection<ILink> _projects;        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            object repository = null;
            Assembly ass = null;
            try
            {
                ass = Assembly.LoadFrom("TecnoComponents.dll");
            }
            catch(FileNotFoundException ex) 
            {
                MessageBox.Show(ex.Message);
            }
            if (ass != null)
            {
                repository = CreteBinding(ass);
                _projects = (repository as IRepository)?.GetProects();
                MenuProjects.ItemsSource = _projects;
            }
        }
        static object CreteBinding(Assembly a)
        {
            try
            {
                var Types = a.GetTypes();
                Type moocDB = null;
                foreach (Type t in Types)
                {
                    if(t.Name == "MoocDB")
                    {
                        moocDB = t;
                        break;
                    }
                } 
                object Repository = Activator.CreateInstance(moocDB);
                return Repository;
            }catch(Exception ex)
            {
               
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
