namespace KSP.BiblioNet.Application.DataBase.Book.Commands.CreateBook
{
    public class CreateBookModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int AvailableCopies { get; set; }
        public string Genre { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
