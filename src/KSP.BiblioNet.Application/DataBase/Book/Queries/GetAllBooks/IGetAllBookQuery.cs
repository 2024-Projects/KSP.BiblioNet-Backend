﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.Book.Queries.GetAllBooks
{
    public interface IGetAllBookQuery
    {
        Task<List<GetAllBookModel>> Execute();
    }
}
