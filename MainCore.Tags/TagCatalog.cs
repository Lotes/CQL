using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MainCore.Tags
{
    /// <summary>
    /// Implementation of ICategoryCatalog.
    /// </summary>
    public class TagCatalog : ITagCatalog
    {
        private List<Tag> members;

        public TagCatalog()
        {
            Initialize();
        }

        private void Initialize()
        {
            this.members = new List<Tag>();
        }

        public Tag AddMember(string categoryName, string memberName)
        {
            var result = new Tag(categoryName, memberName, Colors.White);
            if (TagFilters.Names.Contains(result.MemberName))
                throw new ArgumentException("Filter member names are forbidden to add {" + string.Join(", ", TagFilters.Names) + "}.");
            foreach (var member in members)
                if (member.Equals(result))
                    return member;
            members.Add(result);
            NotifyCollectionChanged(result, null);
            return result;
        }

        public void RemoveMember(Tag me)
        {
            for (var index = 0; index < members.Count; index++)
            {
                var element = members[index];
                if (element.Equals(me))
                {
                    members.RemoveAt(index);
                    NotifyCollectionChanged(null, element );
                    return;
                }
            }
        }

        public void RemoveCategory(string category)
        {
            if (category == null)
                throw new ArgumentNullException("category");
            category = category.ToUpper();
            var removed = new List<Tag>();            
            for (var index = 0; index < members.Count;)
            {
                var element = members[index];
                if (!string.IsNullOrEmpty(element.CategoryName) && element.CategoryName.Equals(category))
                {
                    members.RemoveAt(index);
                    removed.Add(element);
                }
                else
                    index++;
            }
            if(removed.Count > 0)
                NotifyCollectionChanged(null, removed.ToArray());
        }

        public Tag ReplaceMember(Tag member, string categoryName, string memberName, Color color)
        {
            var replacement = new Tag(categoryName, memberName, color);
            if (member.Equals(replacement))
            {
                member.Color = color; //only replace color
                return member;
            }                
            else
            {
                if (members.Any(m => m.Equals(replacement)))
                    throw new InvalidOperationException("Category member already exists!");
                members.Remove(member);
                members.Add(replacement);
                NotifyCollectionChanged(replacement, member);
                return replacement;
            }
        }

        #region interface implementations
        public IEnumerator<Tag> GetEnumerator()
        {
            return members.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return members.GetEnumerator();
        }

        private void NotifyCollectionChanged(Tag added, params Tag[] removed)
        {
            if (CollectionChanged == null)
                return;
            if (added == null && removed == null)
                return;
            if (added == null && removed != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, removed));
            else if (added != null && removed == null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, added));
            else
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, added, removed[0]));
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        #endregion        
    

        public bool ContainsMember(string categoryName, string memberName)
        {
            try
            {
                var member = new Tag(categoryName, memberName);
                return members.Any(m => m.Equals(member));
            }
            catch { return false; }
        }
    }
}
