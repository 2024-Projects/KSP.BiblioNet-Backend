﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.User.Queries.GetUserById
{
    public class GetUserByIdModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<string> Roles { get; set; } 
    }
}
