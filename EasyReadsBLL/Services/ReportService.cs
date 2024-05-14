using EasyReadsBLL.DTOs;
using EasyReadsDAL;
using EasyReadsDAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsBLL.Services
{
    public class ReportService
    {
        private readonly DataAccessFactory _dataAccessFactory;
        private readonly ArticleService _articleService;
        public ReportService(DataAccessFactory dataAccessFactory, ArticleService articleService)
        {
            _dataAccessFactory = dataAccessFactory;
            _articleService = articleService;
        }

        public void CreateReport(ReportDTO obj)
        {
            Report app = new Report();
            app.Username = obj.Username;
            app.Reason = obj.Reason;
            app.Status = "Pending";
            app.ReportedAt = DateTime.Now;
            _dataAccessFactory.ReportData().Create(app);
        }

        public ReportDTO? GetReport(int repId)
        {
            var data = _dataAccessFactory.ReportData().Get(repId);
            if (data != null)
            {
                var app = Convert(data);
                return app;
            }
            else
            {
                return null;
            }
        }

        public List<ReportDTO> GetReportByUser(string username)
        {
            var data = _dataAccessFactory.ReportData().GetReportByUser(username);
            return Convert(data);
        }

        public List<ReportDTO> GetAll()
        {
            var data = _dataAccessFactory.ReportData().GetAll();
            return Convert(data);
        }
        public List<ReportDTO> GetAllApproved()
        {
            var data = _dataAccessFactory.ReportData().GetAllApproved();
            return Convert(data);
        }

        public List<ReportDTO> GetAllRejected()
        {
            var data = _dataAccessFactory.ReportData().GetAllRejected();
            return Convert(data);
        }
        public List<ReportDTO> GetAllPendings()
        {
            var data = _dataAccessFactory.ReportData().GetAllPendings();
            return Convert(data);
        }
        public void Approve(int repId, int articleId)
        {
            _articleService.RemoveArticle(articleId);
            _dataAccessFactory.ReportData().Approve(repId);
        }
        public void Reject(int repId)
        {
            _dataAccessFactory.ReportData().Reject(repId);
        }

        public List<ReportDTO> Convert(List<Report> data)
        {
            List<ReportDTO> reports = new List<ReportDTO>();
            foreach (var app in data)
            {
                reports.Add(Convert(app));
            }
            return reports;
        }

        public ReportDTO Convert(Report obj)
        {
            ReportDTO app = new ReportDTO();
            app.ReportId = obj.ReportId;
            app.Username = obj.Username;
            app.Reason = obj.Reason;
            app.Status = obj.Status;
            app.ReportedAt = obj.ReportedAt;
            return app;
        }
    }
}
