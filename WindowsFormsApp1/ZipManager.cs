using System;
using System.Collections.Generic;
using System.IO.Compression;
using Archive = System.IO.Compression.ZipArchive;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class ZipManager
    {
        public static TreeView TreeView {private get; set;}
        public static bool IsFileExist(string file)
        {
            return System.IO.File.Exists(file) || System.IO.Directory.Exists(file);
        }
        public static void Open(string file)
        {
            TreeView.Nodes.Clear();
            Archive archive = ZipFile.OpenRead(file);
            TreeNode root = new TreeNode(file);
            foreach (var t in archive.Entries)
            {
                string[] path = t.FullName.Split('/');
                if (path[path.Length - 1].Length < 1 || path[path.Length - 1] == "")
                    continue;

                TreeNode node = root;
                for (int j = 0; j < path.Length; j++)
                {
                    TreeNode[] nodes = node.Nodes.Find(path[j], false);
                    if (nodes.Length == 0)
                    {
                        node = node.Nodes.Add(path[j], path[j]);
                    }
                    else
                    {
                        node = nodes[0];
                    }
                }
            }

            TreeView.Nodes.Add(root);
            archive.Dispose();
            GC.Collect();
         }

        public static void Zip(string file)
        {
            string[] name = file.Split(new char[] {'/'});
            ZipFile.CreateFromDirectory(file, name[name.Length-1] + ".zip");
        }

        public static void Unzip(string file, string outputFile)
        {
            var archive = ZipFile.OpenRead(file);
            foreach (var temp in archive.Entries)
            {
                if (File.Exists(Path.Combine(outputFile, temp.FullName)))
                {
                    File.Delete(Path.Combine(outputFile, temp.FullName));
                }
            }
        
            if (!file.EndsWith(".zip"))
            {
                file += ".zip";
            }
        
            ZipFile.ExtractToDirectory(file, outputFile);
        }
    }
}
