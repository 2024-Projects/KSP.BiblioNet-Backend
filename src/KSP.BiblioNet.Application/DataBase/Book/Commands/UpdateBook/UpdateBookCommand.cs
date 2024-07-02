using AutoMapper;
using KSP.BiblioNet.Application.DataBase.User.Commands.UpdateUser;
using KSP.BiblioNet.Domain.Entities.Book;
using KSP.BiblioNet.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.Book.Commands.UpdateBook
{
    public class UpdateBookCommand: IUpdateBookCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateBookCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<UpdateBookModel> Execute(UpdateBookModel model)
        {
            var entity = _mapper.Map<BookEntity>(model);
            _dataBaseService.Books.Update(entity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
