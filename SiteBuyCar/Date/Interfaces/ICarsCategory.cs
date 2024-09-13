using WebApplication1.Date.Models;

namespace WebApplication1.Date.Interfaces
{
    public interface ICarsCategory
    {

        IEnumerable<Category> AllCategory { get; }

    }
}
