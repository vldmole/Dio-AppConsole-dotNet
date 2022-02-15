namespace Dio.Series.entities
{
    public class AbstractEntity <TKey>
    {
        public TKey Id { get; protected set; }

        public AbstractEntity(TKey Id)
        {
            this.Id = Id;
        }
   }
}