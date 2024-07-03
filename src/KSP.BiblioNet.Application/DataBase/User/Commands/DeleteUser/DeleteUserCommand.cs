using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.User.Commands.DeleteUser
{
    public class DeleteUserCommand: IDeleteUserCommand
    {
        private readonly IDataBaseService _dataBaseService;

        public DeleteUserCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<bool> Execute(int userId)
        {
            var entity = await _dataBaseService.Users.FirstOrDefaultAsync(x => x.Id == userId);
            
            if (entity == null) return false;

            _dataBaseService.Users.Remove(entity);

            return await _dataBaseService.SaveAsync();

        }

    }
}
