using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RHGestor
{
    public partial class Adm : Form
    {
        public Adm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string senha, login;
                login = textBox1.Text;
                senha = textBox2.Text;

                if (login == "admin" && senha == "admin123")
                {
                    MessageBox.Show("Logado com sucesso!");
                    Entrevistador c;
                    c = new Entrevistador();
                    c.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Login inválido");
            }
            catch (Exception ex) { MessageBox.Show("Erro ao avançar: " + ex.Message); }
        }
    }
}
