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
    public partial class Entrevistador : Form
    {
        public Entrevistador()
        {
            InitializeComponent();
            preencher();

        }
        private void preencher()
        {
            Lista.ler();

            //Lista que adiciona os CPFs no combobox para seleção

            comboBox1.Items.Clear();
            for (int i = 0; i < Lista.itens.Count; i++)
            {
                comboBox1.Items.Add(Lista.itens[i].cpf);
            }
                

            // Preenchimento do listbox
            double pont;
            try
            {
                for (int i = 0; i < Lista.itens.Count; i++)
                {
                    pont = (Lista.itens[i].pontuacao * 100) / 20;
                    this.listBox1.Items.Add("CPF: " + Lista.itens[i].cpf + "    | Nome: " + Lista.itens[i].nome + "    | Pontuação: " + pont + "%       | Residência: " + Lista.itens[i].endRes + "   | Formação: " + Lista.itens[i].escolaridade + "     | Dep: " + Lista.itens[i].departamento);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao preencher a tablea: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool achou = false;
            try
            {
                for (int i = 0; i < Lista.itens.Count; i++)
                {
                    if (comboBox1.SelectedItem.ToString() == Lista.itens[i].cpf)
                    {
                        MessageBox.Show("Resposta Dissertativa (CPF: " + comboBox1.SelectedItem.ToString() + ")"+Environment.NewLine +
                            Lista.itens[i].descr);
                        
                        achou = true;
                        break;
                    }
                }
                if (!achou)
                {
                    MessageBox.Show("CPF " + comboBox1.SelectedItem.ToString() + " não encontrado");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("CPF inválido: selecione um valor");
            }

        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            bool achou=false;
            try
            {
                //Este for ira percorrer a lista e achar o indice do CPF selecionado no combo
                for (int i = 0; i < Lista.itens.Count; i++)
                {
                    if (comboBox1.SelectedItem.ToString() == Lista.itens[i].cpf)
                    {
                        MessageBox.Show("CPF " + comboBox1.SelectedItem.ToString() + " apagado com sucesso!");
                        Lista.itens.RemoveAt(i);
                        this.listBox1.Items.Clear();
                        Lista.gravar();
                        preencher();
                        comboBox1.Text = "";
                        label2.Text = "";
                        achou = true;
                        break;
                    }
                }
                if (!achou)
                {
                    MessageBox.Show("CPF " + comboBox1.SelectedItem.ToString() + " não encontrado :(");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("CPF inválido: selecione um valor");
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            bool achou = false;
            try
            {
                for (int i = 0; i < Lista.itens.Count; i++)
                {
                    if (comboBox1.SelectedItem.ToString() == Lista.itens[i].cpf)
                    {
                        MessageBox.Show(
                            "Data de Nascimento: " + Lista.itens[i].dataNasc.ToShortDateString() + Environment.NewLine +
                            "RG: " + Lista.itens[i].rg + Environment.NewLine +
                            "Nome do Pai: " + Lista.itens[i].pai + Environment.NewLine +
                            "Nome do Mãe: " + Lista.itens[i].mae + Environment.NewLine +
                            "Telefone: " + Lista.itens[i].telefone + Environment.NewLine +
                            "Email: " + Lista.itens[i].email + Environment.NewLine +
                            "Cidade Natal: " + Lista.itens[i].endNatal + Environment.NewLine +
                            "");

                        
                        achou = true;
                        break;
                    }
                }
                if (!achou)
                {
                    MessageBox.Show("CPF " + comboBox1.SelectedItem.ToString() + " não encontrado :(");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("CPF inválido: selecione um valor");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < Lista.itens.Count; i++)
                {
                    if (comboBox1.SelectedItem.ToString() == Lista.itens[i].cpf)
                    {
                        label2.Text = Lista.itens[i].nome;
                        break;
                    }
                    else
                        label2.Text = "Selecione o CPF";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CPF inválido: selecione um valor");
            }
        }
    }
}
