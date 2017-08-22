using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BLL;
using DAL;

namespace Challenge2.Controllers
{
    public class BookController : ApiController
    {
            BookActions BActions;

            public IEnumerable<BookModel> get()
            {
                BActions = new BookActions();
            return BActions.GetBooks();
            }

            public BookModel Get(int id)
            {
                BActions = new BookActions();
                return BActions.GetBookByName(id);
            }

        }
    }