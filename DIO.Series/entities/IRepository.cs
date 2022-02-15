namespace Dio.Series.entities
{
    public interface IRepository<T, TKey>
     where T : AbstractEntity<TKey>
     where TKey: notnull
    {
      public void Create(T entity);

      public T Read(TKey key);
      
      public IEnumerable<T> ReadAll();
      
      public IEnumerable<T> Read(Func<T, bool> predicate);
      
      public void Update(T entity);
      
      public void Delete(TKey key);
      
      public ulong NextKey();
   }
}