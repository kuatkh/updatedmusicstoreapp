using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Components
{
    [ViewComponent(Name = "GenreMenu")]
    public class GenreMenuComponent : ViewComponent
    {
        public GenreMenuComponent(WebApplication1Context dbContext)
        {
            DbContext = dbContext;
        }

        private WebApplication1Context DbContext { get; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // TODO use nested sum https://github.com/aspnet/EntityFramework/issues/3792
            //.OrderByDescending(
            //    g => g.Albums.Sum(a => a.OrderDetails.Sum(od => od.Quantity)))
            
            var genres = await DbContext.Genres.Select(g => g.Name).Take(9).ToListAsync();

            return View(genres);
        }
    }
}