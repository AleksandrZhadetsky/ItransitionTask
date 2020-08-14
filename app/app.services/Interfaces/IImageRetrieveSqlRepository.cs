using app.data_access.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace app.services.Interfaces
{
    public interface IImageRetrieveSqlRepository : IRepository<Image, Guid>
    {
        Task<IEnumerable<Image>> GetImagesAsync(int start, int end, Categories category);
    }
}
