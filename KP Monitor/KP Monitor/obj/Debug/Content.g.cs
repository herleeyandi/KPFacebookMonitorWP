﻿#pragma checksum "C:\Users\Herleeyandi\documents\visual studio 2013\Projects\KP Monitor\KP Monitor\Content.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0F69925A574770466515359749B10005"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Facebook.Client.Controls;
using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace KP_Monitor {
    
    
    public partial class Content : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Panorama isi;
        
        internal Microsoft.Phone.Controls.PanoramaItem login;
        
        internal System.Windows.Controls.TextBlock opening;
        
        internal Microsoft.Phone.Controls.PanoramaItem home;
        
        internal Microsoft.Phone.Controls.PanoramaItem post;
        
        internal Microsoft.Phone.Controls.PanoramaItem rule;
        
        internal Microsoft.Phone.Controls.PanoramaItem reward;
        
        internal Facebook.Client.Controls.LoginButton loginButton;
        
        internal Facebook.Client.Controls.ProfilePicture profilePicture;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/KP%20Monitor;component/Content.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.isi = ((Microsoft.Phone.Controls.Panorama)(this.FindName("isi")));
            this.login = ((Microsoft.Phone.Controls.PanoramaItem)(this.FindName("login")));
            this.opening = ((System.Windows.Controls.TextBlock)(this.FindName("opening")));
            this.home = ((Microsoft.Phone.Controls.PanoramaItem)(this.FindName("home")));
            this.post = ((Microsoft.Phone.Controls.PanoramaItem)(this.FindName("post")));
            this.rule = ((Microsoft.Phone.Controls.PanoramaItem)(this.FindName("rule")));
            this.reward = ((Microsoft.Phone.Controls.PanoramaItem)(this.FindName("reward")));
            this.loginButton = ((Facebook.Client.Controls.LoginButton)(this.FindName("loginButton")));
            this.profilePicture = ((Facebook.Client.Controls.ProfilePicture)(this.FindName("profilePicture")));
        }
    }
}

