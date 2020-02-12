using System.IO;

namespace ShinsakaiWindowsApp
{
    public interface IImportable
    {
        string import(StreamReader file);
    }
}
