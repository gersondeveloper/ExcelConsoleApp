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
                                        .ReadAllLines(@"C:\\repositories\\DotNet\\ExcelConsoleApp//dtBase.csv")
                                        .Skip(1)
                                        .Select( v => Produto.FromCsv(v))
                                        .ToList();

            Debug.WriteLine("Quantidade de linhas do arquivo base: ", produtosBase.Count.ToString());
                                        
            

            List<Produto> produtosMapa = File
                                        .ReadAllLines(@"C:\\repositories\\DotNet\\ExcelConsoleApp//dtMapa.csv")
                                        .Skip(1)
                                        .Select( v => Produto.FromCsv(v))
                                        .ToList();




            // Debug.WriteLine("Quantidade de linhas do arquivo mapa: ", produtosMapa.Count.ToString());

            // var novosProdutos = Produto.ComparaArquivos(produtosBase,produtosMapa);

            // Produto.SaveCSV(novosProdutos);

            // Console.WriteLine("Arquivo gravado com sucesso!");

            var produtosDictionary = Produto.CreateDictionary(produtosMapa);
            var novosProdutos = Produto.ComparaArquivos(produtosBase,produtosDictionary);            
        }
    }
}
