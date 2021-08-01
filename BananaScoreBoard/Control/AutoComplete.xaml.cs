using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BananaScoreBoard.Control
{
    /// <summary>
    /// AutoComplete.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AutoComplete : UserControl
    {
        public AutoComplete()
        {
            InitializeComponent();
        }

        public delegate List<string> GetItemSource(string value);

        private GetItemSource _GetSuggestion = null;
        public GetItemSource GetSuggestion
        {
            get
            {
                return _GetSuggestion;
            }
            set
            {
                _GetSuggestion = value;
            }
        }

        private static DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(AutoComplete), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        
        /*
        private static void TextChanged(DependencyObject property, DependencyPropertyChangedEventArgs args)
        {
            AutoComplete auto_complete = property as AutoComplete;
            string old_value = args.OldValue as string;
            string new_value = args.NewValue as string;
            //auto_complete.AutoCompleteText.Text = new_value;
        }
        */

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }



        private bool isSuggestionOpened()
        {
            return AutoCompletePopup.IsOpen;
        }
        private void OpenAutoSuggestion()
        {
            AutoCompletePopup.Visibility = Visibility.Visible;
            AutoCompletePopup.IsOpen = true;
            AutoCompleteSuggestion.Visibility = Visibility.Visible;
        }

        private void CloseAutoSuggestion()
        {
            AutoCompletePopup.Visibility = Visibility.Collapsed;
            AutoCompletePopup.IsOpen = false;
            AutoCompleteSuggestion.Visibility = Visibility.Collapsed;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Down :
                    {
                        if (isSuggestionOpened())
                        {
                            int count = AutoCompleteSuggestion.Items.Count;
                            int index = AutoCompleteSuggestion.SelectedIndex;
                            AutoCompleteSuggestion.SelectedIndex = (index + 1) % count;
                            
                        }
                        else
                        {
                            if (AutoCompleteSuggestion.Items.Count > 0)
                                OpenAutoSuggestion();
                        }
                    }
                    break;
                case Key.Up:
                    {
                        if (isSuggestionOpened())
                        {
                            int count = AutoCompleteSuggestion.Items.Count;
                            int index = AutoCompleteSuggestion.SelectedIndex;
                            AutoCompleteSuggestion.SelectedIndex = index -1 < 0 ? count -1 : index -1;
                            
                        }
                        else
                        {
                            if (AutoCompleteSuggestion.Items.Count > 0)
                                OpenAutoSuggestion();
                        }
                    }
                    break;
                case Key.Escape:
                    {
                        if (isSuggestionOpened())
                        {
                            AutoCompleteSuggestion.SelectedIndex = -1;
                        }
                    }
                    break;
                case Key.Back:
                case Key.Delete:
                    {
                        isDeleting = true;
                    }
                    break;

                case Key.Enter:
                    {
                        SelectionConfirmed();
                    }
                    break;
            }
            
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isSuggesting == true)
            {
                isSuggesting = false;
                return;
            }

           bool denySuggestion = false;
            if (isDeleting)
            {
                isDeleting = false;
                denySuggestion = true;
            }

           string text = AutoCompleteText.Text;
            
           if (String.IsNullOrEmpty(text))
            {
                CloseAutoSuggestion();
                return;
            }

            var itemsSource = GetSuggestion == null ? new List<string> { } : GetSuggestion(text);
            AutoCompleteSuggestion.ItemsSource = itemsSource;
            if (itemsSource.Count != 0)
            {
                if (denySuggestion == false)
                {
                    Suggest(SuggestionSendor.Key, itemsSource[0]);
                }
                OpenAutoSuggestion();
            }
            else
            {
                CloseAutoSuggestion();
            }

        }

        bool isDeleting = false;
        


        enum SuggestionSendor
        {
            Key,
            Selection,
        }
        string original_text = "";
        bool isSuggesting = false;

        private void Suggest(SuggestionSendor sendor, string suggestion_text)
        {

            switch(sendor)
            {
                case SuggestionSendor.Key:
                    {
                        original_text = AutoCompleteText.Text;
                    }
                    break;

                case SuggestionSendor.Selection:
                    {
                        
                    }
                    break;
            }

            isSuggesting = true;
            AutoCompleteText.Text = suggestion_text;

            this.Dispatcher.InvokeAsync(() =>
            {
                int original_text_length = original_text.Length;
                int suggestion_text_length = suggestion_text.Length;
                AutoCompleteText.Focus();
                AutoCompleteText.SelectionStart = original_text_length;
                AutoCompleteText.SelectionLength = suggestion_text_length - original_text_length;
            });
        }

        private void SelectionConfirmed()
        {
            Text = AutoCompleteText.Text;
            CloseAutoSuggestion();

            AutoCompleteText.SelectionStart = AutoCompleteText.Text.Length;
            original_text = "";
            isSuggesting = false;
        }

        private void AutoCompleteSuggestion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (AutoCompleteSuggestion.SelectedIndex <= -1)
            {
                CloseAutoSuggestion();
                return;
            }

            Suggest(SuggestionSendor.Selection, AutoCompleteSuggestion.SelectedItem.ToString());
        }
    }
}
