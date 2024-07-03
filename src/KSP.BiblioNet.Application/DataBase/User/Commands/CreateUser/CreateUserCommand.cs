using AutoMapper;
using KSP.BiblioNet.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.User.Commands.CreateUser
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateUserCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }
        public async Task<CreateUserModel> Execute(CreateUserModel model)
        {
            var entity = _mapper.Map<UserEntity>(model);

            if (model.RoleIds != null && model.RoleIds.Any())
            {
                entity.UserRoles = model.RoleIds.Select(roleId => new UserRoleEntity { RoleId = roleId, User = entity }).ToList();
            }

            await _dataBaseService.Users.AddAsync(entity);
            await _dataBaseService.SaveAsync();
            return model;


        }
    } 
}


