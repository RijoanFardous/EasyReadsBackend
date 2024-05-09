using EasyReadsDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsBLL.Services
{
    public class ArticleService
    {
        private readonly DataAccessFactory _dataAccessFactory;
        public ArticleService(DataAccessFactory dataAccessFactory)
        {
            _dataAccessFactory = dataAccessFactory;
        }


    }
}
