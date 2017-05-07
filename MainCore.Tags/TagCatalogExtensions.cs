using System.Collections.Generic;
using System.Linq;

namespace MainCore.Tags
{
    /// <summary>
    /// CategoryCatalogExtensions contains the extensions for the ICategoryCatalog interface.
    /// </summary>
    public static class TagCatalogExtensions
    {
        /// <summary>
        /// Returns a list of the existing distinct category names of the category catalog.
        /// </summary>
        /// <returns>the disting category names</returns>
        public static IList<string> GetCategoryNames(this ITagCatalog catalog)
        {
            return catalog.Select(c => c.CategoryName).Distinct().ToList();
        }

        /// <summary>
        /// Returns a list of category members for the given category name.
        /// </summary>
        /// <param name="categoryName">the category name for which the member should be returned</param>
        /// <returns>The list of category members which are correspond to the given category name</returns>
        public static IList<Tag> GetCategoryMembers(this ITagCatalog catalog, string categoryName)
        {
            return catalog.Where(c => c.CategoryName.Equals(categoryName)).ToList();
        }
    }
}
