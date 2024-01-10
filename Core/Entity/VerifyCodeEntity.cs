using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class VerifyCodeEntity
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
