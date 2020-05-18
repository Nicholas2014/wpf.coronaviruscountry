using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TextEditor
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Window win = Current.MainWindow;

            var bmp = new RenderTargetBitmap((int)win.Width, (int)win.Height, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(win);

            var errorPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ErrorReports");
            if (!Directory.Exists(errorPath))
            {
                Directory.CreateDirectory(errorPath);
            }

            BitmapEncoder bitmapEncoder = new PngBitmapEncoder();
            bitmapEncoder.Frames.Add(BitmapFrame.Create(bmp));

            var filePath = Path.Combine(errorPath, $"{DateTime.Now:yyyyMMddHHmmss}.png");

            using (var fs = File.Create(filePath))
            {
                bitmapEncoder.Save(fs);
            }
        }
    }
}
