using ReginaCourseAppConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к файлу: ");
        string FileName = Console.ReadLine();
        using (StreamReader sr = new StreamReader(FileName))
        {
            string input = sr.ReadToEnd(); // read the string from file
            string[] rows = input.Split('\n');
            int[,] array = new int[rows.Length, rows[0].Split(',').Length];

            for (int i = 0; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');
                for (int j = 0; j < columns.Length; j++)
                {
                    int value;
                    if (int.TryParse(columns[j], out value))
                    {
                        array[i, j] = value;
                    }
                }   
            }
            HashSet<int> r = new HashSet<int>();
            List<int> p = Enumerable.Range(0, array.GetLength(0)).ToList();
            List<int> x = new List<int>();
            string fileName = "output.txt";
            File.Delete(fileName);
            Bronn.BronKerboschAlg(r,p,x,array);
        }
    }
}