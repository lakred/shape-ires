namespace ShapeFactory;

public class Workflow
{
    private readonly string _basePath;

    public Workflow(string basePath) => _basePath = basePath;

    public void Infrastructure(IEnumerable<string> paths)
    {
        try
        {
            foreach (var path in paths) Directory.CreateDirectory(Path.Combine(_basePath, path));
        }catch (Exception ex) { Console.WriteLine("Error with creating directory"); }
    }

    public IEnumerable<string> Pending(string source) => Directory.GetFiles(Path.Combine(_basePath, source));

    public bool TryMove(string file, string destination)
    {
        try
        {
            File.Move(
                Path.Combine(_basePath, file),
                Path.Combine(_basePath, destination, Path.GetFileName(file)));
        }
        catch (Exception e)
        {
            return false;
            Console.WriteLine( "Error moving file");
        }finally { Console.WriteLine("END"); }

        return true;
    }
}

