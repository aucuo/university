using System.IO;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string ReadFile(string path)
        {
            string str = "";

            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader(path))
                {
                    // Read the stream as a string, and write the string to the console.
                    str = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return str;
        }

        void WriteFile(string path, double value)
        {
            try
            {
                //Open the File
                StreamWriter sw = new StreamWriter(path, true, Encoding.ASCII);
                
                sw.Write(value);

                //close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        string sourcePath = "C:\\Users\\aucuo\\Desktop\\Learning\\AKTiOS\\OS\\laba1_anya\\1\\source.txt";
        string resultPath = "C:\\Users\\aucuo\\Desktop\\Learning\\AKTiOS\\OS\\laba1_anya\\1\\result.txt";

        string[] arr = ReadFile(sourcePath).Split(' ');

        double a = Convert.ToDouble(arr[0]), b = Convert.ToDouble(arr[1]);
        double s = 0;


        for (int i = 1; i <= b; i++)
        {
            s += Math.Sqrt(a) * i;
        }

        System.Console.WriteLine(s);

        System.IO.File.WriteAllText(resultPath, string.Empty); // Очистка файла перед записью
        WriteFile(resultPath, s);
    }
}