namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            var progress = new StreamProgressInfo(new Music("John Secada", "Just another day", 10, 5));
            var progress2 = new StreamProgressInfo(new File("Knigga", 10, 5));
        }
    }
}
