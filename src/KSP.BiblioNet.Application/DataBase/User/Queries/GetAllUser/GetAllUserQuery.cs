using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace KSP.BiblioNet.Application.DataBase.User.Queries.GetAllUser
{
    public class GetAllUserQuery : IGetAllUserQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetAllUserQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }
        public async Task<List<GetAllUserModel>> Execute()
        {
            var listEntity = await _dataBaseService.Users
                        .Include(u => u.UserRoles)
                        .ThenInclude(ur => ur.Role)
                        .ToListAsync();

            var models = _mapper.Map<List<GetAllUserModel>>(listEntity);

            foreach (var model in models)
            {
                var userEntity = listEntity.FirstOrDefault(u => u.Id == model.Id);
                model.Roles = userEntity.UserRoles.Select(ur => ur.Role.RoleName).ToList();
            }

            return models;

        }
    }
}
