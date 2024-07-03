using AutoMapper;
using KSP.BiblioNet.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.User.Commands.UpdateUser
{
    public class UpdateUserCommand: IUpdateUserCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateUserCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<UpdateUserModel> Execute(UpdateUserModel model) 
        {

             var entity = await _dataBaseService.Users
                      .Include(u => u.UserRoles)
                      .FirstOrDefaultAsync(u => u.Id == model.Id);

            if (entity == null)
            {
                throw new Exception("User not found");
            }

            entity.Name = model.Name;
            entity.Email = model.Email;
            entity.Password = model.Password;
            entity.Address = model.Address;

            entity.UserRoles.Clear();
            foreach (var roleName in model.Roles)
            {
                var role = await _dataBaseService.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);
                if (role != null)
                {
                    entity.UserRoles.Add(new UserRoleEntity { UserId = entity.Id, RoleId = role.Id });
                }
            }

            _dataBaseService.Users.Update(entity);
            await _dataBaseService.SaveAsync();
            return model;

        } 


    }
}
