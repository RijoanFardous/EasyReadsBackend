using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.Interfaces
{
    public interface IRepo<CLASS, ID>
    {
        List<CLASS> GetAll();
        CLASS? Get(ID id);
        void Create(CLASS obj);
        void Update(CLASS obj);
        void Delete(ID id);
    }
}
