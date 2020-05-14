using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_Sabardina.Models
{
    public class ProfUserViewModel
    {
        public UserViewModel User { get; set; }
        public List<AskViewModel> Asks { get; set; }

    }
}