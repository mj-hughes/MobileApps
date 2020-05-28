using System.Threading.Tasks;
using FillInFables.Models;

namespace FillInFables
{
    public interface IRestService
    {
        Task<MadLibz> RefreshDataAsync();
    }
}
