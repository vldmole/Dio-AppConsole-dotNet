
using Dio.Series.entities;
using Dio.Series.entities.serie;
using Dio.Series.inMemoryRepository;
using Dio.Series.application;

namespace Dio.Series
{
   public class Principal
   {
      public static void Main(string[] args)
      {
         IRepository<Serie, int> repo = InMemoryRepositoryFactory.GetRepository<Serie, int>();
         Application app = new Application(repo);
         app.run();

         /*
         Serie serie = new Serie(1, Gender.ACTION, 1971, "TriploX", "macacos me mordam");
         repo.Create(serie);
         
         serie = new Serie(2, Gender.ADVENTURE, 1998, "ArquivoX", "Partiu ET");
         repo.Create(serie);

         foreach(Serie ser in repo.ReadAll())
         {
            Console.WriteLine(ser.ToString());
         }
         */
      }
   }
}