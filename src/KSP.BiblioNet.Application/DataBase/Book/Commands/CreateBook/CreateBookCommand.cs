using AutoMapper;
using KSP.BiblioNet.Domain.Entities.Book;

namespace KSP.BiblioNet.Application.DataBase.Book.Commands.CreateBook
{
    public class CreateBookCommand: ICreateBookCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateBookCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }
        public async Task<CreateBookModel> Execute(CreateBookModel model)
        {
            var entity = _mapper.Map<BookEntity>(model);
            await _dataBaseService.Books.AddAsync(entity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
