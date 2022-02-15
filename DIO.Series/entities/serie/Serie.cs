using System.Text;

namespace Dio.Series.entities.serie
{
   public class Serie : AbstractEntity<int>
   {
      public Gender gender { get; private set; }
      public string title { get; private set; }
      public string description { get; private set;}
      public int year { get; private set; }
      
      //----------------------------------------------------------------------------------------
      public Serie(int Id, Gender gender, int year, string title, string description) : base(Id)
      {
         this.gender = gender;
         this.year = year;
         this.title = title;
         this.description = description;
      }
      //----------------------------------------------------------------------------------------
      public override string ToString()
      {
         StringBuilder sb = new StringBuilder();
         sb.AppendFormat("{0} Id:{1} Gender: {2} Year: {3} Title: {4} Description: {5} {6}", 
             "{", this.Id, this.gender, this.year, this.title, this.description, "}" );

         return sb.ToString();
      }
      //----------------------------------------------------------------------------------------
   }
}