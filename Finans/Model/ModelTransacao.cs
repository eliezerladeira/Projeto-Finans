using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelTransacao
    {
        public ModelTransacao()
        {
            this.IdTrans = 0;
            this.DataTrans = null;
            this.DescTrans = "";
            this.ValorTrans = 0;
            this.NotaTrans = "";
        }

        public ModelTransacao(int id, DateTime? data, String descricao, double valor, String nota)
        {
            this.IdTrans = id;
            this.DataTrans = data;
            this.DescTrans = descricao;
            this.ValorTrans = valor;
            this.NotaTrans = nota;
        }

        private int id_trans;
        private DateTime? data_trans;
        private String desc_trans;
        private double valor_trans;
        private String nota_trans;

        public int IdTrans
        {
            get { return this.id_trans; }
            set { this.id_trans = value; }
        }

        public DateTime? DataTrans
        {
            get { return this.data_trans; }
            set { this.data_trans = value; }
        }

        public String DescTrans
        {
            get { return this.desc_trans; }
            set { this.desc_trans = value; }
        }

        public double ValorTrans
        {
            get { return this.valor_trans; }
            set { this.valor_trans = value; }
        }

        public String NotaTrans
        {
            get { return this.nota_trans; }
            set { this.nota_trans = value; }
        }
    }
}