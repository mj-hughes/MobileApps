using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace Code11JokesDatabase
{
    public class JokeDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public JokeDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m=> m.MappedType.Name==typeof(Joke).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Joke)).ConfigureAwait(false);
                    initialized = true;

                }
            }
        }

        public Task<List<Joke>> GetJokesAsync()
        {
            return Database.Table<Joke>().ToListAsync();
        }

        public Task<List<Joke>> GetJokesNotDoneAsync()
        {
            return Database.QueryAsync<Joke>("SELECT * FROM [Joke] WHERE [Punchline]=''");
        }

        public Task<Joke> GetJokeAsync(int id)
        {
            return Database.Table<Joke>().Where(i=>i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Joke joke)
        {
            if (joke.ID != 0 )
            {
                return Database.UpdateAsync(joke);
            }
            else
            {
                return Database.InsertAsync(joke);
            }
        }

        // Delete joke not part of this assignment
    }
}
