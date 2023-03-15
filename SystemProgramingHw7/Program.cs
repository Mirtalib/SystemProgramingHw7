string path = Path.GetPathRoot(Environment.SystemDirectory);

Console.WriteLine("-----Welcome-----");
Console.WriteLine($"Current directory: {path}");

while (true)
{
 
    Console.WriteLine("make your choice");
    Console.WriteLine("1.- List all directories");
    Console.WriteLine("2.- Copy file");
    Console.WriteLine("3.- Move file");
    Console.WriteLine("4.- Exit");
    Console.Write("> ");

    string input = Console.ReadLine();

    switch (input)
    {
        case "1":
            InfoList(path);
            break;
        case "2":
            Console.Write("Enter the file path you want to copy: ");
            string sourceFilePath = Console.ReadLine();
            Console.Write("Enter the destination path: ");
            string destinationPath = Console.ReadLine();
            CopyFile(sourceFilePath, destinationPath);
            break;
        case "3":
            Console.Write("Enter the file path you want to move: ");
            string moveSourceFilePath = Console.ReadLine();
            Console.Write("Enter the destination path: ");
            string moveDestinationPath = Console.ReadLine();
            MoveFile(moveSourceFilePath, moveDestinationPath);
            break;
        case "4":
            Console.WriteLine("Exiting");
            return;
        default:
            Console.WriteLine("Enter the number in the range 1-4");
            break;
    }

}



void InfoList(string path)
{
    try
    {
        Console.WriteLine($"All directories in {path}:");
        string[] directories = Directory.GetDirectories(path);
        foreach (string directory in directories)
        {
            Console.WriteLine(directory);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"{e.Message}");
    }
}

void CopyFile(string sourceFilePath, string destinationPath)
{
    try
    {
        string fileName = Path.GetFileName(sourceFilePath);
        string destinationFilePath = Path.Combine(destinationPath, fileName);
        File.Copy(sourceFilePath, destinationFilePath);
        Console.WriteLine($"Successfully  {fileName} to {destinationPath}");
    }
    catch (Exception e)
    {
        Console.WriteLine($"{e.Message}");
    }
}

void MoveFile(string sourceFilePath, string destinationPath)
{
    try
    {
        string sourceFileName = Path.GetFileName(sourceFilePath);
        string destinationFilePath = Path.Combine(destinationPath, sourceFileName);
        File.Move(sourceFilePath, destinationFilePath);
        Console.WriteLine($"Successfully  {sourceFileName} to {destinationPath}");
    }
    catch (Exception e)
    {
        Console.WriteLine($"{e.Message}");
    }
}