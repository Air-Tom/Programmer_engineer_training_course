﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Itmo.CSDesktopApp.WinFormsLab_2_TestList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (peopleList.Text.Length != 0)
            {
                memberList.Items.Add(peopleList.Text);
            }
            else MessageBox.Show("Выберите элемент из списка или введите новый");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            while (memberList.CheckedIndices.Count > 0)
                memberList.Items.RemoveAt(memberList.CheckedIndices[0]);
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            memberList.Sorted = true;
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            peopleList.Items.Clear();
            FileStream fStream = new FileStream("D:\\Учебный курс_Инженер-программист\\6 Разработка Windows-приложений на C#\\Itmo.Labs\\WindowsForms\\Lab2\\Itmo.CSDesktopApp.WinFormsLab_2_TestList\\XMLData.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            XmlDocument xmlDoc = new XmlDocument(); 
            xmlDoc.Load(fStream);
            for (int i = 0; i < xmlDoc.DocumentElement.ChildNodes.Count; i++)
            {
                peopleList.Items.Add(xmlDoc.DocumentElement.ChildNodes[i].InnerText);
            }

            fStream.Close();
        }
    }
}
