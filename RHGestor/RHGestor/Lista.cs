using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RHGestor
{
    public static class Lista
    {
        public static List<Pessoa> itens = null;//declarando a lista
        private static string nomeArq;
        static Lista()
        {
            itens = new List<Pessoa>();//intanciar a lista
            nomeArq = "dados.bin";
        }
        public static void ler()
        {
            FileStream fs;//objeto arquivo binario
            BinaryFormatter bf;

            try
            {
                fs = new FileStream(nomeArq, FileMode.Open);//abre o arquivo
                bf = new BinaryFormatter();//cria o objeto de serialização
                itens = (List<Pessoa>)bf.Deserialize(fs);//le do arquivo e coloca dados na lista
                fs.Close();
            }
            catch (Exception)
            {

            }
        }
        public static void gravar()
        {
            FileStream fs;
            BinaryFormatter bf;
            try
            {
                fs = new FileStream(nomeArq, FileMode.Create);
                bf = new BinaryFormatter();
                bf.Serialize(fs, itens);
                fs.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gravar: " + ex.Message);
            }
        }
        public static void remove(string cpfL)//remove
        {
            int i;
            for (i = 0; i < itens.Count; i++)
            {
                if (itens[i].cpf == cpfL)
                    break;
            }
            if (i < itens.Count)
            {
                itens.RemoveAt(i);
                throw new Exception("CPF deletado.");
            }
            else
                throw new Exception("CPF não encontrado.");


        }
        
    }
}

