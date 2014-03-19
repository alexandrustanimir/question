using Model;
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

namespace Questions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            switch(btnStart.Content.ToString())
            {
                case  "Start":
                    {
                        List<Question> dataItems =  Repository.Repository.GetQuestions();
                        content.Children.Add(new QuestionControlxaml(dataItems[new Random().Next() % dataItems.Count]));
                        btnStart.Content = "Stop";
                        break;

                    }
                case  "Stop" :
                    {
                        btnStart.Content = "Start";
                        content.Children.Clear();
                        content.UpdateLayout();
                        break;
                    }
            }
        }
    }
}
