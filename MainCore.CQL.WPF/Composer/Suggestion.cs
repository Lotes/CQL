using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MainCore.CQL.WPF.Composer
{
    public class Suggestion
    {
        private static Dictionary<QueryPartType, ImageSource> icons;
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

        static Suggestion()
        {
            icons = new Dictionary<QueryPartType, ImageSource>();
            icons[QueryPartType.BooleanConstant] = Convert(Properties.Resources.variable);
            icons[QueryPartType.BooleanLiteral] = Convert(Properties.Resources.token);
            icons[QueryPartType.FieldComparsion] = Convert(Properties.Resources.variable);
        }

        public Suggestion(QueryPartType partType, string name, string usage, object value)
        {
            PartType = partType;
            Name = name;
            Value = value;
            Image = icons[partType];
            Usage = usage;
        }

        public QueryPartType PartType { get; private set; }
        public ImageSource Image { get; private set; }
        public string Name { get; private set; }
        public string Usage { get; private set; }
        public object Value { get; private set; }
    }
}
