using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ExcelApp.Model
{
    public class Produto
    {
        private const string STRING_MASK = "{0};{1};{2};{3};{4};{5}";

        public string CodigoOferta { get; set; }
        public string ConteudosOnLineFidel{ get; set; }
        public string AplicativosTitularFidel { get; set; }
        public string AplicativosDependenteFidel { get; set; }
        public string IsencoesTrafegoTitularFidel { get; set; }
        public string IsencoesTrafegoDependenteFidel { get; set; }



        public static Produto FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(';');
            Produto produtosBase = new Produto();
            produtosBase.CodigoOferta = Convert.ToString(values[0]);
            produtosBase.ConteudosOnLineFidel = Convert.ToString(values[1]);
            produtosBase.AplicativosTitularFidel = Convert.ToString(values[2]);
            produtosBase.AplicativosDependenteFidel = Convert.ToString(values[3]);
            produtosBase.IsencoesTrafegoTitularFidel = Convert.ToString(values[4]);
            produtosBase.IsencoesTrafegoDependenteFidel = Convert.ToString(values[5]);

            return produtosBase;
        }

        public static List<Produto> ComparaArquivos(List<Produto> produtosBase, List<Produto> produtosMapa)
        {

            Produto novoProduto;
            List<Produto> produtosNovos = new List<Produto>();

            for(int i = 0; i < produtosBase.Count; i++)
            {
                Debug.WriteLine("Codigo oferta base {0}", produtosBase[i].CodigoOferta);
                Debug.WriteLine("Codigo oferta mapa {0}", produtosMapa[i].CodigoOferta);

                novoProduto = new Produto();

                if(produtosBase[i].CodigoOferta.Equals(produtosMapa[i].CodigoOferta))
                {
                    novoProduto.CodigoOferta = produtosMapa[i].CodigoOferta;
                    novoProduto.ConteudosOnLineFidel = produtosMapa[i].ConteudosOnLineFidel;
                    novoProduto.AplicativosTitularFidel = produtosMapa[i].AplicativosTitularFidel;
                    novoProduto.AplicativosDependenteFidel = produtosMapa[i].AplicativosDependenteFidel;
                    novoProduto.IsencoesTrafegoTitularFidel = produtosMapa[i].IsencoesTrafegoTitularFidel;
                    novoProduto.IsencoesTrafegoDependenteFidel = produtosMapa[i].IsencoesTrafegoDependenteFidel;
                    produtosNovos.Add(novoProduto);
                }
                else
                {
                    novoProduto.CodigoOferta = produtosBase[i].CodigoOferta;
                    novoProduto.ConteudosOnLineFidel = produtosBase[i].ConteudosOnLineFidel;
                    novoProduto.AplicativosTitularFidel = produtosBase[i].AplicativosTitularFidel;
                    novoProduto.AplicativosDependenteFidel = produtosBase[i].AplicativosDependenteFidel;
                    novoProduto.IsencoesTrafegoTitularFidel = produtosBase[i].IsencoesTrafegoTitularFidel;
                    novoProduto.IsencoesTrafegoDependenteFidel = produtosBase[i].IsencoesTrafegoDependenteFidel;
                    produtosNovos.Add(novoProduto);

                }

            }
            return produtosNovos;
        }

        public static void SaveCSV (List<Produto> novosProdutos)
        {
            using (var newFile = File.CreateText("//home//gerson//Documents//Repositories//NetCore//ExcelApp//testeNewProdutos.csv"))
            {
                foreach (var produto in novosProdutos)
                {
                    newFile.WriteLine(produto);
                }
            }
        }

        public override string ToString()
        {
           return string.Format(STRING_MASK, this.CodigoOferta, this.ConteudosOnLineFidel, this.AplicativosTitularFidel, this.AplicativosDependenteFidel, this.IsencoesTrafegoTitularFidel, this.IsencoesTrafegoDependenteFidel); 
        }


    }

    

}