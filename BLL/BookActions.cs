using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BookActions
    {
        private Book TBook;
        private List<Book> BalBookList;
        private BookModel LocalBook;
        private List<BookModel> BookList;

        ChallengeEntities manager = new ChallengeEntities();
        public IEnumerable<BookModel> GetBooks()
        {
            BalBookList = manager.Books.ToList();
            BookList = new List<BookModel>();

            foreach (var values in BalBookList)
            {
                LocalBook = new BookModel();
                LocalBook.Id = values.Id;
                LocalBook.Name = values.Name;
                LocalBook.AuthorId = values.AuthorId;
                LocalBook.ISBN = values.ISBN;
                LocalBook.PublishDate = values.PublishDate;
                BookList.Add(LocalBook);
            };
            return BookList;
        }
        
        public BookModel GetBookByName(int id)
        {
            LocalBook = new BookModel();
            var getBook = manager.Books.FirstOrDefault(x => x.Id == id);

            LocalBook.Id = getBook.Id;
            LocalBook.Name = getBook.Name;
            LocalBook.AuthorId = getBook.AuthorId;
            LocalBook.ISBN = getBook.ISBN;
            LocalBook.PublishDate = getBook.PublishDate;
            return LocalBook;
        }
    }
}
