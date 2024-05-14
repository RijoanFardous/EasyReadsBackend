using EasyReadsDAL.EF;
using EasyReadsDAL.EF.Entities;
using EasyReadsDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.Repos
{
    public class ApplicationRepo : IApplicationRepo
    {
        private readonly EasyReadsContext _db;
        public ApplicationRepo(EasyReadsContext db)
        {
            _db = db;
        }

        public void Approve(int appId)
        {
            var app = _db.Applications.Find(appId);
            if (app != null)
            {
                app.Status = "Approved";
            }
        }

        public void Create(Application obj)
        {
            _db.Applications.Add(obj);
            _db.SaveChanges();
        }

        public Application? Get(int appId)
        {
            return _db.Applications.Find(appId);
        }

        public List<Application> GetAll()
        {
            return _db.Applications.ToList();
        }

        public List<Application> GetAllApproved()
        {
            var applications = (from a in _db.Applications where a.Status.Equals("Approved") select a).ToList();
            return applications;
        }

        public List<Application> GetAllPendings()
        {
            var applications = (from a in _db.Applications where a.Status.Equals("Pending") select a).ToList();
            return applications;
        }

        public List<Application> GetAllRejected()
        {
            var applications = (from a in _db.Applications where a.Status.Equals("Rejected") select a).ToList();
            return applications;
        }

        public List<Application> GetApplicationByUser(string username)
        {
            var applications = (from a in _db.Applications where a.Username.Equals(username) select a).ToList();
            return applications;
        }

        public void Reject(int appId)
        {
            var app = _db.Applications.Find(appId);
            if (app != null)
            {
                app.Status = "Rejected";
            }
        }
    }
}
