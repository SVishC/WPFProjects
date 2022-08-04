using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTreeView
{
    public class MainWindowViewModel:BaseViewModel
    {
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }
        public MainWindowViewModel()
        {
            var drives = DirectoryStructure.GetLogicalDrives();
            Items = new ObservableCollection<DirectoryItemViewModel>(drives.Select(drive => new DirectoryItemViewModel(drive.FullPath, drive.Type)));
        }
    }
}
