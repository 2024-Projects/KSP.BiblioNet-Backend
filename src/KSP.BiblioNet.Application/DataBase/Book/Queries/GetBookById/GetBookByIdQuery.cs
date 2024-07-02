using AutoMapper;
using KSP.BiblioNet.Application.DataBase.User.Queries.GetUserById;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.Book.Queries.GetBookById
{
    public class GetBookByIdQuery: IGetBookByIdQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetBookByIdQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }
        public async Task<GetBookByIdModel> Execute(int bookId)
        {
            var entity = await _dataBaseService.Books
                .FirstOrDefaultAsync(x => x.Id == bookId);

            return _mapper.Map<GetBookByIdModel>(entity);
        }
    }
}
