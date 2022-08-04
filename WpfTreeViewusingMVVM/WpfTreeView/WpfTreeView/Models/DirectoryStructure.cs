using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTreeView 
{ 
    public static class DirectoryStructure
    {

        public static List<DirectoryItem> GetLogicalDrives()
        {
            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();
        }

        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {

            List<DirectoryItem> children = new List<DirectoryItem>();

            #region Folders

            try
            {
                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                    children.AddRange(dirs.Select(folder=>new DirectoryItem { FullPath=folder,Type=DirectoryItemType.Folder}));

            }
            catch
            {

            }

            #endregion

            #region Files
           

            try
            {
                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                    children.AddRange(fs.Select(file=>new DirectoryItem { FullPath=file,Type=DirectoryItemType.File}));

            }
            catch
            {

            }

            #endregion

            return children;

        }

    public static string GetFileFolderName(string path)
    {
        if (string.IsNullOrEmpty(path))
            return path;

        path = path.Trim().Replace('/', '\\');

        return path.Substring(path.LastIndexOf('\\') + 1);
    }
}
}
