using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using entityframework.Models;

namespace _09EntityFramework.Pages_Blog
{
    public class EditModel : PageModel
    {
        private readonly entityframework.Models.MyBlogContext _context;

        public EditModel(entityframework.Models.MyBlogContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Article Article { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return Content("Không thấy bài viết");
            }

            Article = await _context.articles.FirstOrDefaultAsync(m => m.Id == id);

            if (Article == null)
            {
                return Content("Không thấy bài viết");
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Article).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(Article.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ArticleExists(int id)
        {
            return _context.articles.Any(e => e.Id == id);
        }
    }
}
