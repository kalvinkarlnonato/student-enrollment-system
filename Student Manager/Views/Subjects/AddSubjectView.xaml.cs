using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Student_Manager.ViewModels.Subjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace Student_Manager.Views.Subjects
{
    public sealed partial class AddSubjectView : Page
    {
        public AddSubjectViewModel ViewModel { get;} = new();
        public ContentDialog contentDialog { get; set; }

        private String[] programs = { "BSCRIM", "BSIT", "BEED", "BSAGRI" };
        public AddSubjectView()
        {
            this.InitializeComponent();
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

        private void AddMoreButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            contentDialog.Hide();
        }
    }
}
