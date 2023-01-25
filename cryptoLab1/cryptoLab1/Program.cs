namespace cryptoLab1
{
    class Program
    {
        public static char[] characters = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                                'Э', 'Ю', 'Я'};
        public static int N = characters.Length;

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
                            string EncodeForFile = Encoder.Encode();
                            System.IO.File.WriteAllText("encode.txt", EncodeForFile);
                            break;
                        }
                    case "2":
                        {
                            string DecodeForFile = Decoder.Decode();
                            System.IO.File.WriteAllText("decode.txt", DecodeForFile);
                            break;
                        };
                    case "3":
                        {
                            string pathEncode = "encode.txt";
                            var proc = new System.Diagnostics.Process();
                            proc.StartInfo.FileName = pathEncode;
                            proc.StartInfo.UseShellExecute = true;
                            proc.Start();
                            break;
                        };
                    case "4": 
                        {
                            string pathDecode = "decode.txt";
                            var proc = new System.Diagnostics.Process();
                            proc.StartInfo.FileName = pathDecode;
                            proc.StartInfo.UseShellExecute = true;
                            proc.Start();
                            break; 
                        }
                    case "5":
                        {
                            string pathKey = "key.txt";
                            var proc = new System.Diagnostics.Process();
                            proc.StartInfo.FileName = pathKey;
                            proc.StartInfo.UseShellExecute = true;
                            proc.Start();
                            break;
                        }
                }                
            }
        }
    }
}