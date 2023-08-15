using DemoProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DemoProject
{
    public class NoteWithReturn
    {
        public int RetId { get; set; }
        public int NoteId { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Status { get; set; }
        public string ExtraNotes { get; set; }
        public int InternId { get; set; }
        public string InternName { get; set; }

    }
}