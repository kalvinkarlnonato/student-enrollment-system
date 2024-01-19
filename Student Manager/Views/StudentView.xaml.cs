using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Student_Manager.Views.Students;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Search;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Student_Manager.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StudentView : Page
    {
        Frame rootFrame = null;
        System.Collections.ObjectModel.ObservableCollection<StudentModel> MyData = new System.Collections.ObjectModel.ObservableCollection<StudentModel>();
        public StudentView()
        {
            this.InitializeComponent();
            MyData.Add(new StudentModel() { StudentNumber = "22-20321"});
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
            var yourPage = new AddStudentView();
            var yourDialog = new ContentDialog()
            {
                XamlRoot = XamlRoot,
                Content = yourPage
            };
            yourPage.contentDialog = yourDialog;
            await yourDialog.ShowAsync();

            //Get the return result of SearchPage
            var yourPageResult = yourPage.result;
        }
    }
    public class StudentModel
    {
        public String StudentNumber { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Ex { get; set; }
        public String College { get; set; }
        public String Course { get; set; }
        public String Major { get; set; }
        public String YearLevel { get; set; }
        public String EntryDate { get; set; }
        public String Status { get; set; }
        public String DateOfBirth { get; set; }
        public String Sex { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String Province { get; set; }
        public String Scheme { get; set; }
    }
}
