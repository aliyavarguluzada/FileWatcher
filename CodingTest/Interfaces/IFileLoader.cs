using CodingTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.Interfaces
{
    public interface IFileLoader
    {
        Task<List<Data>> LoadDataAsync(string filePath);
        bool CanLoad(string fileExtension);
    }
}
