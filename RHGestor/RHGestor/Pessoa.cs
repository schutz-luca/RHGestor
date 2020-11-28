using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHGestor
{
    [Serializable]
    public class Pessoa
    {
        public string cpf { get; private set; }
        public string nome { get; private set; }
        public string rg { get; private set; }
        public DateTime dataNasc { get; private set; }
        public string pai { get; private set; }
        public string mae { get; private set; }
        public string endNatal { get; private set; }
        public string endRes { get; private set; }
        public string escolaridade { get; private set; }
        public string telefone { get; private set; }
        public string email { get; private set; }
        public string departamento { get; private set; }

        public int pontuacao { get; private set; }

        public string descr { get; private set; }

        public void setCPF(string d)
        {
            bool repetido = false;
            for(int i = 0; i < Lista.itens.Count; i++)
            {
                if (d == Lista.itens[i].cpf)
                    repetido = true;
            }
            if(!repetido)
                this.cpf = d;
            else
                throw new Exception("CPF já existente");
        }

        public void setNome(string d)
        {
            this.nome = d;
        }

        public void setRG(string d)
        {
            this.rg = d;
        }
        public void setDataNasc(DateTime d)
        {
            this.dataNasc = d;
        }
        public void setPai(string d)
        {
            this.pai = d;
        }
        public void setMae(string d)
        {
            this.mae = d;
        }
        public void setEndNatal(string d)
        {
            this.endNatal = d;
        }

        public void setEndRes(string d)
        {
            this.endRes = d;
        }
        public void setEscolaridade(string d)
        {
            this.escolaridade = d;
        }

        public void setTelefone(string d)
        {
            this.telefone = d;
        }
        public void setEmail(string d)
        {
            this.email = d;
        }
        public void setDep(string d)
        {
            this.departamento = d;
        }
        public void setPont(int d)
        {
            this.pontuacao += d;
        }

        public void setDescr(string d)
        {
            this.descr = d;
        }
    }
}
