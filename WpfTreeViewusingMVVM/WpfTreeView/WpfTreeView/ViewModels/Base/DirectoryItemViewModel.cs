using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTreeView
{
    public class DirectoryItemViewModel:BaseViewModel
    {

        public string FullPath { get; set; }

        public DirectoryItemType Type { get; set; }

        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(FullPath); } }

        public string ImageName { get { return this.Type == DirectoryItemType.Drive ? "Drive_Icon" : (this.Type == DirectoryItemType.Folder ? "Folder_Icon" : "File_Icon"); } }

        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        public DirectoryItemViewModel(string fullPath,DirectoryItemType type)
        {
            FullPath = fullPath;
            Type = type;

            ClearChildren();
        }

        public bool IsExpanded
        {
            get
            {
                return this.Children?.Count(child => child != null) > 0;
            }
            set //will be called for both expand and collapse
            {
                if (value == true)
                    Expand();
                else
                    ClearChildren();
            }
        }

        private void Expand()
        {
            if (Type == DirectoryItemType.File) //we cannot expad a file
                return;

            var childs = DirectoryStructure.GetDirectoryContents(FullPath);
            this.Children = new ObservableCollection<DirectoryItemViewModel>(childs.Select(item => new DirectoryItemViewModel(item.FullPath, item.Type)));
        }

        private void ClearChildren()
        {
             Children = new ObservableCollection<DirectoryItemViewModel>();

            if (Type != DirectoryItemType.File)
                Children.Add(null);
            
        }
    }
}
