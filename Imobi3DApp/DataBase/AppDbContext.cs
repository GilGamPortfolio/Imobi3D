using SQLite;
using Imobi3DApp.Models;

namespace Imobi3DApp.Database
{
    public class AppDbContext
    {
        readonly SQLiteAsyncConnection _database;

        public AppDbContext(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Imovel>().Wait(); 
            // Futuramente, adicionaremos outras tabelas aqui, como a de Comodos
        }

        public AsyncTableQuery<Imovel> GetImoveis()
        {
            return _database.Table<Imovel>();
        }

        public Task<Imovel> GetImovelAsync(int id)
        {
            return _database.Table<Imovel>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveImovelAsync(Imovel imovel)
        {
            if (imovel.Id != 0)
            {
                return _database.UpdateAsync(imovel);
            }
            else
            {
                return _database.InsertAsync(imovel);
            }
        }

        public Task<int> DeleteImovelAsync(Imovel imovel)
        {
            return _database.DeleteAsync(imovel);
        }
    }
}