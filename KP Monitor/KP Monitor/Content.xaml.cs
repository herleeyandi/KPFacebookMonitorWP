using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace KP_Monitor
{
    public partial class Content : PhoneApplicationPage
    {
        public Content()
        {
            InitializeComponent();
            this.home.Visibility = Visibility.Collapsed;
            this.post.Visibility = Visibility.Collapsed;
            this.rule.Visibility = Visibility.Collapsed;
            this.reward.Visibility = Visibility.Collapsed;
            this.LayoutRoot.Background = new SolidColorBrush(Colors.Blue);
            isi.Foreground = new SolidColorBrush(Colors.White);
            this.profilePicture.Visibility = Visibility.Collapsed;
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Help.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            this.login.Visibility = Visibility.Visible;
            opening.Text = "Thank you, to continue logout just click button below";
            login.Header = "logout";
            this.home.Visibility = Visibility.Collapsed;
            this.post.Visibility = Visibility.Collapsed;
            this.rule.Visibility = Visibility.Collapsed;
            this.reward.Visibility = Visibility.Collapsed;
            this.LayoutRoot.Background = new SolidColorBrush(Colors.Blue);
            isi.Foreground = new SolidColorBrush(Colors.White);
            this.login.Visibility = Visibility.Visible;          
            isi.DefaultItem = login;
            this.loginButton.Visibility = Visibility.Visible;
            ApplicationBar.IsVisible = false;
            this.profilePicture.Visibility = Visibility.Collapsed;
        }

        private void OnSessionStateChanged(object sender, Facebook.Client.Controls.SessionStateChangedEventArgs e)
        {
            if (e.SessionState == Facebook.Client.Controls.FacebookSessionState.Opened)
            {
                this.home.Visibility = Visibility.Visible;
                isi.DefaultItem = home;
                this.login.Visibility = Visibility.Collapsed;
                this.post.Visibility = Visibility.Visible;
                this.rule.Visibility = Visibility.Visible;
                this.reward.Visibility = Visibility.Visible;
                this.LayoutRoot.Background = new SolidColorBrush(Colors.White);
                isi.Foreground = new SolidColorBrush(Colors.Black);
                this.loginButton.Visibility = Visibility.Collapsed;
                ApplicationBar.IsVisible = true;
                this.profilePicture.Visibility = Visibility.Visible;
            }
            else 
            {
                this.home.Visibility = Visibility.Collapsed;
                this.post.Visibility = Visibility.Collapsed;
                this.rule.Visibility = Visibility.Collapsed;
                this.reward.Visibility = Visibility.Collapsed;
                this.LayoutRoot.Background = new SolidColorBrush(Colors.Blue);
                this.login.Visibility = Visibility.Visible;
                opening.Text = "Welcome to KP Facebook Monitor Application. To use you must login first by clicking the button below.";
                login.Header = "login first";
                isi.Foreground = new SolidColorBrush(Colors.White);
                isi.DefaultItem = login;
                this.loginButton.Visibility = Visibility.Visible;
                this.profilePicture.Visibility = Visibility.Collapsed;
            }
        }
       
    }
}