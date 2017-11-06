using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CQL.WPF.Composer
{
    public class QueryPartSuggestion
    {
        private static Dictionary<Type, ImageSource> icons;
        private static ImageSource Convert(Bitmap bitmap)
        {
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }

        static QueryPartSuggestion()
        {
            icons = new Dictionary<Type, ImageSource>();
            icons[typeof(BooleanConstantViewModel)] = Convert(Properties.Resources.variable);
            icons[typeof(BooleanLiteralViewModel)] = Convert(Properties.Resources.token);
            icons[typeof(FieldComparsionViewModel)] = Convert(Properties.Resources.variable);
        }

        public QueryPartSuggestion(string name, string usage, QueryPartViewModel part)
        {
            Part = part;
            Image = icons[part.GetType()];
            Usage = usage;
            Name = name;
        }

        public ImageSource Image { get; private set; }
        public string Name { get; private set; }
        public string Usage { get; private set; }
        public QueryPartViewModel Part { get; private set; }
    }
}
