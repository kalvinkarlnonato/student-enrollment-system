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
    public sealed partial class LoginView : Page
    {
        public LoginView()
        {
            this.InitializeComponent();
        }

        private async void MessageBox(String title, String content,String closeText, Button control)
        {
            ContentDialog dialog = new ContentDialog() { Title = title, Content = content, CloseButtonText = closeText };
            dialog.XamlRoot = control.XamlRoot;
            await dialog.ShowAsync();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string greet;
            //if(nameTextbox.Text == String.Empty)
            //{
            //    MessageBox("Invalid","Please enter your name","OK",(Button)sender);
            //    return;
            //}
            if (DateTime.Now.Hour <= 12) greet = "Good Morning";
            else if (DateTime.Now.Hour <= 16) greet = "Good Afternoon";
            else if (DateTime.Now.Hour <= 20) greet = "Good Evening";
            else greet = "Good night";
            MessageBox(greet, "Welcome to student management system. Please rate my work on my page and i am open for suggestions.", "OK", (Button)sender);
            Frame rootFrame = ((App)Application.Current).RootFrame;
            Frame.Navigate(typeof(DashboardView), rootFrame);
        }
    }
}
