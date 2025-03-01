﻿using MyLib;
using MyLib.Models;
using MyLib.Presenters;
using MyLib.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMVP
{
    public partial class Form1 : Form, IUsersView
    {
        private UsersPresenter presenter_;

        public Form1()
        {
            InitializeComponent();
            presenter_ = new UsersPresenter(new MemoryUsersModel(), this, userCard);
        }

        public void Show(List<User> users)
        {
            UsersList.DataSource = null;
            UsersList.DataSource = users;
        }

        void NameFiltr_Click(object sender, EventArgs e)
        {
                presenter_.View__FiltrEvent(NameTextBox.Text, ComboBoxFiltr.Text);

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            presenter_.Model__RefreshLoadedInfoUsers();
            UsersList.Rows[0].Selected = true;
        
        }

        private void UsersList_SelectionChanged(object sender, EventArgs e)
        {
            presenter_.View__SelectedUser(UsersList.CurrentCell.RowIndex);
        }

        public int GetUserIndex()
        {
            return UsersList.CurrentCell.RowIndex;
        }

        private void UsersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
