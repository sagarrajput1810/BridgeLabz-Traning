using System.IO;
using System.Text;

namespace SearchProblems
{
    public static class ReadBinaryAsCharactersProblem
    {
        public static string ReadAll(string filePath)
        {
            using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using var reader = new StreamReader(stream, Encoding.UTF8, leaveOpen: false);
            return reader.ReadToEnd();
        }
    }
}
