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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            Pessoa obj;
            int i=0;
            try
            {
                Lista.ler();
                obj = new Pessoa();


                // A partir daqui teremos a validação de cada campo com seus respectivos requisitos

                if (!(txtNome.Text.Trim() == ""))
                {
                    if (txtNome.Text.Trim().Contains(" "))
                    {
                        obj.setNome(txtNome.Text);
                        i++;
                    }
                    else
                        MessageBox.Show("Digite o nome completo");
                    
                }
                else
                    MessageBox.Show("Campo Nome vazio");






                if (dtpNasc.Value < DateTime.Now)
                {
                    obj.setDataNasc(dtpNasc.Value);
                    i++;
                }
                else
                    MessageBox.Show("Data de nascimento inválida");





                if (!(txtCPF.Text.Trim() == ""))
                {
                    if (txtCPF.Text.Length == 11)
                    {
                        if (!(txtCPF.Text.Contains("-") || txtCPF.Text.Contains(".") || txtCPF.Text.Contains("/") || txtCPF.Text.Contains(" ")))
                        {
                            obj.setCPF(txtCPF.Text);
                            i++;
                        }
                        else
                            MessageBox.Show("Digite o CPF apenas com os digitos, sem pontos ou sinais");
                    }
                    else
                        MessageBox.Show("CPF: Quantidade de digitos inválida, escreva apenas o números sem sinais");
                }
                else
                    MessageBox.Show("Campo CPF vazio");





                if (!(txtRG.Text.Trim() == ""))
                {
                    if (txtRG.Text.Length <= 14)
                    {
                        if (!(txtRG.Text.Contains("-") || txtRG.Text.Contains(".") || txtRG.Text.Contains("/") || txtRG.Text.Contains(" ")))
                        {
                            obj.setRG(txtRG.Text);
                            i++;
                        }
                        else
                            MessageBox.Show("Digite o RG apenas com os digitos, sem pontos ou sinais");
                    }
                    else
                        MessageBox.Show("RG: Quantidade de digitos inválida, escreva apenas o números sem sinais");
                }
                else
                    MessageBox.Show("Campo RG vazio");





                if (!(txtMae.Text.Trim() == ""))
                {
                    if (txtMae.Text.Trim().Contains(" "))
                    {
                        obj.setMae(txtMae.Text);
                        i++;
                    }
                    else
                        MessageBox.Show("Digite o nome da mãe completo");
                }
                else
                    MessageBox.Show("Campo Nome da Mãe vazio");




                if (!(txtPai.Text.Trim() == ""))
                {
                    if (txtPai.Text.Trim().Contains(" "))
                    {
                        obj.setPai(txtPai.Text);
                        i++;
                    }
                    else
                        MessageBox.Show("Digite o nome do pai completo");
                }
                else
                    MessageBox.Show("Campo Nome do Pai vazio");




                if (!(txtCidadeNatal.Text == "" || cmbEstadoN.SelectedItem == null))
                {
                    obj.setEndNatal(txtCidadeNatal.Text + " - " + cmbEstadoN.SelectedItem.ToString());
                    i++;
                }
                else
                    MessageBox.Show("Complete o endereço da cidade natal");




                if (!(txtCidadeRes.Text == "" || cmbEstadoR.SelectedItem == null))
                {
                    obj.setEndRes(txtCidadeRes.Text + " - " + cmbEstadoR.SelectedItem.ToString());
                    i++;
                }
                else
                    MessageBox.Show("Complete o endereço da cidade residencial");




                if (!(cmbEnsino.SelectedItem==null))
                {
                    if (rdbComp.Checked || rdbIncomp.Checked)
                    {
                        string status;
                        if (rdbComp.Checked)
                            status = rdbComp.Text;
                        else
                            status = rdbIncomp.Text;

                        obj.setEscolaridade(cmbEnsino.SelectedItem.ToString() + " " + status + " em " + txtCurso.Text + " (" + textBox1.Text + ")");
                        i++;
                    }
                    else
                        MessageBox.Show("Preencha os campos da escolaridade");
                }
                else
                    MessageBox.Show("Preencha os campos da escolaridade");


                if (txtTelefone.Text != "" || txtTelefone.Text.Length>10)
                {
                    obj.setTelefone(txtTelefone.Text);
                    i++;
                }
                else
                    MessageBox.Show("Digite o telefone apenas com números começando pelo DDD");


                if (txtEmail.Text != "" || txtEmail.Text.Contains("@") || txtEmail.Text.Contains(".com"))
                {
                    obj.setEmail(txtEmail.Text);
                    i++;
                }
                else
                    MessageBox.Show("Digite um email válido");



                if (cmbDep.SelectedItem != null) 
                {
                    obj.setDep(cmbDep.SelectedItem.ToString());
                    i++;
                }
                else
                    MessageBox.Show("Selecione um departamento");


                int cb = 0;
                if (cbDialogo.Checked)
                {
                    obj.setPont(1);
                    cb++;
                }
                if (cbFalar.Checked)
                {
                    obj.setPont(1);
                    cb++;
                }
                if (cbRiscos.Checked)
                {
                    obj.setPont(1);
                    cb++;
                }
                if (cb < 3)
                {
                    if (cbExcelencia.Checked)
                    {
                        obj.setPont(1);
                        cb++;
                    }
                }
                if (cb < 3)
                {
                    if (cbEscutar.Checked)
                    {
                        obj.setPont(2);
                        cb++;
                    }
                }
                if (cb < 3)
                {
                    if (cbPersistencia.Checked)
                    {
                        obj.setPont(2);
                        cb++;
                    }
                }


                if (i == 12) // É confirmado se os 12 campos foram preenchidos, caso contrário os itens não serão validados
                {
                    /*
                     * Message Box para confirmar se os dados tiveram a entrada devida
                     * 
                    MessageBox.Show(obj.nome + "\n" + obj.dataNasc + "\n" + obj.cpf + " - " +
                    obj.rg + "\n" + obj.mae + " " + obj.pai + "\n" + obj.endNatal + "\n" + obj.endRes + "\n" +
                    obj.escolaridade + "\n" + obj.telefone + " - " + obj.email + "\n" + i);
                    */

                    MessageBox.Show("Dados pessoais salvos com sucesso! Prossiga a próxima página");

                    Lista.itens.Add(obj);
                    Lista.gravar();

                    if (cmbDep.SelectedItem.ToString() == "Logistica")
                    {
                        FLogistica c;
                        c = new FLogistica();
                        c.Show();
                    }
                    if (cmbDep.SelectedItem.ToString() == "Compras")
                    {
                        FCompras c;
                        c = new FCompras();
                        c.Show();
                    }

                    if (cmbDep.SelectedItem.ToString() == "Operacional")
                    {
                        FOperacional c;
                        c = new FOperacional();
                        c.Show();
                    }

                    //limpando textBoxes
                    txtCidadeNatal.Text = "";
                    txtCidadeRes.Text = "";
                    txtCPF.Text = "";
                    txtCurso.Text = "";
                    txtEmail.Text = "";
                    txtMae.Text = "";
                    txtNome.Text = "";
                    txtPai.Text = "";
                    txtRG.Text = "";
                    txtTelefone.Text = "";
                    //limpando comboBoxes
                    cmbDep.SelectedItem = null;
                    cmbEnsino.SelectedItem = null;
                    cmbEstadoN.SelectedItem = null;
                    cmbEstadoR.SelectedItem = null;
                    //limpandoCheckBoxes
                    cbFalar.Checked = false;
                    cbDialogo.Checked = false;
                    cbEscutar.Checked = false;
                    cbExcelencia.Checked = false;
                    cbRiscos.Checked = false;
                    cbPersistencia.Checked = false;
                    dtpNasc.Value = DateTime.Now;
                }
                else
                    MessageBox.Show("Preencha os campos de forma válida");
                
            }
            catch (Exception ex) { MessageBox.Show("Erro ao avançar: " + ex.Message); }
        }

        private void administradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Adm c;
            c = new Adm();
            c.Show();
           
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
