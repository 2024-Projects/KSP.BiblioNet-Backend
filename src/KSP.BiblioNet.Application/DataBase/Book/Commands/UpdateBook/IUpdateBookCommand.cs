using KSP.BiblioNet.Application.DataBase.User.Commands.UpdateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.Book.Commands.UpdateBook
{
    public interface IUpdateBookCommand
    {
        Task<UpdateBookModel> Execute(UpdateBookModel model);
    }
}
