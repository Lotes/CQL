using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MainCore.Tags
{
    public class Tag: IComparable<Tag>, INotifyPropertyChanged
    {
        /// <summary>
        /// Category and member name must be valid identifiers! Umlaute are also permitted.
        /// </summary>
        public static readonly Regex PATTERN_IDENTIFIER = new Regex(@"^[a-zA-Z_][a-zA-Z_0-9]*$");

        /// <summary>
        /// This is the delimiter between category name and member name.
        /// </summary>
        public const char DELIMITER = '/';

        /// <summary>
        /// Splits a string into category and member part.
        /// Throws FormatException if syntax was violated.
        /// a -> c:A m:null
        /// a/ -> c:A m:null
        /// a/b -> c:A m:B
        /// /b -> c:null m:B
        ///   -> c:null m:null
        /// </summary>
        /// <param name="str">do not pass NULL (ArgumentNullException)</param>
        /// <param name="categoryName">can be null</param>
        /// <param name="memberName">can be null</param>
        public static void Parse(string str, out string categoryName, out string memberName)
        {
            if(str == null)
                throw new ArgumentNullException("str");
            var parts = str.Split(DELIMITER);
            switch (parts.Length)
            { 
                case 0:
                    categoryName = null;
                    memberName = null;
                    break;
                case 1:
                    if (string.IsNullOrEmpty(parts[0]))
                        categoryName = null;
                    else if (!PATTERN_IDENTIFIER.IsMatch(parts[0]))
                        throw new FormatException("Category name is not a valid identifier!");
                    else
                        categoryName = parts[0].ToUpper();
                    memberName = null;
                    break;
                case 2:
                    if (string.IsNullOrEmpty(parts[0]))
                        categoryName = null;
                    else if (!PATTERN_IDENTIFIER.IsMatch(parts[0]))
                        throw new FormatException("Category name is not a valid identifier!");
                    else
                        categoryName = parts[0].ToUpper();

                    if (string.IsNullOrEmpty(parts[1]))
                        memberName = null;
                    else if (!PATTERN_IDENTIFIER.IsMatch(parts[1]))
                        throw new FormatException("Member name is not a valid identifier!");
                    else
                        memberName = parts[1].ToUpper();
                    break;
                default:
                    throw new FormatException("Syntax violated: Do only use two identifiers separated by a slash ("+DELIMITER+").");
            }
        }

        /// <summary>
        /// Attempt to use Parse() and return whether it was a success or not.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="categoryName"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public static bool TryParse(string str, out string categoryName, out string memberName)
        {
            try
            {
                Parse(str, out categoryName, out memberName);
            }
            catch (Exception)
            {
                categoryName = null;
                memberName = null;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Shortcut function for creating a '[categoryName]/UNCATEGORIZED' filter
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public static Tag UncategorizedFilter(string categoryName) { return new Tag(categoryName, TagFilters.Uncategorized, Colors.White); }

        /// <summary>
        /// Shortcut function for creating a '[categoryName]/ANY' filter
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public static Tag AnyFilter(string categoryName) { return new Tag(categoryName, TagFilters.Any, Colors.White); }

        /// <summary>
        /// Shortcut function for creating a '[categoryName]/MULTIPLE' filter
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public static Tag MultipleFilter(string categoryName) { return new Tag(categoryName, TagFilters.Multiple, Colors.White); }

        private Color color;

        /// <summary>
        /// Creates a category member. Uppercases its name parts!
        /// </summary>
        /// <param name="categoryName">optional, can be null (will be then converted to empty string)</param>
        /// <param name="memberName">must not be empty or null</param>
        /// <param name="color">system-wide color for this member</param>
        public Tag(string categoryName, string memberName) : this(categoryName, memberName, Colors.White)
        {
        }

        /// <summary>
        /// Creates a category member. Uppercases its name parts!
        /// </summary>
        /// <param name="categoryName">optional, can be null</param>
        /// <param name="memberName">must not be empty or null</param>
        /// <param name="color">system-wide color for this member</param>
        public Tag(string categoryName, string memberName, Color color)
        {
            if (string.IsNullOrEmpty(memberName))
                throw new ArgumentException("Member name must not be empty or null!", "memberName");
            if (!PATTERN_IDENTIFIER.IsMatch(memberName))
                throw new ArgumentException("Member name must be a valid identifier!", "memberName");
            if (categoryName == null)
                categoryName = "";
            if (!string.IsNullOrEmpty(categoryName) && !PATTERN_IDENTIFIER.IsMatch(categoryName))
                throw new ArgumentException("Category name must be a valid identifier!", "memberName");
            this.CategoryName = categoryName.ToUpper();
            this.MemberName = memberName.ToUpper();
            this.color = color;
        }

        /// <summary>
        /// returns the category
        /// </summary>
        public string CategoryName
        {
            get; private set;
        }
        
        /// <summary>
        /// returns the name
        /// </summary>
        public string MemberName
        {
            get; private set;
        }

        /// <summary>
        /// returns the color
        /// </summary>
        public Color Color 
        { 
            get { return color; }
            set
            {
                if (color.Equals(value))
                    return;
                color = value;
                NotifyPropertyChanged("Color");
            }
        }        

        /// <summary>
        /// Returns true, if the category member is a filter (MemberName == NONE, MULTIPLE, ...)
        /// </summary>
        public bool IsFilter
        {
            get { return TagFilters.Names.Contains(MemberName); }
        }

        #region interface implementations
        public override bool Equals(object obj)
        {
            var other = obj as Tag;
            if(other == null)
                return base.Equals(obj);
            return this.CategoryName.Equals(other.CategoryName) && this.MemberName.Equals(other.MemberName);
        }

        public override int GetHashCode()
        {
            return 7 + CategoryName.GetHashCode() + 13 * MemberName.GetHashCode();
        }

        public int CompareTo(Tag other)
        {
            var cmp = this.CategoryName.CompareTo(other.CategoryName);
            if (cmp != 0)
                return cmp;
            return this.MemberName.CompareTo(other.MemberName);
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(CategoryName))
                return DELIMITER + MemberName;
            return CategoryName + DELIMITER + MemberName;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Triggers an event that a property has changed.
        /// </summary>
        /// <param name="propertyName"></param>
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
