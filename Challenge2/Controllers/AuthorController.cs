using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using Challenge2.Models;
using BLL;


namespace Challenge2.Controllers
{
    public class AuthorController : ApiController
    {
        AuthorActions AActions;
        


        public IEnumerable<AuthorModel> get()
        {
            AActions = new AuthorActions();
            return AActions.GetAuthors();
        }

        public AuthorModel Get(string id)
        {
            AActions = new AuthorActions();
            return AActions.GetAuthorByName(id);
        }

        public void Post([FromBody]AuthorModel addAuthor)
        {
            AActions = new AuthorActions();
            AActions.AddAuthor(addAuthor);
        }

        public void Put(int id, AuthorModel updateAuthor)
        {
            AActions = new AuthorActions();
            AActions.UpdateAuthor(id, updateAuthor);
        }

        public void Put(int id)
        {
            AActions = new AuthorActions();
            AActions.RemoveAuthor(id);
        }

    }
}
