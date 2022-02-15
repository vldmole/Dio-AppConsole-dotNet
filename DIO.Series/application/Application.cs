using Dio.Series.entities;
using Dio.Series.entities.serie;

namespace Dio.Series.application
{
   public class Application
   {
      private const int ESC = 27;
      IRepository<Serie, int> repo = null;

      //-------------------------------------------------------------
      public Application(IRepository<Serie, int> repo)
      {
         this.repo = repo;
      }
      //-------------------------------------------------------------
      private void menu()
      {
         Console.Clear();

         Console.WriteLine();
         Console.WriteLine("DIO Séries a seu dispor!!!");
         Console.WriteLine("Informe a opção desejada:");

         Console.WriteLine("1- Listar séries");
         Console.WriteLine("2- Inserir nova série");
         Console.WriteLine("3- Atualizar série");
         Console.WriteLine("4- Excluir série");
         Console.WriteLine("5- Visualizar série");
         Console.WriteLine("Esc - Sair");
         Console.WriteLine();
      }
      //-------------------------------------------------------------
      public void run()
      {
         do
         {
            menu();

            int choice = int.Parse(Console.ReadLine());

            if (choice == ESC)
               return;

            manager(choice);

         } while (true);
      }
      //-------------------------------------------------------------
      private void manager(int op)
      {
         switch (op)
         {
            case 1:
               ListSeries();
               break;
            case 2:
               createSerie();
               break;
            case 3:
               UpdateSerie();
               break;
            case 4:
               DeleteSerie();
               break;
            case 5:
               ViewSerie();
               break;
         }
      }
      //-------------------------------------------------------------
      private void ListSeries()
      {
        Console.WriteLine("Listar séries");

        var list = repo.ReadAll();
        Console.WriteLine("{0} Séries cadastradas.", list.Count());
        
        foreach (var serie in list)
            Console.WriteLine(serie.ToString());

         Console.ReadLine();
      }
      //-------------------------------------------------------------
      private Gender readGender()
      {
         Array vGenders = Enum.GetValues(typeof(Gender));
         int gender = -1;
         do
         {
            foreach (int i in vGenders)
               Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));

            Console.Write("Digite o gênero entre as opções acima: ");
            gender = int.Parse(Console.ReadLine());

         } while (!Enum.IsDefined(typeof(Gender), gender));

         return ((Gender) gender);
      }
      //-------------------------------------------------------------
      private void createSerie()
      {
         Console.WriteLine("Inserir nova série");

         Gender gender = readGender();
         
         Console.Write("Digite o Título da Série: ");
         string title = Console.ReadLine();
         //-------------------------------------------------------------
         Console.Write("Digite o Ano de Início da Série: ");
         int year = int.Parse(Console.ReadLine());

         Console.Write("Digite a Descrição da Série: ");
         string description = Console.ReadLine();

         Serie serie = new Serie(
            Id: (int)this.repo.NextKey(),
            year: year,
            gender: gender,
            title: title,
            description: description
         );

         this.repo.Create(serie);
      }
      //-------------------------------------------------------------
      private void UpdateSerie()
      {
         Console.Write("Digite o id da série: ");
         int id = int.Parse(Console.ReadLine());
         Serie serie = this.repo.Read(id);
         
         Console.WriteLine("Genero: {0}", Enum.GetName(typeof(Gender), serie.gender));
         Gender newGender = readGender();

         Console.WriteLine("Título: {0}", serie.title);
         Console.Write("Digite o Título da Série: ");
         string newTitle = Console.ReadLine();

         Console.WriteLine("Ano: {0}", serie.year);
         Console.Write("Digite o Ano de Início da Série: ");
         int newYear = int.Parse(Console.ReadLine());

         Console.WriteLine("Descrição: {0}", serie.description);
         Console.Write("Digite a Descrição da Série: ");
         string newDescription = Console.ReadLine();

         Serie upSerie = new Serie(
             Id: id,
             gender: (Gender)newGender,
             title: newTitle,
             year: newYear,
             description: newDescription
        );

         this.repo.Update(upSerie);
      }
      //-------------------------------------------------------------
      private void DeleteSerie()
      {
         Console.Write("Digite o id da série: ");
         int id = int.Parse(Console.ReadLine());

         repo.Delete(id);
      }
      //-------------------------------------------------------------
      private void ViewSerie()
      {
         Console.Write("Digite o id da série: ");
         int id = int.Parse(Console.ReadLine());

         Serie serie = this.repo.Read(id);

         Console.WriteLine(serie.ToString());
         Console.ReadLine();
      }
      //-------------------------------------------------------------
   }
}