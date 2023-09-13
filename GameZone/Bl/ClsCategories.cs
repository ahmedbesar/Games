using GameZone.Models;

namespace GameZone.Bl
{
    public interface ICategories
    {
        public List<Category> GetAll();
        IEnumerable<SelectListItem> GetSelectedCategories();
        public Category GetById(int id);
        public bool Save(Category category);
        public bool Dekete(int id);
    }
    public class ClsCategories:ICategories
    {
        GameZoneDBContext context;
        public ClsCategories(GameZoneDBContext ctx)
        {
            context = ctx;
        }
        public List<Category> GetAll()
        {
            try
            {
                var lstCategories = context.Categories.ToList();
                return lstCategories;
            }
            catch
            {
                return new List<Category>();
            }
        }
        public IEnumerable<SelectListItem> GetSelectedCategories()
        {
            return context.Categories
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .OrderBy(c => c.Text)
                .AsNoTracking()
                .ToList();
        }
        public Category GetById(int id)
        {
            try
            {
                var category = context.Categories.FirstOrDefault(a => a.Id == id );
                return category;
            }
            catch
            {
                return new Category();
            }
        }

        public bool Save(Category category)
        {
            try
            {
                if (category.Id == 0)
                {
               
                    context.Categories.Add(category);
                }
                else
                {
           

                    context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Dekete(int id)
        {
            try
            {
                var category = GetById(id);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
