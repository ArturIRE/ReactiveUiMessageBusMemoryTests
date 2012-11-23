namespace RXMemoryTests
{
    using System;

    public static class Helper
    {
        public static void RunGarbageCollection()
        {
            // http://stackoverflow.com/a/4257387 + comments
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
