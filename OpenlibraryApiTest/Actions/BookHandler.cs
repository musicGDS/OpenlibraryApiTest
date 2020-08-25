using OpenlibraryApiTest.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenlibraryApiTest.Handlers
{
    static class BookHandler
    {
        public static string GetTitle(Book book)
        {
            return book.Title;
        }
    }
}
