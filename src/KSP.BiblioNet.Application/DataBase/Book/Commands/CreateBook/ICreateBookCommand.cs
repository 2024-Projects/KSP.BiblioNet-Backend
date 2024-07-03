using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.Book.Commands.CreateBook
{
    public interface ICreateBookCommand
    {
        Task<CreateBookModel> Execute(CreateBookModel model);
    }
}
