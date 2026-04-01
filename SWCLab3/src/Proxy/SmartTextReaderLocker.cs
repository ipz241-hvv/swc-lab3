using System.Text.RegularExpressions;

namespace SWCLab3.src.Proxy
{
    public class SmartTextReaderLocker : ITextReader
    {
        private readonly ITextReader _realReader;
        private readonly Regex _filter;

        public SmartTextReaderLocker(ITextReader reader, string pattern)
        {
            _realReader = reader;
            _filter = new Regex(pattern);
        }

        public char[][]? ReadFile(string filePath)
        {
            if (_filter.IsMatch(filePath))
            {
                Console.WriteLine("Access denied!");
                return null;
            }

            return _realReader.ReadFile(filePath);
        }
    }
}