using AutoMapper;
using KSP.BiblioNet.Application.DataBase.Book.Queries.GetBookById;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.Book.Queries.GetBookByISBN
{
    public class GetBookByISBNQuery: IGetBookByISBNQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetBookByISBNQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }
        public async Task<GetBookByISBNModel> Execute(string isbn)
        {
            var entity = await _dataBaseService.Books
                .FirstOrDefaultAsync(x => x.ISBN == isbn);

            return _mapper.Map<GetBookByISBNModel>(entity);
        }
    }
}
