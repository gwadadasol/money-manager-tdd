using Microsoft.AspNetCore.Mvc;
using TransactionMicroService.Models;
using TransactionMicroService.Services;

namespace TransactionService.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
    //private readonly ILogger<TransactionController> _logger;

    //public TransactionController(ILogger<TransactionController> logger)
    //{
    //    _logger = logger;
    //}

    ITransactionSrvc _service;

    public TransactionController(ITransactionSrvc service)
    {
        _service = service;
    }

    [HttpGet(ApiRoutes.Transaction.GetAll)]
    public ActionResult<List<Transaction>> GetAll()
    {
        try
        {
            var result = _service.GetAllTransactions();
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpPost(ApiRoutes.Transaction.Create)]
    public ActionResult<List<Transaction>> Post(Transaction transaction)
    {
        _service.AddTransaction(transaction);
        return Ok();

}
}
