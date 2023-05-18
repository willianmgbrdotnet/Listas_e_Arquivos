using System;
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
            MostrarLista();
            break;
          case 2:
            AdicionarItensNaLista();
            break;
          case 3:
            ExcluirItemDaLista();
            break; 
          case 7:
            //APAGAR todos os Itens da Lista de Compras
            SobrescreverListaExistente();
            break;
          case 5:
            Console.Clear();
            break;
          
          default:
            throw new ArgumentOutOfRangeException();
        }
        opcaoDoUsuario = ObterOpcaoDoUsuario();        
      }
      Console.WriteLine("Estarei aqui caso você lembre de mais alguma coisa!");
    }

    private static void SobrescreverListaExistente()
    {
      Console.WriteLine("Este procedimento vai APAGAR a Lista de Compras inteira.");
      Console.WriteLine("Tem certeza que você quer APAGAR toda a Lista de Compras ??");
      Console.WriteLine();
      Console.WriteLine("Aperte 7 para APAGAR Todos os Itens da Lista de Compra.");
      Console.WriteLine("Se mudou de Idéia e quer voltar, aperte Outro Número. ");
      Console.WriteLine();
      int resposta = int.Parse(Console.ReadLine());
      if(resposta == 7)
      {
        Console.WriteLine("Escreva a nova Lista de Compra separando cada Item com um ESPAÇO");
        Console.WriteLine("Exemplo: carne suco.de.laranja pao.integral acucar");
        Console.WriteLine("Aperte ENTER para finalizar a Lista de Compra");
        Console.WriteLine();

        //O "true" foi removido depois do nome do Arquivo para sobrescrever o arquivo
        using (StreamWriter writer = new StreamWriter("lista_de_compras.txt"))
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
      else
      {
        ObterOpcaoDoUsuario();
      }
    }

    private static void ExcluirItemDaLista()
    {
      //variavel que armazenará o conteúdo lido do arquivo
      List<string> conteudoDoArquivo = new List<string>();
      using (StreamReader reader = new StreamReader("lista_de_compras.txt"))
      {
        string item;
        while((item = reader.ReadLine()) != null)
        {
          conteudoDoArquivo.Add(item);
        }
      }

      // Mostra uma Lista Numerada de itens para o usuário
    Console.WriteLine("Itens na Lista de Compras:");
    for (int i = 0; i < conteudoDoArquivo.Count; i++)
      {
        //Como o Indice começa com o numero 0, acrescenta 1 para a lista começar a partir do numero 1
        Console.WriteLine($"{i + 1}. {conteudoDoArquivo[i]}");
      }

      Console.WriteLine();    
      // O usuário deverá digitar o numero correspondente ao Item
      Console.WriteLine("Qual item você deseja retirar da Lista de Compra? ");
      Console.WriteLine("Digite o número que está antes do Item.");
      int indiceDoItem = int.Parse(Console.ReadLine()) - 1;
    
      // Verificar se o número do item contém na lista numerada
      if (indiceDoItem >= 0 && indiceDoItem < conteudoDoArquivo.Count)
      {
        // Remover o item da lista
        conteudoDoArquivo.RemoveAt(indiceDoItem);
        Console.WriteLine("Item removido com sucesso!");
      }
      else
      {
        Console.WriteLine("Número de item inválido.");
      }
      Console.WriteLine();


      //Reescreverá o arquivo de acordo com os parâmetros abaixo
      using (StreamWriter writer = new StreamWriter("lista_de_compras.txt"))
      {
        foreach(string item in conteudoDoArquivo)
        {
          Console.WriteLine($"{item}");
          //escreverá um item por linha no arquivo
          writer.WriteLine($"{item}");
        }
      }
    }


    private static void MostrarLista()
    {
      //variavel que armazenará o conteúdo lido do arquivo
      List<string> conteudoDoArquivo = new List<string>();
      using (StreamReader reader = new StreamReader("lista_de_compras.txt"))
      {
        string item;
        while((item = reader.ReadLine()) != null)
        {
          conteudoDoArquivo.Add(item);
        }
      }
      //Reescreverá o arquivo de acordo com os parâmetros abaixo
      using (StreamWriter writer = new StreamWriter("lista_de_compras.txt"))
      {
        List<string> listaCompras = new List<string>();
        //esta lista armazenará o intervalo de itens lidos pelo reader
        listaCompras.AddRange(conteudoDoArquivo);
        //Removerá itens duplicados lidos no arquivo        
        listaCompras = listaCompras.Distinct().ToList();

        listaCompras.Sort();

        foreach(string item in listaCompras)
        {
          Console.WriteLine($"{item}");
          //escreverá um item por linha no arquivo
          writer.WriteLine($"{item}");
        }
      }
    }

    private static int ObterOpcaoDoUsuario()
    {
        Console.WriteLine();
        Console.WriteLine("Vamos às Compras!?");
        Console.WriteLine();
        Console.WriteLine("Informe a Opção desejada.");
        Console.WriteLine();
        Console.WriteLine("Digite 1 para Mostrar a Lista de Compras");
        Console.WriteLine("Digite 2 para Adicionar um Item na Lista");
        Console.WriteLine("Digite 3 para Remover um Item da Lista");
        Console.WriteLine("Digite 5 para Limpar a tela");
        Console.WriteLine("Digite 7 para APAGAR a Lista que Existe e CRIAR uma Nova Lista");
        Console.WriteLine("Digite 9 para Sair");
        Console.WriteLine();

        int opcaoDoUsuario = int.Parse(Console.ReadLine());
        Console.WriteLine();
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