namespace Adilicious.Core
{
    using System.Collections.Generic;

    public interface IAdRepository
    {
        IEnumerable<Ad> GetAll();
    }
}