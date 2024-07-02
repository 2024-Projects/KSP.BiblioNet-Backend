using AutoMapper;
using KSP.BiblioNet.Application.DataBase.Book.Commands.CreateBook;
using KSP.BiblioNet.Application.DataBase.Book.Commands.UpdateBook;
using KSP.BiblioNet.Application.DataBase.Book.Queries.GetAllBooks;
using KSP.BiblioNet.Application.DataBase.Book.Queries.GetBookById;
using KSP.BiblioNet.Application.DataBase.Book.Queries.GetBookByISBN;
using KSP.BiblioNet.Application.DataBase.Loan.Commands.CreateLoan;
using KSP.BiblioNet.Application.DataBase.Loan.Commands.UpdateLoan;
using KSP.BiblioNet.Application.DataBase.Loan.Queries.GetAllLoan;
using KSP.BiblioNet.Application.DataBase.User.Commands.CreateUser;
using KSP.BiblioNet.Application.DataBase.User.Commands.UpdateUser;
using KSP.BiblioNet.Application.DataBase.User.Queries.GetAllUser;
using KSP.BiblioNet.Application.DataBase.User.Queries.GetUserById;
using KSP.BiblioNet.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using KSP.BiblioNet.Domain.Entities.Book;
using KSP.BiblioNet.Domain.Entities.Loan;
using KSP.BiblioNet.Domain.Entities.User;

namespace KSP.BiblioNet.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region User
            CreateMap<UserEntity, CreateUserModel>().ReverseMap();
            CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
            CreateMap<UserEntity, GetAllUserModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByIdModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByUserNameAndPasswordModel>().ReverseMap();
            #endregion

            #region Book
            CreateMap<BookEntity, CreateBookModel>().ReverseMap();
            CreateMap<BookEntity, UpdateBookModel>().ReverseMap();
            CreateMap<BookEntity, GetAllBookModel>().ReverseMap();
            CreateMap<BookEntity, GetBookByIdModel>().ReverseMap();
            CreateMap<BookEntity, GetBookByISBNModel>().ReverseMap();
            #endregion

            #region Loan
            CreateMap<LoanEntity, CreateLoanModel>().ReverseMap();
            CreateMap<LoanEntity, UpdateLoanModel>().ReverseMap();
            CreateMap<LoanEntity, GetAllLoanModel>().ReverseMap();

            CreateMap<LoanEntity, GetAllLoanModel>()
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.Books, opt => opt.Ignore());
            CreateMap<UserEntity, UserModel>();
            CreateMap<BookEntity, BookModel>();


            #endregion


        }
    }
}
