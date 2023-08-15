using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace DemoProject
{
    public class UserInfoDal
    {
        NoteDal _noteDal = new NoteDal();
        public List<TeamLead> Get()
        {
            using (UserInfoContext context = new UserInfoContext())
            {
                return context.TeamLeads.ToList();
            }
        }
        public bool IsEmailUsed(IUser user)
        {
            using (UserInfoContext context = new UserInfoContext())
            {
                return context.TeamLeads.Any(user1 => user1.Email == user.Email) || context.Interns.Any(user1 => user1.Email == user.Email);
            }
        }
        public bool IsEmailOk(IUser user)
        {
            return user.Email.Contains("@");
        }
        public bool IsPasswordOk(IUser user)
        {
            return user.Password.Length >= 4;
        }
        public string Add(IUser user)
        {
            using (UserInfoContext context = new UserInfoContext())
            {
                if (IsEmailUsed(user)) return "AIS"; //Already In Use
                if (!IsEmailOk(user)) return "EP"; //Email Problem
                if (!IsPasswordOk(user)) return "PP"; //Password Problem
                if (user is TeamLead teamLead) context.TeamLeads.Add(teamLead);
                else if (user is Intern intern) context.Interns.Add(intern);
                context.SaveChanges();
                return "OK";
            }
        }
        public IUser LogIn(string email, string password)
        {
            using (UserInfoContext context = new UserInfoContext())
            {
                if (context.Interns.Any(user1 => user1.Email == email && user1.Password == password))
                {
                    return context.Interns.FirstOrDefault(user1 => user1.Email == email);
                }
                if (context.TeamLeads.Any(user1 => user1.Email == email && user1.Password == password))
                {
                    return context.TeamLeads.FirstOrDefault(user1 => user1.Email == email);
                }
                return null;
            }
        }
        public Intern[] GetInterns(TeamLead user)
        {
            using (UserInfoContext context = new UserInfoContext())
            {
                return context.Interns.Where(p => p.TeamleadId == user.Id).ToArray();
            }
        }
        public void Update(IUser user)
        {
            using (UserInfoContext context = new UserInfoContext())
            {
                if (user is TeamLead teamLead)
                {
                    var entity = context.Entry(teamLead);
                    entity.State = EntityState.Modified;
                    context.SaveChanges();
                }
                else if (user is Intern intern)
                {
                    var entity = context.Entry(intern);
                    entity.State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
        public void AdjustNewTeamlead(Intern intern, int newId)
        {
            using (UserInfoContext context = new UserInfoContext())
            {
                intern.TeamleadId = newId;
                var entity = context.Entry(intern).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void RemoveTeamleadOrIntern(IUser user, int newTeamleadId = -1)
        {
            using (UserInfoContext context = new UserInfoContext())
            {
                if (user is Intern intern)
                {
                    _noteDal.RemoveRets(intern.Id);
                    context.Entry(intern).State = EntityState.Deleted;
                    context.SaveChanges();
                }
                else if (user is TeamLead teamLead)
                {
                    Intern[] interns = GetInterns(teamLead);
                    foreach (Intern intern1 in interns)
                    {
                        intern1.TeamleadId = newTeamleadId;
                        context.Entry(intern1).State = EntityState.Modified;
                    }
                    context.Entry(teamLead).State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
        }
        public TeamLead[] GetTeamleadForInterns(TeamLead teamLead)
        {
            using (UserInfoContext context = new UserInfoContext())
            {
                return context.TeamLeads.Where(p => p.Id != teamLead.Id).ToArray();
            }
        }
    }
}
