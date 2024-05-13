using EasyReadsDAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsBLL.DTOs
{
    public class TokenDTO
    {
        public string TokenKey { get; set; }
        public string Username { get; set; }
    }
}
