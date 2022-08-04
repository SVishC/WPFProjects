using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTreeView
{
    public class DirectoryItem
    {

        public string FullPath { get; set; }

        public DirectoryItemType Type { get; set; }

        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(FullPath); } }
    }
}
