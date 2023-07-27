using System;
using System.Windows.Controls;
using System.Windows;
using System.Diagnostics;

namespace RevitFamilyBuilder.DialogWindows
{
    //-- Custom Dialog Window --//
    public class CustomDialog : Window
    {
        public CustomDialog(string message, string filePath)
        {
            Title = "Custom Dialog";
            Width = 300;
            Height = 150;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            StackPanel panel = new StackPanel();
            panel.Margin = new Thickness(10);

            TextBlock textBlock = new TextBlock();
            textBlock.Text = message;
            panel.Children.Add(textBlock);

            // Close dialog window
            Button okButton = new Button();
            okButton.Content = "OK";
            okButton.Click += (s, args) => { Close(); };
            panel.Children.Add(okButton);

            // Open snip image and close dialog window
            Button viewButton = new Button();
            viewButton.Content = "View Snip Image";
            viewButton.Click += (s, args) =>
            {
                try
                {
                    Process.Start(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while opening the image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                Close();
            };
            panel.Children.Add(viewButton);

            // Open snip directory in explorer and close dialog window
            Button directoryButton = new Button();
            directoryButton.Content = "Open Folder in Explorer";
            directoryButton.Click += (s, args) =>
            {
                string saveDir = $@"C:\Users\{Environment.UserName}\Downloads\";
                try
                {
                    Process.Start("explorer.exe", saveDir);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while opening the directory: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                Close();
            };
            panel.Children.Add(directoryButton);

            Content = panel;
        }
    }
}
