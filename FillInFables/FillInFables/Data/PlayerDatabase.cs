using System;
using System.Linq;
using System.Threading.Tasks;
using FillInFables.Models;
using SQLite;

namespace FillInFables
{
    public class PlayerDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public PlayerDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Player).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Player)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<Player> GetPlayerAsync()
        {
            return Database.Table<Player>().FirstOrDefaultAsync();
        }

        public Task<Player> GetPlayerByIdAsync(int id)
        {
            return Database.Table<Player>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Player player)
        {
            if (player.ID != 0)
            {
                return Database.UpdateAsync(player);
            }
            else
            {
                return Database.InsertAsync(player);
            }
        }


    }
}
