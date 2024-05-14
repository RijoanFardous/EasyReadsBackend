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
    public class ApplicationService
    {
        private readonly DataAccessFactory _dataAccessFactory;
        public ApplicationService(DataAccessFactory dataAccessFactory)
        {
            _dataAccessFactory = dataAccessFactory;
        }

        public void CreateApplication(ApplicationDTO obj)
        {
            Application app = new Application();
            app.Username = obj.Username;
            app.Description = obj.Description;
            app.Status = "Pending";
            app.AppliedAt = DateTime.Now;
            _dataAccessFactory.ApplicationData().Create(app);
        }

        public ApplicationDTO? GetApplication(int appId)
        {
            var data = _dataAccessFactory.ApplicationData().Get(appId);
            if(data != null)
            {
                var app = Convert(data);
                return app;
            }
            else
            {
                return null;
            }
        }

        public List<ApplicationDTO> GetApplicationByUser(string username)
        {
            var data = _dataAccessFactory.ApplicationData().GetApplicationByUser(username);
            return Convert(data);
        }

        public List<ApplicationDTO> GetAll()
        {
            var data = _dataAccessFactory.ApplicationData().GetAll();
            return Convert(data);
        }
        public List<ApplicationDTO> GetAllApproved()
        {
            var data = _dataAccessFactory.ApplicationData().GetAllApproved();
            return Convert(data);
        }

        public List<ApplicationDTO> GetAllRejected()
        {
            var data = _dataAccessFactory.ApplicationData().GetAllRejected();
            return Convert(data);
        }
        public List<ApplicationDTO> GetAllPendings()
        {
            var data = _dataAccessFactory.ApplicationData().GetAllPendings();
            return Convert(data);
        }
        public void Approve(int appId, string username)
        {
            _dataAccessFactory.UserData().MemberToAuthor(username);
            _dataAccessFactory.ApplicationData().Approve(appId);
        }
        public void Reject(int appId)
        {
            _dataAccessFactory.ApplicationData().Reject(appId);
        }

        public List<ApplicationDTO> Convert(List<Application> data)
        {
            List<ApplicationDTO> applications = new List<ApplicationDTO>();
            foreach(var app in data)
            {
                applications.Add(Convert(app));
            }
            return applications;
        }

        public ApplicationDTO Convert(Application obj)
        {
            ApplicationDTO app = new ApplicationDTO();
            app.ApplicationId = obj.ApplicationId;
            app.Username = obj.Username;
            app.Description = obj.Description;
            app.Status = obj.Status;
            app.AppliedAt = obj.AppliedAt;
            return app;
        }
    }
}
