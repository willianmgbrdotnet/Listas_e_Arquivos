using System;
using System.Collections.Generic;
using System.Linq;

class ComprasNoSupermercado
{
  public static void Main(string[] args)
  {
    Console.WriteLine("Quantas Listas de Compras você deseja criar agora?");
    
    //Quantidade de listas a serem criadas
    int numeroDeTestes = int.Parse(Console.ReadLine());

    Console.WriteLine("Escreva a Lista de Compra separando cada Item com um ESPAÇO");
    Console.WriteLine("Exemplo: carne suco.de.laranja pao.integral acucar");
    Console.WriteLine("Aperte ENTER no final de cada Lista de Compra");
    Console.WriteLine(); 

    for (int i = 0; i < numeroDeTestes; i++) {
      List<string> listDeCompras = new List<String>(Console.ReadLine().Split(' ')); //o espaço será usado como separador dos itens da lista

      //Elimina a duplicidade de itens da lista
      List<string> listaSemDuplicados = listDeCompras.Distinct().ToList();

      //Agrupa os itens em ordem alfabetica (por padrão)
      listaSemDuplicados.Sort();

      //Mostrar na tela a lista com seus itens ordenados e sem repetir algum item
      foreach(string item in listaSemDuplicados)
      {
        Console.Write($"{item} ");
      }

      Console.WriteLine();
    
    }
  }
}