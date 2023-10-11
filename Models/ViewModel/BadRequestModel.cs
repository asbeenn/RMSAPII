using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class BadRequestModel
    {
        public int Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}
