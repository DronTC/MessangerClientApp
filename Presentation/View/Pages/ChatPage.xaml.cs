﻿using MessangerClientApp.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MessangerClientApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChatPage.xaml
    /// </summary>
    public partial class ChatPage : Page
    {
        public ChatPage(ChatViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }
    }
}
