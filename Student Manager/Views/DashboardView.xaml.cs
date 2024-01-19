using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace Student_Manager.Views
{
    public sealed partial class DashboardView : Page
    {
        Frame rootFrame = null;

        public DashboardView()
        {
            this.InitializeComponent();
        }

        private void prevButton_Click(object sender, RoutedEventArgs e)
        {
            if (rootFrame.CanGoBack) rootFrame.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if(e.Parameter != null && e.Parameter is Frame frame)
            {
                rootFrame = frame;
            }
        }

        private void StudentButton_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = ((App)Application.Current).RootFrame;
            Frame.Navigate(typeof(StudentView), rootFrame);
        }

        private void SubjectButton_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = ((App)Application.Current).RootFrame;
            Frame.Navigate(typeof(SubjectView), rootFrame);
        }

        private void EnlistmentButton_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = ((App)Application.Current).RootFrame;
            Frame.Navigate(typeof(EnlistmentView), rootFrame);
        }
    }
}
