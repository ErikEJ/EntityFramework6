﻿using System.Diagnostics;
using System.Reflection;
using System.Windows;
using Microsoft.VisualStudio.Shell;

namespace Microsoft.DbContextPackage.Dialogs
{
    public partial class AboutDialog
    {
        private readonly DbContextPackage _package;

        public AboutDialog(DbContextPackage package)
        {
            _package = package;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Version.Text = "Version " + Assembly.GetExecutingAssembly().GetName().Version;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CodeplexLink_Click(object sender, RoutedEventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            _package.DTE2.ItemOperations.Navigate("https://github.com/ErikEJ/EntityFramework6PowerTools");
        }

        private void GalleryLink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(
                "https://marketplace.visualstudio.com/items?itemName=ErikEJ.EntityFramework6PowerToolsCommunityEdition#review-details");
        }
    }
}