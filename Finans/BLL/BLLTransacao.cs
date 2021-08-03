using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLTransacao
    {
        private DALConexao conexao;

        public BLLTransacao(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModelTransacao modelo)
        {
            if (modelo.DataTrans == null)
                throw new Exception("A data é obrigatória!");

            if (modelo.DescTrans.Trim().Length == 0)
                throw new Exception("A descrição é obrigatória!");

            if (modelo.ValorTrans == 0.00)
                throw new Exception("O valor é obrigatório!");

            DALTransacao DALobj = new DALTransacao(conexao);
            DALobj.Incluir(modelo);
        }

        public void Alterar(ModelTransacao modelo)
        {
            if (modelo.IdTrans < 0)
                throw new Exception("O código da transação é obrigatório!");

            if (modelo.DataTrans == null)
                throw new Exception("A data é obrigatória!");

            if (modelo.DescTrans.Trim().Length == 0)
                throw new Exception("A descrição é obrigatória!");

            if (modelo.ValorTrans == 0.00)
                throw new Exception("O valor é obrigatório!");

            DALTransacao DALobj = new DALTransacao(conexao);
            DALobj.Alterar(modelo);
        }

        public void Excluir(int codigo)
        {
            DALTransacao DALobj = new DALTransacao(conexao);
            DALobj.Excluir(codigo);
        }

        public DataTable Localizar(String valor)
        {
            DALTransacao DALobj = new DALTransacao(conexao);
            return DALobj.Localizar(valor);
        }

        public ModelTransacao CarregaModeloTransacao(int codigo)
        {
            DALTransacao DALobj = new DALTransacao(conexao);
            return DALobj.CarregaModeloTransacao(codigo);
        }
    }
}