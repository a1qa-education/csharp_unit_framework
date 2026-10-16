namespace ExampleProject.Framework.Utils
{
    public static class WaitUtils
    {
        public static void Sleep(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }
    }
}