using FluentValidation;
using KSP.BiblioNet.Application.DataBase.Book.Commands.CreateBook;
using KSP.BiblioNet.Application.DataBase.Book.Commands.DeleteBook;
using KSP.BiblioNet.Application.DataBase.Book.Commands.UpdateBook;
using KSP.BiblioNet.Application.DataBase.Book.Queries.GetAllBooks;
using KSP.BiblioNet.Application.DataBase.Book.Queries.GetBookById;
using KSP.BiblioNet.Application.DataBase.Book.Queries.GetBookByISBN;
using KSP.BiblioNet.Application.Exceptions;
using KSP.BiblioNet.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace KSP.BiblioNet.Api.Controllers
{
    [Route("api/v1/book")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class BookController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateBookModel model,
            [FromServices] ICreateBookCommand createBookCommand,
            [FromServices] IValidator<CreateBookModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await createBookCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }


        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateBookModel model,
            [FromServices] IUpdateBookCommand updateBookCommand,
            [FromServices] IValidator<UpdateBookModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await updateBookCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }


        [HttpDelete("delete/{BookId}")]
        public async Task<IActionResult> Delete(
           int BookId,
           [FromServices] IDeleteBookCommand deleteBookCommand)
        {
            if (BookId == 0)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await deleteBookCommand.Execute(BookId);

            if (!data)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }


        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromServices] IGetAllBookQuery getAllBookQuery)
        {
            var data = await getAllBookQuery.Execute();

            if (data == null || data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }


        [HttpGet("get-by-id/{BookId}")]
        public async Task<IActionResult> GetById(
           int BookId,
           [FromServices] IGetBookByIdQuery getBookByIdQuery)
        {

            if (BookId == 0)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await getBookByIdQuery.Execute(BookId);

            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-by-isbn/{ISBN}")]
        public async Task<IActionResult> GetByISBN(
            string ISBN,
            [FromServices] IGetBookByISBNQuery getBookByISBNQuery, 
            [FromServices] IValidator<string> validator)
        {
            var validate = await validator.ValidateAsync(ISBN);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await getBookByISBNQuery.Execute(ISBN);

            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }


    }
}
