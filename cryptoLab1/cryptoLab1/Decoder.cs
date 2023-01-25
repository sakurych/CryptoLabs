namespace cryptoLab1
{
    internal class Decoder
    {
        public static string Decode()
        {
            string input = File.ReadAllText("encode.txt");
            string keyword = File.ReadAllText("key.txt");

            input = input.ToUpper();
            keyword = keyword.ToUpper();

            string result = "";

            int keyword_index = 0;

            foreach (char symbol in input)
            {
                int p = (Array.IndexOf(Program.characters, symbol) + Program.N -
                    Array.IndexOf(Program.characters, keyword[keyword_index])) % Program.N;

                result += Program.characters[p];

                keyword_index++;

                if ((keyword_index + 1) == keyword.Length)
                {
                    keyword_index = 0;
                }
            }

            return result;
        }
    }
}
