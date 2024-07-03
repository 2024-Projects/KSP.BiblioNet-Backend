using AutoMapper;
using FluentValidation;
using KSP.BiblioNet.Application.Configuration;
using KSP.BiblioNet.Application.DataBase.Book.Commands.CreateBook;
using KSP.BiblioNet.Application.DataBase.Book.Commands.DeleteBook;
using KSP.BiblioNet.Application.DataBase.Book.Commands.UpdateBook;
using KSP.BiblioNet.Application.DataBase.Book.Queries.GetAllBooks;
using KSP.BiblioNet.Application.DataBase.Book.Queries.GetBookById;
using KSP.BiblioNet.Application.DataBase.Book.Queries.GetBookByISBN;
using KSP.BiblioNet.Application.DataBase.Loan.Commands.CreateLoan;
using KSP.BiblioNet.Application.DataBase.Loan.Commands.UpdateLoan;
using KSP.BiblioNet.Application.DataBase.Loan.Queries.GetAllLoan;
using KSP.BiblioNet.Application.DataBase.User.Commands.CreateUser;
using KSP.BiblioNet.Application.DataBase.User.Commands.DeleteUser;
using KSP.BiblioNet.Application.DataBase.User.Commands.UpdateUser;
using KSP.BiblioNet.Application.DataBase.User.Commands.UpdateUserPassword;
using KSP.BiblioNet.Application.DataBase.User.Queries.GetAllUser;
using KSP.BiblioNet.Application.DataBase.User.Queries.GetUserById;
using KSP.BiblioNet.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using KSP.BiblioNet.Application.Validators.Book;
using KSP.BiblioNet.Application.Validators.Loan;
using KSP.BiblioNet.Application.Validators.User;
using Microsoft.Extensions.DependencyInjection;

namespace KSP.BiblioNet.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });

            services.AddSingleton(mapper.CreateMapper());

            #region User
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<IUpdateUserPasswordCommand, UpdateUserPasswordCommand>();
            services.AddTransient<IGetAllUserQuery, GetAllUserQuery>();
            services.AddTransient<IGetUserByIdQuery, GetUserByIdQuery>();
            services.AddTransient<IGetUserByUserNameAndPasswordQuery, GetUserByUserNameAndPasswordQuery>();
            #endregion

            #region Book
            services.AddTransient<ICreateBookCommand, CreateBookCommand>();
            services.AddTransient<IUpdateBookCommand, UpdateBookCommand>();
            services.AddTransient<IDeleteBookCommand, DeleteBookCommand>();
            services.AddTransient<IGetAllBookQuery, GetAllBookQuery>();
            services.AddTransient<IGetBookByIdQuery, GetBookByIdQuery>();
            services.AddTransient<IGetBookByISBNQuery, GetBookByISBNQuery>();
            services.AddTransient<ICreateLoanCommand, CreateLoanCommand>();
            #endregion

            #region Loan
            services.AddTransient<ICreateLoanCommand, CreateLoanCommand>();
            services.AddTransient<IUpdateLoanCommand, UpdateLoanCommand>();
            services.AddTransient<IGetAllLoanQuery, GetAllLoanQuery>();
            #endregion


            #region User Validator
            services.AddScoped<IValidator<CreateUserModel>, CreateUserValidator>();
            services.AddScoped<IValidator<UpdateUserModel>, UpdateUserValidator>();
            services.AddScoped<IValidator<UpdateUserPasswordModel>, UpdateUserPasswordValidator>();
            services.AddScoped<IValidator<(string, string)>, GetUserByUserNameAndPasswordValidator>();
            #endregion


            #region Book Validator
            services.AddScoped<IValidator<CreateBookModel>, CreateBookValidator>();
            services.AddScoped<IValidator<UpdateBookModel>, UpdateBookValidator>();
            services.AddScoped<IValidator<string>, GetBookByISBNValidator>();
            #endregion


            #region Loan Validator
            services.AddScoped<IValidator<CreateLoanModel>, CreateLoanValidator>();
            services.AddScoped<IValidator<UpdateLoanModel>, UpdateLoanValidator>();
            #endregion


            return services;

        }
    }
}
