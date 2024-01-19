using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Student_Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace Student_Manager.Views
{
    public sealed partial class EnlistmentView : Page
    {
        Frame rootFrame = null;

        EnlistmentViewModel ViewModel { get; } = new();

        System.Collections.ObjectModel.ObservableCollection<EnlistmentModel> applicants = new System.Collections.ObjectModel.ObservableCollection<EnlistmentModel>();
        System.Collections.ObjectModel.ObservableCollection<EnlistmentModel> enrolled = new System.Collections.ObjectModel.ObservableCollection<EnlistmentModel>();

        private String[] programs = { "BSCRIM", "BSIT", "BEED", "BSAGRI" };

        public EnlistmentView()
        {
            this.InitializeComponent();
            applicants.Add(new EnlistmentModel() { StudentNumber = "22-23021", Name = "123" });
            applicants.Add(new EnlistmentModel() { StudentNumber = "22-23022", Name = "qwe" });
            applicants.Add(new EnlistmentModel() { StudentNumber = "22-23023", Name = "asd" });
            applicants.Add(new EnlistmentModel() { StudentNumber = "22-23024", Name = "zxc" });


            foreach (String program in programs)
            {
                this.ProgramMenuLayout.Items.Add(
                    new MenuFlyoutItem
                    {
                        Text = program.ToString(),
                        Command = ViewModel.ChangeProgramCommand,
                        CommandParameter = program,
                    });
            }
        }

        private void prevButton_Click(object sender, RoutedEventArgs e)
        {
            if (rootFrame.CanGoBack) rootFrame.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null && e.Parameter is Frame frame)
            {
                rootFrame = frame;
            }
        }

        private async void EnlistButton_Click(object sender, RoutedEventArgs e)
        {
            Button enlistButton = (Button)sender;
            bool containsItem = enrolled.Any(item => item.StudentNumber == applicants[applicantsGrid.SelectedIndex].StudentNumber);
            if(containsItem) {
                ContentDialog dialog = new ContentDialog() { Title = "Existing item found", Content = "This student is already enlisted", CloseButtonText = "OK" };
                dialog.XamlRoot = enlistButton.XamlRoot;
                await dialog.ShowAsync();
                return;
            }

            foreach (EnlistmentModel applicant in applicantsGrid.SelectedItems)
            {
                enrolled.Add(applicant);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            enrolled.Clear();
            TextBox x = (TextBox)sender;
            String strSearch = x.Text.ToUpper();
            List<EnlistmentModel> a = applicants.Where(a => a.StudentNumber.ToUpper().Contains(strSearch)).ToList();
            foreach (EnlistmentModel applicant in a)
            {
                enrolled.Add(applicant);
            }
        }
    }
    public class EnlistmentModel
    {
        public String StudentNumber { get; set; }
        public String Name { get; set; }
    }
}
