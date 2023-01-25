using System.IO;
using System.Text;

namespace CryptoLab_2
{
    class Program
    {
        static void Main()
        {


            while (true)
            {
                Console.WriteLine("Выберите действие");
                Console.WriteLine("1 - Зашифровать файл");
                Console.WriteLine("2 - Расшифровать файл");
                Console.WriteLine("3 - Открыть файл encode.txt");
                Console.WriteLine("4 - Открыть файл decode.txt");
                Console.WriteLine("5 - Открыть файл key.txt");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            var ob = new RC6Base();
                            ob.fileData = ob.ReadByteArrayFromFile("text.txt");
                            ob.fileLength = (uint)ob.fileData.Length;
                            ob.KeyGen((UInt32)32);
                            ob.EncodeFile();                                                                        
                            ob.WriteByteArrayToFile(ob.resultData.ToArray(), "Encode.txt");
                            break;
                        }
                        case "2":
                        {
                            var mc = new RC6Base();
                            mc.fileData = mc.ReadByteArrayFromFile("Encode.txt");
                            mc.fileLength = (uint)mc.fileData.Length;
                            mc.KeyGen((UInt32)32); 
                            mc.DecodeFile();
                            mc.WriteByteArrayToFile(mc.resultData.ToArray(), "Decode.txt");
                            break;
                        }
                }
            }
        }
    }  
}