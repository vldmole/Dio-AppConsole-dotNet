using Dio.Series.entities;

namespace Dio.Series.inMemoryRepository
{
   public abstract class InMemoryRepositoryFactory
   {
      static Dictionary<Type, Object> repoMap = new Dictionary<Type, object>();
      
      //--------------------------------------------------------------------
      public static IRepository<T, TKey> GetRepository<T, TKey>()
        where T : AbstractEntity<TKey>
        where TKey : notnull
      {
         Type key = typeof(T);
         if( repoMap.ContainsKey(key) )
                return ( (IRepository<T, TKey>)repoMap[key] );

         IRepository<T, TKey> repo = new Repository<T, TKey>();
         repoMap.Add(key, repo);

         return repo;
      }
    
    //-------------------------------------------------------------
    class Repository<T, TKey> : IRepository<T, TKey>
        where T : AbstractEntity <TKey> 
        where TKey: notnull
    {
        private Dictionary<TKey, T> repo = new Dictionary<TKey, T>();
        private ulong key = 0;
        
        //-------------------------------------------------------------
        public void Create(T entity)
        {
            repo.Add(entity.Id, entity);
        }
        //-------------------------------------------------------------
        public T Read(TKey id)
        {
            return repo[id];
        }
        //-------------------------------------------------------------
        public IEnumerable<T> ReadAll()
        {
            return repo.Values.ToList();
        }
        //-------------------------------------------------------------
        public IEnumerable<T> Read(Func<T, bool> predicate)
        {
            return (
                repo
                .Where(kv => predicate(kv.Value))
                .Select(kv => kv.Value)
            );
        }
        //-------------------------------------------------------------
        public void Update(T entity)
        {
            this.Delete(entity.Id);

            repo.Add(entity.Id, entity);
        }
        //-------------------------------------------------------------
        public void Delete(TKey id)
        {
            if (!repo.ContainsKey(id))
                throw new Exception("Entity not found: " + id);

            repo.Remove(id);
        }
        //-------------------------------------------------------------
        public ulong NextKey()
        {
            return ++key;
        }
    }
   }
}