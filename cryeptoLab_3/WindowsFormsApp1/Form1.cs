using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static byte[] img;
        public static byte[] buffer1;
        public static byte[] AllByte;
        public static byte[] key;
        public Form1()
        {
            InitializeComponent();
            Bitmap btmp = (Bitmap)Image.FromFile("100.bmp");
            pictureBox1.Image = btmp;
        }

        private void Encode_Click(object sender, EventArgs e)
        {
            Bitmap imge = new Bitmap("100.bmp");
            byte[] img =  ConvertBitMapToByte(imge);
            pictureBox1.Image = ConvertByteToBitMap(img);
            using (FileStream fstream = File.OpenRead("text.txt"))
            {
                // выделяем массив для считывания данных из файла
                key = new byte[fstream.Length];
                // считываем данные
                fstream.Read(key, 0, key.Length);
            }
            byte[] data = crypt.Encrypt(img, key);
            Bitmap b = new Bitmap(ConvertByteToBitMap(data));
            b.Save("Encode.bmp", ImageFormat.Bmp);
            pictureBox1.Image = b;
        }

        private byte[] ConvertBitMapToByte(Bitmap img)
        {
            byte[] Result = null;
            BitmapData bData = img.LockBits(new Rectangle(new Point(), img.Size), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            int ByteCount = bData.Stride * img.Height;
            Result = new byte[ByteCount];
            Marshal.Copy(bData.Scan0, Result, 0, ByteCount);
            img.UnlockBits(bData);
            return Result;
        }

        private Bitmap ConvertByteToBitMap(byte[] Ishod)
        {
            Bitmap img = new Bitmap(1152, 648);
            BitmapData bData = img.LockBits(new Rectangle(new Point(), img.Size), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            Marshal.Copy(Ishod, 0, bData.Scan0, Ishod.Length);
            img.UnlockBits(bData);
            return img;
        }

        private void Decode_Click(object sender, EventArgs e)
        {
            Bitmap imge = (Bitmap)Image.FromFile("Encode.bmp");
            ImageConverter imgCon = new ImageConverter();
            img = ConvertBitMapToByte(imge);
            using (FileStream fstream = File.OpenRead("text.txt"))
            {
                // выделяем массив для считывания данных из файла
                key = new byte[fstream.Length];
                // считываем данные
                fstream.Read(key, 0, key.Length);
            }
            byte[] data = crypt.Encrypt(img, key);
            Bitmap b = new Bitmap(ConvertByteToBitMap(data));
            b.Save("Decode.bmp", ImageFormat.Bmp);
            pictureBox1.Image = b;
        }
    }

    internal class crypt
    {
        public static byte[] Encrypt(byte[] data, byte[] key)
        {
            int a, i, j, k, tmp;
            int[] codeKey, box;
            byte[] cipher;

            codeKey = new int[256];
            box = new int[256];
            cipher = new byte[data.Length];

            for (i = 0; i < 256; i++)
            {
                codeKey[i] = key[i % key.Length];
                box[i] = i;
            }
            for (j = i = 0; i < 256; i++)
            {
                j = (j + box[i] + codeKey[i]) % 256;
                tmp = box[i];
                box[i] = box[j];
                box[j] = tmp;
            }
            for (a = j = i = 0; i < data.Length; i++)
            {
                a++;
                a %= 256;
                j += box[a];
                j %= 256;
                tmp = box[a];
                box[a] = box[j];
                box[j] = tmp;
                k = box[((box[a] + box[j]) % 256)];
                cipher[i] = (byte)(data[i] ^ k);
            }
            return cipher;
        }


        public static byte[] Decrypt(byte[] data, byte[] key)
        {
            return Encrypt(data, key);
        }
    }
}
