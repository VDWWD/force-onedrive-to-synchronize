using System;
using System.IO;

namespace VDWWD_SyncForcer
{
    class Program
    {
        static void Main(string[] args)
        {
            //check if there are arguments specified
            if (args.Length == 0)
            {
                Console.WriteLine("Please specify the OneDrive folder.");
                return;
            }

            //get the folder from the arguments collection
            string folder = args[0].TrimEnd('\\');

            //or hardcode a path to your onedrive folder
            //string folder = @"c:\path_to_onedrive";

            //check if the folder exits
            if (!Directory.Exists(folder))
            {
                Console.WriteLine($"The OneDrive folder \"{folder}\" was not found.");
                return;
            }

            //add a filename
            string file = folder + @"\ForceSync.txt";

            try
            {
                //create a text file
                using (var writer = new StreamWriter(file, true))
                {
                    writer.WriteLine("VDWWD");
                }

                //then delete it again
                File.Delete(file);

                Console.WriteLine("OneDrive Sync triggered.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
