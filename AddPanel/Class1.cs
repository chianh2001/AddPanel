using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using Newtonsoft.Json;
using System.IO;

namespace AddPanel
{
    public static class Class1
    {
        public static BitmapImage GetImage(string imageName, int width, int height)
        {
            string imagePath = $"pack://application:,,,/AddPanel;component/Resources/{imageName}";
            Uri uri = new Uri(imagePath);

            return CreateResizedImage(uri, width, height);
        }

        private static BitmapImage CreateResizedImage(Uri uri, int width, int height)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = uri;
            bitmap.DecodePixelWidth = width;
            bitmap.DecodePixelHeight = height;
            bitmap.EndInit();

            return bitmap;
            //public static string text_Tooltip = @"D:\Demo\Sample\AddPanel\AddPanel\";
        }
    }

    public class UserSelections
    {
        public string SelectedFamily { get; set; }
    }

    public class UserSettingsManager
    {
        private const string SaveFilePath = "user_selections.json";
        private static readonly string SaveDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AddPanel");

        public UserSelections LoadUserSelections()
        {
            if (!Directory.Exists(SaveDirectory))
            {
                Directory.CreateDirectory(SaveDirectory);
            }

            if (File.Exists(SaveFilePath))
            {
                var json = File.ReadAllText(SaveFilePath);
                return JsonConvert.DeserializeObject<UserSelections>(json);
            }
            return new UserSelections();
        }

        public void SaveUserSelections(UserSelections selections)
        {
            if (!Directory.Exists(SaveDirectory))
            {
                Directory.CreateDirectory(SaveDirectory);
            }
            var json = JsonConvert.SerializeObject(selections, Formatting.Indented);
            File.WriteAllText(SaveFilePath, json);
        }
    }
}
