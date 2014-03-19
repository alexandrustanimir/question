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
    /// Interaction logic for QuestionControlxaml.xaml
    /// </summary>
    public partial class QuestionControlxaml : UserControl
    {

        private Question _currentQuestion;
        private void _loadContent(Question question)
        {
            this.DataContext = question;
            _currentQuestion = question;
            switch (question.GetQuestionType())
            {
                case QuestionType.BooleanQuestion:
                    {
                        foreach (var item in question.GetOptions())
                        {
                            lstAnswers.Items.Add(new RadioButton() { Content = item });
                        }
                        break;
                    }
                case QuestionType.FreeTextQuestion:
                    {
                        lstAnswers.Items.Add(new TextBox() { Text = "" ,Width=300});
                        break;

                    }
                case QuestionType.MultipleChoiceQuestion:
                    {
                        foreach (var item in question.GetOptions())
                        {
                            lstAnswers.Items.Add(new CheckBox() { Content = item });
                        }
                        break;
                    }

        }}
        public QuestionControlxaml(Question question)
        {
            InitializeComponent();

            _loadContent(question);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Answer a = new Answer();
            a.Id = Guid.NewGuid();
            a.IdQuestion = _currentQuestion.Id;
            switch (_currentQuestion.GetQuestionType())
            {
                case QuestionType.BooleanQuestion:
                    {
                        foreach (var item in lstAnswers.Items)
                        {
                            RadioButton rb = item as RadioButton;
                            if (rb != null && rb.IsChecked.HasValue && rb.IsChecked.Value)
                            {
                                a.AnswerList.Add(rb.Content.ToString());
                                break;
                            }
                        }
                        break;
                    }
                case QuestionType.FreeTextQuestion:
                    {
                          foreach (var item in lstAnswers.Items)
                          {
                              TextBox textbox = item as TextBox;
                              if( textbox == null || string.IsNullOrEmpty(textbox.Text))
                              {
                                  MessageBox.Show("No aswer!");
                                  return;
                              }
                              else
                              {
                                  a.AnswerList.Add(textbox.Text);
                              }
                          }
                          break;
                    }
                case QuestionType.MultipleChoiceQuestion:
                    {
                        foreach (var item in lstAnswers.Items)
                        {
                            CheckBox checkbox = item as CheckBox;
                            if (checkbox != null && checkbox.IsChecked.HasValue && checkbox.IsChecked.Value)
                            {
                                a.AnswerList.Add(checkbox.Content.ToString());
                            }
                        }
                        break;
                    }
            }
                    //submit the answer
                  if(  Repository.Repository.AddAnswer(a))
                  {
                      lstAnswers.Items.Clear();
                          List<Question> dataItems =  Repository.Repository.GetQuestions();
                      _loadContent(dataItems[new Random().Next() % dataItems.Count]);
                      
                  }



            
            }
        }
    }
