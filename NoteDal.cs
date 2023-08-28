using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace DemoProject
{
    public class NoteDal
    {
        public List<NoteWithReturn> GetAll(IUser user)
        {
            using (InternNotesContext context = new InternNotesContext())
            {
                var result = GenerateQuery();
                if (user is Intern intern) {
                   
                    return result.Where(p => p.AuthorId == intern.TeamleadId && p.InternId == intern.Id).ToList();
                    
                }
                else if (user is TeamLead teamlead)
                {
                    return result.Where(p=>p.AuthorId == teamlead.Id).ToList();
                }
                List<NoteWithReturn> notes = new List<NoteWithReturn>();
                return notes;
            }
        }
        public void Add(Note note, Intern[] interns)
        {
            using (InternNotesContext context = new InternNotesContext())
            {
                context.Notes.Add(note);
                context.SaveChanges();
                int id2 = context.Notes.OrderByDescending(item => item.Id).FirstOrDefault().Id;
                foreach (Intern intern in interns)
                {
                    context.Returns.Add(new Return
                    {
                        Status = "In Progress",
                        ExtraNotes = string.Empty,
                        InternId = intern.Id,
                        NoteId = id2,
                        InternName = intern.UserName
                    });
                }
                context.SaveChanges();
            }
        }
        public void Update(Note note, Return ret)
        {
            using (InternNotesContext context = new InternNotesContext())
            {
                var entity = context.Entry(note);
                var entity2 = context.Entry(ret);
                entity2.State = EntityState.Modified;
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(Note note, Return ret)
        {
            using (InternNotesContext context = new InternNotesContext())
            {
                var entity = context.Entry(note);
                var entity2 = context.Entry(ret);
                entity2.State = EntityState.Deleted;
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public List<NoteWithReturn> GetByTitle(string key, IUser user, string selectedItem = "", TeamLead User = null)
        {
            using (InternNotesContext context = new InternNotesContext())
            {
                List<NoteWithReturn> notes = new List<NoteWithReturn>();
                var result = GenerateQuery();
                if (user is TeamLead teamlead)
                {
                    notes =  result.Where(p => p.Title.ToLower().Contains(key.ToLower()) && p.AuthorId == teamlead.Id).ToList();
                }
                else if (user is Intern intern)
                {
                    notes = result.Where(p => p.Title.ToLower().Contains(key.ToLower()) && p.AuthorId == intern.TeamleadId && p.InternId == intern.Id).ToList();
                }
                if (selectedItem != "")
                {
                    List<NoteWithReturn> notes2 = GetByIntern(selectedItem, User);
                    return GetIntersection(notes, notes2);
                }
                return notes;
            }
        }
        public List<NoteWithReturn> GetIntersection(List<NoteWithReturn> l1 , List<NoteWithReturn> l2)
        {
            List<NoteWithReturn> result = new List<NoteWithReturn>();
            foreach (NoteWithReturn n1 in l1)
            {
                foreach(NoteWithReturn n2 in l2)
                {
                    if(n1.NoteId == n2.NoteId && n1.InternId == n2.InternId && n1.RetId == n2.RetId) result.Add(n1);
                }
            }
            return result;
        }
        public List<NoteWithReturn> GenerateQuery()
        {
            using (InternNotesContext context = new InternNotesContext())
            {
                var query = from note in context.Notes
                            join ret in context.Returns
                            on note.Id equals ret.NoteId
                            select new NoteWithReturn{
                                RetId = ret.Id,
                                NoteId = note.Id,
                                AuthorId = note.AuthorId,
                                Author = note.Author,
                                Title = note.Title,
                                Content = note.Content,
                                CreatedAt = note.CreatedAt,
                                LastUpdate = note.LastUpdate,
                                Status = ret.Status,
                                ExtraNotes = ret.ExtraNotes,
                                InternId = ret.InternId,
                                InternName = ret.InternName};
                return query.ToList();
            }
        }
        public List<NoteWithReturn> GetByIntern(string selectedItem, TeamLead user, string key = "", IUser user2 = null)
        {
            List<NoteWithReturn> l = GetAll(user);
            if (key != "")
            {
                List<NoteWithReturn> notes = GetByTitle(key, user2);
                if (selectedItem == "====NO FILTER====") return notes;
                return GetIntersection(l.Where(p => p.InternName == selectedItem).ToList(), notes);
            }
            if (selectedItem == "====NO FILTER====") return l;
            return l.Where(p => p.InternName == selectedItem).ToList();
        }

        public List<NoteWithReturn> GetByStatus(IUser user, string v)
        {
            List<NoteWithReturn> l = GetAll(user);
            if (v == "====NO FILTER====") return l;
            return l.Where(p => p.Status == v).ToList();
        }
        public void RemoveRets(int internId)
        {
            using (InternNotesContext context = new InternNotesContext())
            {
                List<Return> l = context.Returns.Where(p => p.InternId == internId).ToList();
                foreach (Return ret in l)
                {
                    context.Entry(ret).State = EntityState.Deleted;
                }
                context.SaveChanges();
            }
        }
        public void DeleteNotesAndReturnsOfADeletedTeamlead(TeamLead teamlead)
        {
            using (InternNotesContext context = new InternNotesContext())
            {
                List<Note> l = context.Notes.Where(p=>p.AuthorId == teamlead.Id).ToList();
                foreach(Note note in l)
                {
                    List<Return> r = context.Returns.Where(p=>p.NoteId == note.Id).ToList();
                    foreach (Return ret in r)
                    {
                        context.Entry(ret).State = EntityState.Deleted;
                    }
                    var entity = context.Entry(note).State = EntityState.Deleted;
                }
                context.SaveChanges();
            }
        }
    }
}