using app.data_access.Data;
using app.data_access.Models;
using app.services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.services.Repositories
{
    public class ImageRetrieveSqlRepository : IImageRetrieveSqlRepository
    {
        private readonly ApplicationDbContext _context;

        public ImageRetrieveSqlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Image> CreateAsync(Image item)
        {
            var createdItem = _context.Images.Add(item).Entity;
            await _context.SaveChangesAsync();

            return createdItem;
        }

        public async Task<Image> DeleteAsync(Guid id)
        {
            var itemToDelete = await _context.Images.Where(img => img.Id == id).FirstOrDefaultAsync();
            var deletedImage = _context.Images.Remove(itemToDelete).Entity;
            await _context.SaveChangesAsync();

            return deletedImage;
        }

        public async Task<IEnumerable<Image>> GetAllItemsAsync()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task<IEnumerable<Image>> GetImagesAsync(int start, int end, Categories category)
        {
            return 
                (await _context
                .Images
                .Where(img => category == Categories.All ? true : img.Category == category)
                .Skip(start)
                .Take(end - start)
                .ToListAsync())
                .Select(img =>
                 {
                     img.Path = Constants.Constants.HostUrl + '/' + img.Path;
                     return img;
                 });
        }

        public async Task<Image> GetItemAsync(Guid id)
        {
            var image = await _context.Images.Where(img => img.Id == id).FirstOrDefaultAsync();
            image.Path = Constants.Constants.HostUrl + '/' + image.Path;

            return image;
        }

        public async Task<Image> UpdateAsync(Image item)
        {
            var updatedItem = _context.Images.Update(item).Entity;
            await _context.SaveChangesAsync();

            return updatedItem;
        }
    }
}
