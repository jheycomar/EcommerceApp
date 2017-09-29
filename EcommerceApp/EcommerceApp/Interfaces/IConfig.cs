using SQLite.Net.Interop;

namespace EcommerceApp.Interfaces
{
    public interface IConfig
    {
        string DirectoryDB { get; }

        ISQLitePlatform Platform { get; }

    }
}
