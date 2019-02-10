using System;
using System.Collections.Generic;
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
                                        .ReadAllLines("//home//gerson//Documents//Repositories//NetCore//ExcelApp//teste.csv")
                                        .Skip(1)
                                        .Select( v => Produto.FromCsv(v))
                                        .ToList();
            

            List<Produto> produtosMapa = File
                                        .ReadAllLines("//home//gerson//Documents//Repositories//NetCore//ExcelApp//testeMapa.csv")
                                        .Skip(1)
                                        .Select( v => Produto.FromCsv(v))
                                        .ToList();

            var novosProdutos = Produto.ComparaArquivos(produtosBase,produtosMapa);

            Produto.SaveCSV(novosProdutos);

            Console.WriteLine("Arquivo gravado com sucesso!");
        }
    }
}
