using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using withEF.Models;

namespace withEF.Pages_Blog
{
    public class IndexModel : PageModel
    {
        private readonly withEF.Models.ArticleContext _context;

        public IndexModel(withEF.Models.ArticleContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get; set; } = default!;
        public const int size = 10;
        public int currentPage { get; set; }
        public int CountPage { set; get; }


        public async Task OnGetAsync(string? querry, int p = 1)
        {

            if (_context.Article != null)
            {
                int count;
                IQueryable<Article> articles;
                if (querry == null)
                {
                    articles = from article in _context.Article
                                   orderby article.PublishDate descending
                                   select article;
                    count = await articles.CountAsync();
                }
                else
                {
                    articles = from article in _context.Article
                                   where article.Title.Contains(querry)
                                   orderby article.PublishDate descending
                                   select article;
                    count = await articles.CountAsync();
                }
                CountPage = (int)Math.Ceiling((double)count / size);
                if (p < 1)
                    currentPage = 1;
                else if (p > CountPage)
                    currentPage = CountPage;
                else
                    currentPage = p;
                Article = await articles.Skip((currentPage - 1) * size).Take(size).ToListAsync();
            }
        }
    }
}
