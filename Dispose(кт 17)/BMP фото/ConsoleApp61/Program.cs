using System;
using System.Drawing;
using System.IO;

namespace ConsoleApp61
{
    public class BitmapImage : IDisposable
    {
        private Bitmap bitmap;
        private bool disposed = false;

        public void Load(string path)
        {
            bitmap = new Bitmap(path);
        }

        public void Save(string filePath)
        {
            bitmap.Save(filePath);
        }

        public void Dispose()
        {
            if (!disposed)
            {
                bitmap?.Dispose();
                disposed = true;
            }
            GC.SuppressFinalize(this);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            using (BitmapImage file = new BitmapImage())
            {
                file.Load("photo.bmp");
                file.Save("photo1.bmp");
            }
        }
    }
}