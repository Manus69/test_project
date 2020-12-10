using System.IO;

namespace AspNetCoreTodo
{
    public class Logger
    {
        public static void log(string file_name, string text)
        {
            //string name;
            System.IO.StreamWriter writer;

            if (!System.IO.File.Exists(file_name))
            {
                writer = new StreamWriter(System.IO.File.Create(file_name));
            }
            else
            {
                writer = System.IO.File.AppendText(file_name);
            }
            writer.WriteLine(text);

            writer.Flush();
            writer.Close();
            writer.Dispose();
        }
    }
}