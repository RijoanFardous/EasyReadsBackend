using EasyReadsDAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.Interfaces
{
    public interface IApplicationRepo
    {
        public void Create(Application obj);
        public Application? Get(int appId);
        public List<Application> GetApplicationByUser(string username);
        public List<Application> GetAll();
        public List<Application> GetAllApproved();
        public List<Application> GetAllRejected();
        public List<Application> GetAllPendings();
        public void Approve(int appId);
        public void Reject(int appId);
    }
}
