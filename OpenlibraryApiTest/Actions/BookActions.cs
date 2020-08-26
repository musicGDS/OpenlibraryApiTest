using OpenlibraryApiTest.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenlibraryApiTest.Handlers
{
    static class BookActions
    {
        public static string GetTitle(BookModel book)
        {
            return book.Title;
        }
    }
}
