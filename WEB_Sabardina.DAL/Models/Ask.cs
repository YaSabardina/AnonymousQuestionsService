using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB_Sabardina.DAL.Models
{
    public class Ask
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public string Question { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
