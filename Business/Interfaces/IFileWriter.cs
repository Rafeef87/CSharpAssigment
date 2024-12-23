
using Business.Models;

namespace Business.Interfaces;

public interface IFileWriter
{
   bool SaveContactToFile(string list);
}