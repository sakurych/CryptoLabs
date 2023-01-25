namespace cryptoLab1
{
    internal class Encoder
    {
        public static string Encode()
        {

            string input = File.ReadAllText("text.txt");
            string keyword = File.ReadAllText("key.txt");

            input = input.ToUpper();
            keyword = keyword.ToUpper();

            char[] message = input.ToCharArray();
            char[] key = keyword.ToCharArray();

            string result = "";

            int keyword_index = 0;

            foreach (char symbol in input)
            {
                int c = (Array.IndexOf(Program.characters, symbol) + Program.N +
                    Array.IndexOf(Program.characters, keyword[keyword_index])) % Program.N;
                if(c > Program.characters.Length)
                {
                    c = c- Program.characters.Length;
                }
                result += Program.characters[c];

                keyword_index++;

                if ((keyword_index + 1) == keyword.Length)
                {
                    keyword_index = 0;
                }
                c = 0;
            }
            return result;
        }
    }
}
