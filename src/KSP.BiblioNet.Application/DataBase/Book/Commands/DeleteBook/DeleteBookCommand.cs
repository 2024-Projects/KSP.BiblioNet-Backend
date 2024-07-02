using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.Book.Commands.DeleteBook
{
    public class DeleteBookCommand: IDeleteBookCommand
    {
        private readonly IDataBaseService _dataBaseService;

        public DeleteBookCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<bool> Execute(int bookId)
        {
            var entity = await _dataBaseService.Books.FirstOrDefaultAsync(x => x.Id == bookId);

            if (entity == null) return false;

            _dataBaseService.Books.Remove(entity);

            return await _dataBaseService.SaveAsync();

        }
    }
}
