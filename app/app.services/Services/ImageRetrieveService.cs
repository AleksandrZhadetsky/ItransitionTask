using app.data_access.Models;
using app.services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.services.Services
{
    public class ImageRetrieveService : IImageRetrieveService
    {
        private readonly IImageRetrieveSqlRepository _repository;

        public ImageRetrieveService(IImageRetrieveSqlRepository repository)
        {
            _repository = repository;
        }

        public async Task<Image> GetImageAsync(Guid id)
        {
            return await _repository.GetItemAsync(id);
        }

        public async Task<IEnumerable<Image>> GetImagesAsync(int start, int end, Categories category)
        {
            return
                await _repository.GetImagesAsync(start, end, category);
        }

        public Task<IEnumerable<Image>> GetImagesByDateAsync(DateTime date, int start, int end)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Image>> GetImagesByUserAsync(string userId, int start, int end)
        {
            throw new NotImplementedException();
        }
    }
}
