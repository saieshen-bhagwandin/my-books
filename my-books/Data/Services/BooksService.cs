using my_books.Data.Models;
using my_books.Data.ViewModels;

namespace my_books.Data.Services
{
    public class BooksService
    {

        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
                _context = context; 
        }


        public void AddBookWithAuthors(BookVM book) {


            var _book = new Book() {


                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverURL = book.CoverURL,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherID

            };

            _context.Books.Add(_book);  
            _context.SaveChanges();

            foreach (var id in book.AuthorId) {

                var _book_author = new Book_Author()
                {

                    BookId = _book.Id,
                    AuthorId = id


                };


                _context.Books_Authors.Add(_book_author);
                _context.SaveChanges();
            
            }
        
        }

        public List<Book> GetAllBooks() {


            var allBooks = _context.Books.ToList();

            return allBooks;
        
        
        }


        public Book GetBookById(int BookId) {

           var singleBook =  _context.Books.FirstOrDefault(n => n.Id == BookId);


            return singleBook;
        
        
        }


        public Book UpdateBookById(int BookId, BookVM book) {

            var _book = _context.Books.FirstOrDefault(n => n.Id == BookId);

                if(_book != null) {


                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;

                if (book.Genre == "string") {

                    _book.Genre = _book.Genre;

                }
                
    
                _book.CoverURL = book.CoverURL;

                _context.SaveChanges();


            }


            return _book;
        }


        public void DeleteBookById(int BookId) {


            var _book = _context.Books.FirstOrDefault(n => n.Id == BookId);

            if (_book != null) {


                _context.Books.Remove(_book);

                _context.SaveChanges();
            
            }



        }
    }
}
