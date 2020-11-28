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
    public partial class FOperacional : Form
    {
        public FOperacional()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Pessoa obj;
                Lista.ler();

                int i = 0;
                obj = Lista.itens[Lista.itens.Count() - 1];

                if (rdbA1.Checked || rdbA2.Checked || rdbA3.Checked || rdbA4.Checked || rdbA5.Checked)
                {
                    if (rdbA1.Checked)
                    {
                        obj.setPont(1);
                    }
                    if (rdbA2.Checked)
                    {
                        obj.setPont(2);
                    }
                    if (rdbA3.Checked)
                    {
                        obj.setPont(3);
                    }
                    if (rdbA4.Checked)
                    {
                        obj.setPont(4);
                    }
                    if (rdbA5.Checked)
                    {
                        obj.setPont(5);
                    }
                    i++;
                }

                if (rdbB1.Checked || rdbB2.Checked || rdbB3.Checked || rdbB4.Checked || rdbB5.Checked)
                {
                    if (rdbB1.Checked)
                    {
                        obj.setPont(1);
                    }
                    if (rdbB2.Checked)
                    {
                        obj.setPont(2);
                    }
                    if (rdbB3.Checked)
                    {
                        obj.setPont(3);
                    }
                    if (rdbB4.Checked)
                    {
                        obj.setPont(4);
                    }
                    if (rdbB5.Checked)
                    {
                        obj.setPont(5);
                    }
                    i++;
                }

                string t = "";
                if (rdbC1.Checked || rdbC2.Checked || rdbC3.Checked)
                {
                    if (rdbC1.Checked)
                    {
                        obj.setPont(5);
                        t = rdbC1.Text;
                    }
                    if (rdbC2.Checked)
                    {
                        obj.setPont(1);
                        t = rdbC2.Text;
                    }
                    if (rdbC3.Checked)
                    {
                        obj.setPont(3);
                        t = rdbC3.Text;
                    }
                    i++;
                }
                if (!(textBox1.Text.Trim() == ""))
                {
                    i++;
                    obj.setDescr(textBox1.Text.Trim() + "\nTem transporte próprio? " + t);
                }

                //MessageBox.Show(obj.pontuacao.ToString() + obj.descr + " nome: " + obj.nome);

                if (i == 4)
                {
                    MessageBox.Show("Seus dados foram enviados com sucesso!");
                    Lista.gravar();
                    this.Close();

                }
                else
                    MessageBox.Show("Preencha todos os campos");

            }
            catch (Exception ex) { MessageBox.Show("Erro ao avançar: " + ex.Message); }
        }
    }
}
