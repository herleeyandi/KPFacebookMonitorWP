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
            this.profilePicture.Visibility = Visibility.Collapsed;
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
                //ApplicationBar.IsVisible = true;
                this.profilePicture.Visibility = Visibility.Visible;
                
            }
            else 
            {
                this.profilePicture.Visibility = Visibility.Collapsed;
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

        private string BuildUserInfoDisplay(Facebook.Client.GraphUser user)
        {
            var userInfo = new System.IO.StringWriter();

            // Example: typed access (name)
            // - no special permissions required
            userInfo.WriteLine(string.Format("Name: {0}", user.Name));
            userInfo.WriteLine();

            // Example: typed access (birthday)
            // - requires user_birthday permission
            userInfo.WriteLine(string.Format("Birthday: {0}", user.Birthday));
            userInfo.WriteLine();

            // Example: partially typed access, to location field,
            // name key (location)
            // - requires user_location permission
            userInfo.WriteLine(string.Format("City: {0}", user.Location.City));
            userInfo.WriteLine();

            // Example: access via property name (locale)
            // - no special permissions required
            userInfo.WriteLine(string.Format("Locale: {0}", user["locale"] ?? string.Empty));
            userInfo.WriteLine();

            // Example: access via key for array (languages) 
            // - requires user_likes permission
           

            return userInfo.ToString();
        }

        private async System.Threading.Tasks.Task RetriveUserInfo()
        {
            var client = new Facebook.FacebookClient(this.loginButton.CurrentSession.AccessToken);

            dynamic result = await client.GetTaskAsync("me");
            var currentUser = new Facebook.Client.GraphUser(result);

            this.userInfo.Text = this.BuildUserInfoDisplay(currentUser);
        }

        private void IsWait()
        {
            this.wait.Visibility = Visibility.Visible;
            this.waitteks.Visibility = Visibility.Visible;
            this.performanceProgressBar.IsIndeterminate = true;
            this.performanceProgressBar.Visibility = Visibility.Visible;
            ApplicationBar.IsVisible = false;
        }

        private void NotWait()
        {
            this.wait.Visibility = Visibility.Collapsed;
            this.waitteks.Visibility = Visibility.Collapsed;
            this.performanceProgressBar.IsIndeterminate = false;
            this.performanceProgressBar.Visibility = Visibility.Collapsed;
            ApplicationBar.IsVisible = true;
        }

        private void OnUserInfoChanged(object sender, Facebook.Client.Controls.UserInfoChangedEventArgs e)
        {
            IsWait();
            this.userInfo.Text = this.BuildUserInfoDisplay(e.User);
            NotWait();
        }

        private async void PublishStory()
        {
            isi.DefaultItem = post;
            IsWait();
            await this.loginButton.RequestNewPermissions("publish_stream");

            var facebookClient = new Facebook.FacebookClient(this.loginButton.CurrentSession.AccessToken);

            var postParams = new
            {
                /*
                name = "Facebook SDK for .NET",
                caption = "Build great social apps and get more installs.",
                description = "The Facebook SDK for .NET makes it easier and faster to develop Facebook integrated .NET apps.",
                link = "http://facebooksdk.net/",
                picture = "http://facebooksdk.net/assets/img/logo75x75.png"
                */
             

                message = postKata.Text
            };
            
            try
            {
                isi.DefaultItem = post;
                IsWait();
                dynamic fbPostTaskResult = await facebookClient.PostTaskAsync("/me/feed", postParams);
                var result = (IDictionary<string, object>)fbPostTaskResult;
                isi.DefaultItem = post;
                NotWait();
                MessageBox.Show("Post berhasil dilakukan");

            }
            catch (Exception ex)
            {
                NotWait();
                MessageBox.Show("Post gagal dilakukan");
               
            }
        }

        private void postfeed_Click(object sender, RoutedEventArgs e)
        {
            this.PublishStory();
        }

        private void loginButton_ManipulationStarted(object sender, System.Windows.Input.ManipulationStartedEventArgs e)
        {
            IsWait();
        }
       
    }

}