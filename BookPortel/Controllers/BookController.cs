using BookPortel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookPortel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        public readonly TrainingDBContext trainingDBContext;
        public BookController(TrainingDBContext _trainingDBContext)
        {
            trainingDBContext = _trainingDBContext;
        }
        [HttpGet("GetBookDetails")]
        public List<Book> GetBookDetails()
        {
            List<Book> lstBook = new List<Book>();
            try
            {
                lstBook = trainingDBContext.Book.ToList();
                return lstBook;
            }
            catch (Exception ex)
            {
                lstBook = new List<Book>();
                return lstBook;
            }
        }
        [HttpPost("AddBook")]
        public string AddBook(Book book)
        {
            string message = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(book.BookName))
                {
                    trainingDBContext.Add(book);
                    trainingDBContext.SaveChanges();
                    message = "Book added successfully";
                }
                else
                    message = "Book Name required.";

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
    }
}
