﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.User.Commands.DeleteUser
{
    public interface IDeleteUserCommand
    {
        Task<bool> Execute(int userId);
    }
}
