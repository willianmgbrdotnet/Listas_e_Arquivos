﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class ComprasNoSupermercado
{
  public static void Main(string[] args)
    {
      int opcaoDoUsuario = ObterOpcaoDoUsuario();

      while(opcaoDoUsuario != 9)
      {
        switch(opcaoDoUsuario)
        {
          case 1:
            //MostrarLista();
            break;
          case 2:
            AdicionarItensNaLista();
            break;
          case 3:
            //ExcluirItemDaLista();
            break; 
          case 7:
            //SobrescreverListaExistente();
            break;
          case 5:
            Console.Clear();
            break;
          
          default:
            throw new ArgumentOutOfRangeException();
        }

        opcaoDoUsuario = ObterOpcaoDoUsuario();        
      }

      System.Console.WriteLine("Estarei aqui caso você lembre de mais alguma coisa");
    }

    private static int ObterOpcaoDoUsuario()
    {
        Console.WriteLine();
        Console.WriteLine("Vamos às Compras!?");
        Console.WriteLine("Informe a Opção desejada.");
        Console.WriteLine();
        Console.WriteLine("Digite 1 para mostrar a Lista de Compras");
        Console.WriteLine("Digite 2 para adicionar um Item na Lista");
        Console.WriteLine("Digite 3 para remover um Item da Lista");
        Console.WriteLine("Digite 5 para Limpar a tela");
        Console.WriteLine("Digite 7 para APAGAR a Lista que Existe e CRIAR uma Nova Lista");
        Console.WriteLine("Digite 9 para Sair");
        Console.WriteLine();

        int opcaoDoUsuario = int.Parse(Console.ReadLine());
        System.Console.WriteLine();
        return opcaoDoUsuario;
    }

    private static void AdicionarItensNaLista()
    {
        //Quantidade de listas a serem criadas
        int numeroDeTestes = 1;

        Console.WriteLine("Escreva a Lista de Compra separando cada Item com um ESPAÇO");
        Console.WriteLine("Exemplo: carne suco.de.laranja pao.integral acucar");
        Console.WriteLine("Aperte ENTER para finalizar a Lista de Compra");
        Console.WriteLine();

        //o Método StreamWriter salva a lista no arquivo com nome entre "".
        //o "using" no início serve para fechar o StreamWriter automaticamente depois de sua execução.
        //o "true" depois do nome do Arquivo impede que o arquivo seja sobrescrito,
        //adicionando novas listas após a última linha dentro do arquivo.
        using (StreamWriter writer = new StreamWriter("lista_de_compras.txt", true))
        {
            for (int i = 0; i < numeroDeTestes; i++)
            {
                List<string> listDeCompras = new List<String>(Console.ReadLine().Split(' ')); //o espaço será usado como separador dos itens da lista

                //Elimina a duplicidade de itens da lista
                List<string> listaSemDuplicados = listDeCompras.Distinct().ToList();

                //Agrupa os itens em ordem alfabetica (por padrão)
                listaSemDuplicados.Sort();

                Console.WriteLine();
                //Mostrar na tela a lista com seus itens ordenados e sem repetir algum item
                foreach (string item in listaSemDuplicados)
                {
                    Console.WriteLine($"{item} ");
                    writer.WriteLine($"{item} ");
                }

            }

        }
    }
}