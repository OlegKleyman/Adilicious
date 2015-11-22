namespace Adilicious.Core.Data
{
    using System.Collections.Generic;
    
    using Mediaradar;

    public interface IAdDataProxy
    {
        IEnumerable<Ad> GetAll();

        IEnumerable<Ad> GetByPosition(string position);
    }
}