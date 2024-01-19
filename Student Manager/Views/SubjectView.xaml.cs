using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Student_Manager.Views.Subjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Student_Manager.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SubjectView : Page
    {
        Frame rootFrame = null;
        System.Collections.ObjectModel.ObservableCollection<SubjectModel> MyData = new System.Collections.ObjectModel.ObservableCollection<SubjectModel>();
        public SubjectView()
        {
            this.InitializeComponent();
            MyData.Add(new SubjectModel() { Course = "BSIT" });
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

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var yourPage = new AddSubjectView();
            var yourDialog = new ContentDialog()
            {
                XamlRoot = XamlRoot,
                Content = yourPage
            };
            yourPage.contentDialog = yourDialog;
            await yourDialog.ShowAsync();
        }
    }
    public class SubjectModel
    {
        public String Course { get; set; }
        public int Year { get; set; }
        public String Code { get; set; }
        public String Description { get; set; }
        public int Units { get; set; }
    }
}
