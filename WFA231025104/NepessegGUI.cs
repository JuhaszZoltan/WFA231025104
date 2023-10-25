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

namespace WFA231025104
{
    public partial class NepessegGUI : Form
    {
        public NepessegGUI()
        {
            InitializeComponent();
            btnKilepes.Click += BtnKilepes_Click;
            btnMentes.Click += BtnMentes_Click;
        }

        private void BtnKilepes_Click(object sender, EventArgs e) 
            => Application.Exit();
        private void BtnMentes_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtFovarosLakossaga.Text) > int.Parse(txtNepesseg.Text))
            {
                lblHibauzenet.Text = "A főváros lakossága nem lehet több a népességnél!";
                txtFovarosLakossaga.Text = txtNepesseg.Text;
            }
            else
            {
                using (var sw = new StreamWriter(@"..\..\src\ujadat.txt", true, Encoding.UTF8))
                {
                    sw.WriteLine(
                        $"{txtOrszag.Text};" +
                        $"{txtTerulet.Text};" +
                        $"{txtNepesseg.Text};" +
                        $"{txtFovaros.Text};" +
                        $"{txtFovarosLakossaga.Text}");
                }
                lblHibauzenet.Text = "A mentés sikeres!";
            }
        }

    }
}
