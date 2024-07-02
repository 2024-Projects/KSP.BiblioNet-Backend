using KSP.BiblioNet.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.Book.Commands.UpdateBook
{
    public class UpdateBookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int AvailableCopies { get; set; }
        public string Genre { get; set; }
        public DateTime PublicationDate { get; set; }
        public LoanStatus Status { get; set; } 
    }
}
