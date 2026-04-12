using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary
{
    public delegate string fPtrBook(Book B);
    public class LibraryEngine
    {

        //4way to print data of book
        public static void ProcessBooks(List<Book> bList, fPtrBook fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
    }
}
