using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;

namespace ExcelApp.Model
{
    public class Produto
    {
        private const string STRING_MASK = "{0};{1};{2};{3};{4};{5}";

        public string CodigoOfertaVozComSVAComLDComVCFidel { get; set; }
        public string ConteudosOnLineFidel{ get; set; }
        public string AplicativosTitularFidel { get; set; }
        public string AplicativosDependenteFidel { get; set; }
        public string IsencoesTrafegoTitularFidel { get; set; }
        public string IsencoesTrafegoDependenteFidel { get; set; }



        public static Produto FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(';');
            Produto produtosBase = new Produto();
            produtosBase.CodigoOfertaVozComSVAComLDComVCFidel = Convert.ToString(values[0]);
            produtosBase.ConteudosOnLineFidel = Convert.ToString(values[1]);
            produtosBase.AplicativosTitularFidel = Convert.ToString(values[2]);
            produtosBase.AplicativosDependenteFidel = Convert.ToString(values[3]);
            produtosBase.IsencoesTrafegoTitularFidel = Convert.ToString(values[4]);
            produtosBase.IsencoesTrafegoDependenteFidel = Convert.ToString(values[5]);

            return produtosBase;
        }

        public static List<Produto> ComparaArquivos(List<Produto> produtosBase, Dictionary<int, Produto> dictionaryProdutos)
        {

            Produto novoProduto;
            List<Produto> produtosNovos = new List<Produto>();
            dynamic d1 = new ExpandoObject();

            var dict = new Dictionary<string, dynamic>();

            

            for(int i = 0; i < produtosBase.Count; i++)
            {
                novoProduto = new Produto();

                var _oferta = produtosBase[i].CodigoOfertaVozComSVAComLDComVCFidel;

                Debug.WriteLine("produtos base oferta:  " + _oferta);

                novoProduto = Produto.SearchDictionary(produtosBase[i], dictionaryProdutos);

                if(novoProduto != null)
                {
                    produtosNovos.Add(novoProduto);
                }
                else
                {
                    produtosNovos.Add(produtosBase[i]);
                }

            }

           // var result = produtosBase.Where(r => produtosMapa.Any(r2 => r2.ConteudosOnLineFidel == r.ConteudosOnLineFidel)).ToList();

            return produtosNovos;
        }

        public static void SaveCSV (List<Produto> novosProdutos)
        {
            using (var newFile = File.CreateText(@"C:\\repositories\\DotNet\\ExcelConsoleApp\\testeNewProdutos1.csv"))
            {
                foreach (var produto in novosProdutos)
                {
                    newFile.WriteLine(produto);
                }
            }
        }

        public override string ToString()
        {
           return string.Format(STRING_MASK, this.CodigoOfertaVozComSVAComLDComVCFidel, this.ConteudosOnLineFidel, this.AplicativosTitularFidel, this.AplicativosDependenteFidel, this.IsencoesTrafegoTitularFidel, this.IsencoesTrafegoDependenteFidel); 
        }

        public static Dictionary<int, Produto> CreateDictionary(List<Produto> listMapa)
        {
            Dictionary<int, Produto> dProduto = new Dictionary<int, Produto>();

            for (int i = 0; i < listMapa.Count; i++)
            {
                dProduto.Add(i, listMapa[i]);
            }

            return dProduto;
        }

        public static void ShowDictionary (Dictionary<int, Produto> dictionaryProdutos)
        {
            foreach (var keyValuePair in dictionaryProdutos.Values)
            {
                Debug.WriteLine(keyValuePair.CodigoOfertaVozComSVAComLDComVCFidel);
            }
        }

        public static Produto SearchDictionary(Produto produto, Dictionary<int, Produto> dictionaryProdutos)
        {
            var oldProduto = produto;
            Produto newProduto;

            foreach (var keyValuePair in dictionaryProdutos)
            {
                newProduto = new Produto();

                if (keyValuePair.Value.CodigoOfertaVozComSVAComLDComVCFidel.Contains(oldProduto.CodigoOfertaVozComSVAComLDComVCFidel))      
                {
                    newProduto = keyValuePair.Value;
                    return newProduto;
                }
                
            }
            return null;
        }
    }
}