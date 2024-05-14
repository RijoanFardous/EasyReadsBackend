using EasyReadsDAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.Interfaces
{
    public interface IReportRepo
    {
        public void Create(Report obj);
        public Report? Get(int repId);
        public List<Report> GetReportByUser(string username);
        public List<Report> GetAll();
        public List<Report> GetAllApproved();
        public List<Report> GetAllRejected();
        public List<Report> GetAllPendings();
        public void Approve(int repId);
        public void Reject(int repId);
    }
}
