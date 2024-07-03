using AutoMapper;
using KSP.BiblioNet.Application.DataBase.User.Queries.GetAllUser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.Book.Queries.GetAllBooks
{
    public class GetAllBookQuery: IGetAllBookQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetAllBookQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        } 
        public async Task<List<GetAllBookModel>> Execute()
        {
            var listEntity = await _dataBaseService.Books.ToListAsync();
            return _mapper.Map<List<GetAllBookModel>>(listEntity);
        }
    }
}
