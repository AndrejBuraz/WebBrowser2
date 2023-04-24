using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowserVjezba1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Navigacija(txtBoxURL.Text);
        }

        private void Navigacija(String adresa)
        {
            txtBoxURL.Text = adresa;
            if (String.IsNullOrEmpty(adresa)) return;
            if (adresa.Equals("about:blank")) return;
            if (!adresa.StartsWith("http://") && !adresa.StartsWith("https://"))
            {
                adresa = "http://" + adresa;
            }
            if (!adresa.EndsWith(".com") && !adresa.EndsWith(".org") && !adresa.EndsWith(".net") && !adresa.EndsWith(".co") && !adresa.EndsWith(".us"))
            {
                adresa = adresa + ".com";
            }
            try
            {
                webBrowser1.Navigate(new Uri(adresa));
            }
            catch (System.UriFormatException)
            {
                return;
            }
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }



        private void btnBookmark_Click(object sender, EventArgs e)
        {
            string adresa = txtBoxURL.Text;
            if (!adresa.EndsWith(".com") && !adresa.EndsWith(".org") && !adresa.EndsWith(".net") && !adresa.EndsWith(".co") && !adresa.EndsWith(".us"))
            {
                adresa = adresa + ".com";
            }
            boxURL.Items.Add(adresa);
        }

        private void boxURL_Click(object sender, EventArgs e)
        {
            Navigacija(boxURL.SelectedItem.ToString());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                webBrowser1.Navigate(openFileDialog.FileName);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowSaveAsDialog();
        }

        private void Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Navigacija(txtBoxURL.Text);
            }
        }

     


    }
}
