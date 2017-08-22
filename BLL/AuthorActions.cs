using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class AuthorActions
    {
        private Author TAuthor;
        private List<Author> BalAuthorList;
        private AuthorModel LocalAuthor;
        private List<AuthorModel> AuthorList;

        ChallengeEntities manager = new ChallengeEntities();
        public IEnumerable<AuthorModel> GetAuthors()
        {

            BalAuthorList = manager.Author.ToList();
            AuthorList = new List<AuthorModel>();

            foreach (var values in BalAuthorList)
            {
                LocalAuthor = new AuthorModel();
                LocalAuthor.Id = values.Id;
                LocalAuthor.Name = values.Name;
                LocalAuthor.PhoneNumber = values.PhoneNumber;
                LocalAuthor.EmailAddress = values.EmailAddress;
                AuthorList.Add(LocalAuthor);
            };
            return AuthorList;
        }

        public AuthorModel GetAuthorByName(string name)
        {
            LocalAuthor = new AuthorModel();
            var getAuthor = manager.Author.FirstOrDefault(x => x.Name == name);

            LocalAuthor.Id = getAuthor.Id;
            LocalAuthor.Name = getAuthor.Name;
            LocalAuthor.EmailAddress = getAuthor.EmailAddress;
            LocalAuthor.PhoneNumber = getAuthor.PhoneNumber;

            return LocalAuthor;
        }

        public void AddAuthor(AuthorModel addAuthor)
        {
            TAuthor = new Author();
            //   LocalAuthor = new AuthorModel();
            TAuthor.Id = addAuthor.Id;
            TAuthor.Name = addAuthor.Name;
            TAuthor.PhoneNumber = addAuthor.PhoneNumber;
            TAuthor.EmailAddress = addAuthor.EmailAddress;
            manager.Author.Add(TAuthor);
            manager.SaveChanges();

        }

        public void UpdateAuthor(int id,AuthorModel updateAuthor)
        {
            var editAuthor = manager.Author.FirstOrDefault(x => x.Id == id);

            if(editAuthor == null)
            {
                throw new Exception(string.Format("Task with id {0} not exists.", updateAuthor.Id));
            }

            //LocalAuthor = new AuthorModel();
            //LocalAuthor.Id = editAuthor.Id;
            //LocalAuthor.Name = editAuthor.Name;
            //LocalAuthor.EmailAddress = editAuthor.EmailAddress;
            //LocalAuthor.PhoneNumber = editAuthor.PhoneNumber;
            manager.Entry(editAuthor).CurrentValues.SetValues(updateAuthor);
            manager.SaveChanges();
            
        }

        public void RemoveAuthor(int id)
        {
           
            var deleteAuthor = manager.Author.FirstOrDefault(x => x.Id == id);
            manager.Author.Remove(deleteAuthor);
            manager.SaveChanges();

        }
    }
}
