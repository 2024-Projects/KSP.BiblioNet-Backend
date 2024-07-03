using FluentValidation;
using KSP.BiblioNet.Application.DataBase.Loan.Commands.CreateLoan;
using KSP.BiblioNet.Application.DataBase.Loan.Commands.UpdateLoan;
using KSP.BiblioNet.Application.DataBase.Loan.Queries.GetAllLoan;
using KSP.BiblioNet.Application.Exceptions;
using KSP.BiblioNet.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace KSP.BiblioNet.Api.Controllers
{
    [Route("api/v1/loan")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class LoanController : ControllerBase
    {

        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateLoanModel model,
            [FromServices] ICreateLoanCommand createLoanCommand,
            [FromServices] IValidator<CreateLoanModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await createLoanCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateLoanModel model,
            [FromServices] IUpdateLoanCommand updateLoanCommand,
            [FromServices] IValidator<UpdateLoanModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            
            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await updateLoanCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }


        [HttpGet("get-paginated")]
        public async Task<IActionResult> GetPaginated(
            [FromServices] IGetAllLoanQuery getAllLoanQuery,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10 )
        {
            var data = await getAllLoanQuery.Execute(pageNumber, pageSize);

            if (data == null || data.Items.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
    }
}
