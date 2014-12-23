using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ridwan.Web.NasiLiwet.Web.Models;

namespace Ridwan.Web.NasiLiwet.Web.repository
{
    public interface IProductRepository
    {
        List<Product> GetAllData();
    }
}
