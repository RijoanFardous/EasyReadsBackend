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
    public class ReportRepo : IReportRepo
    {
        private readonly EasyReadsContext _db;
        public ReportRepo(EasyReadsContext db)
        {
            _db = db;
        }

        public void Approve(int repId)
        {
            var app = _db.Reports.Find(repId);
            if (app != null)
            {
                app.Status = "Approved";
            }
        }

        public void Create(Report obj)
        {
            _db.Reports.Add(obj);
            _db.SaveChanges();
        }

        public Report? Get(int repId)
        {
            return _db.Reports.Find(repId);
        }

        public List<Report> GetAll()
        {
            return _db.Reports.ToList();
        }

        public List<Report> GetAllApproved()
        {
            var reports = (from a in _db.Reports where a.Status.Equals("Approved") select a).ToList();
            return reports;
        }

        public List<Report> GetAllPendings()
        {
            var reports = (from a in _db.Reports where a.Status.Equals("Pending") select a).ToList();
            return reports;
        }

        public List<Report> GetAllRejected()
        {
            var reports = (from a in _db.Reports where a.Status.Equals("Rejected") select a).ToList();
            return reports;
        }

        public List<Report> GetReportByUser(string username)
        {
            var reports = (from a in _db.Reports where a.Username.Equals(username) select a).ToList();
            return reports;
        }

        public void Reject(int repId)
        {
            var app = _db.Reports.Find(repId);
            if (app != null)
            {
                app.Status = "Rejected";
            }
        }
    }
}
