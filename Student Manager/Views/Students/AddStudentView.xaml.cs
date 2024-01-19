using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Student_Manager.ViewModels.Students;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace Student_Manager.Views.Students
{
    public sealed partial class AddStudentView : Page
    {
        public AddStudentViewModel ViewModel { get; } = new();
        public ContentDialog contentDialog { get; set; }
        public MyResult result { get; set; }
        private String[] programs = { "BSCRIM", "BSIT", "BEED", "BSAGRI" };
        public AddStudentView()
        {
            this.InitializeComponent();
            foreach (String program in programs)
            {
                this.SelectLanguageMenuLayout.Items.Add(
                    new MenuFlyoutItem
                    {
                        Text = program.ToString(),
                        Command = ViewModel.ChangeLanguageCommand,
                        CommandParameter = program,
                    });
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Data after simulated search
            result = new MyResult() { Id = 1, Name = "a" };
            contentDialog.Hide();
        }

        private void MenuMaleFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            genderDropdown.Content = "Male";
        }
        private void MenuFemaleFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            genderDropdown.Content = "Female";
        }


    }
    public class MyResult
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
