using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MainCore.Tags
{
    /// <summary>
    /// Defines an observable catalog (add, remove, read) of category members.
    /// All category members in Como must be produced by an catalog.
    /// </summary>
    public interface ITagCatalog: IEnumerable<Tag>, INotifyCollectionChanged    
    {
        /// <summary>
        /// Adds a new category member, e.g. "CITY/BERLIN".
        /// Throws an exception if names are no valid identifier or if the member name ist a filter like NONE or MULTIPLE.
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        Tag AddMember(string categoryName, string memberName);
        /// <summary>
        /// Checks whether the catalog already contains such a named member.
        /// If names are no valid identifier, false will be returned.
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        bool ContainsMember(string categoryName, string memberName);
        /// <summary>
        /// Removes a member from this catalog.
        /// </summary>
        /// <param name="member"></param>
        void RemoveMember(Tag member);
        /// <summary>
        /// Removes an entire category (all its members).
        /// Throws an exception on NULL.
        /// </summary>
        /// <param name="category">will be uppercased internally, NULL ist not allowed</param>
        void RemoveCategory(string category);
        /// <summary>
        /// Replaces a category member with a new one.
        /// Throws an exception if the member is already included or the syntax was violated.
        /// </summary>
        /// <remarks>
        /// The category member is replaced, not renamed. Because members are used in hash tables (dictionaries)
        /// and member's hash code is computed by its name parts. If you change the name, you cannot remove the member 
        /// from all containing dictionaries. The old hash code was used to place the element, the new hash code references 
        /// an empty slot.
        /// </remarks>
        /// <param name="member"></param>
        /// <param name="categoryName"></param>
        /// <param name="memberName"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        Tag ReplaceMember(Tag member, string categoryName, string memberName, Color color);
    }       
}
