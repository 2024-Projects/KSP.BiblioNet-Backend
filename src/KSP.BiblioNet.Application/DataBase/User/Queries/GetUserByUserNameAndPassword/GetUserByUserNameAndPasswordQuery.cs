using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.User.Queries.GetUserByUserNameAndPassword
{
    public class GetUserByUserNameAndPasswordQuery: IGetUserByUserNameAndPasswordQuery
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;

        public GetUserByUserNameAndPasswordQuery(IDataBaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<GetUserByUserNameAndPasswordModel> Execute(string userName, string password)
        {
            var entity = await _databaseService.Users
                .FirstOrDefaultAsync(x => x.UserName == userName &&  x.Password == password);

                   // Con mapper le pasamos el modelo para que mapee la entidad                 
            return _mapper.Map<GetUserByUserNameAndPasswordModel>(entity);
        }


    }
}
