using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using ExcelApp.Model;


namespace ExcelApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Produto> produtosBase = File
                                        .ReadAllLines(@"C:\\repositories\\DotNet\\ExcelConsoleApp//dtBase1.csv")
                                        .Skip(1)
                                        .Select( v => Produto.FromCsv(v))
                                        .ToList();

            Debug.WriteLine("Quantidade de linhas do arquivo base: ", produtosBase.Count.ToString());
                                        
            

            List<Produto> produtosMapa = File
                                        .ReadAllLines(@"C:\\repositories\\DotNet\\ExcelConsoleApp//dtMapa1.csv")
                                        .Skip(1)
                                        .Select( v => Produto.FromCsv(v))
                                        .ToList();




            // Debug.WriteLine("Quantidade de linhas do arquivo mapa: ", produtosMapa.Count.ToString());
            // var novosProdutos = Produto.ComparaArquivos(produtosBase,produtosMapa);
            // Produto.SaveCSV(novosProdutos);
            // Console.WriteLine("Arquivo gravado com sucesso!");

            //Passos:
            // Carrega as duas tabelas em List<Produto>
            // o arquivo dtBase é o arquivo a ser atualizado
            // o arquivo dtMapa é o arquivo completo enviado pelo cliente

            // depois de preenchidas as duas listas, crio um Dicionário da dtMapa
            // depois rodo o método que compara os dois arquivos, a List<Produto> e o Dictionary<int, Produto>
            // a variável novosProdutos deveria conter a lista dtBase atualizada. Mas pelo que vi está fazendo apenas
            // a primeira linha


            var produtosDictionary = Produto.CreateDictionary(produtosMapa);
            var novosProdutos = Produto.ComparaArquivos(produtosBase,produtosDictionary);
            Produto.SaveCSV(novosProdutos);            
        }
    }
}
