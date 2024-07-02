using AutoMapper;
using KSP.BiblioNet.Application.DataBase.User.Queries.GetAllUser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.User.Queries.GetUserById
{
    public class GetUserByIdQuery: IGetUserByIdQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetUserByIdQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }
        public async Task<GetUserByIdModel> Execute(int userId)
        {
            var entity = await _dataBaseService.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (entity == null)
            {
                return null;
            }

            var model = _mapper.Map<GetUserByIdModel>(entity);
            model.Roles = entity.UserRoles.Select(ur => ur.Role.RoleName).ToList();
            return model;

        }
    }
}
