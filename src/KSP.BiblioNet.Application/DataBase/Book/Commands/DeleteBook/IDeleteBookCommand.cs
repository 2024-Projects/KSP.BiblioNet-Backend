using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.Book.Commands.DeleteBook
{
    public interface IDeleteBookCommand
    {
        Task<bool> Execute(int bookId);
    }
}
