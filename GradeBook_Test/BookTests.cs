﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_GradeBook;
using Xunit;

namespace GradeBook_Test
{
    public class BookTests
    {
        [Fact]
        public void BookCalculateAndAverageGrade()
        {
            //arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //act
            var result = book.GetStatistics();

            //assert
            Assert.Equal(85.6, result.Average,1);
            Assert.Equal(90.5,result.High,1);
            Assert.Equal(77.3, result.Low,1);

        }
    }
}
