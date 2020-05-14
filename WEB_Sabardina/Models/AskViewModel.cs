using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_Sabardina.Models
{
    public class AskViewModel
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public string Question { get; set; }
        public int UserId { get; set; }

        public UserViewModel User { get; set; }
    }
}