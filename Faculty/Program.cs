using System;
using System.Collections.Generic;
using Faculty.Model;

namespace Faculty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Professor p1 = new Professor("Pera", "Peric", new DateTime(1958, 12, 2));
            Professor p2 = new Professor("Mika", "Lazic", new DateTime(1976, 11, 13));
        }

        List<Student> students = new List<Student>();
    }
}
