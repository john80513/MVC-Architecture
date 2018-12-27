using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Service.ViewModels.Shared
{
    public class AuthTransModel
    {
        public string APName { get; set; }
        public string APNameEn { get; set; }
        public int APCode { get; set; }
        public bool HasAuthority { get; set; }
    }
}
