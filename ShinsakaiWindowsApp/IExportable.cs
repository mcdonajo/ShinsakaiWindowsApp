using System.IO;

namespace ShinsakaiWindowsApp
{
    public interface IExportable
    {
        void export(StreamWriter file);
    }
}
