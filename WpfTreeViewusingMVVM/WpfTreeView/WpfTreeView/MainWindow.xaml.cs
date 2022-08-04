using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WpfTreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.DataContext = new TestVM();
            this.DataContext = new MainWindowViewModel();
        }

        

        //private void Item_Expanded(object sender, RoutedEventArgs e)
        //{
         
        
        //    //For every tree item add its subfolders and files as Treeview item when its expanded
        //    var parentItem = (TreeViewItem)sender;

        //    //Here we can add the items either 1.always when expanded 2.only the first time and from next time dont change it(saves expanding time) //for demo we are following 2

        //    if (parentItem.Items.Count !=1|| parentItem.Items[0] != null) //if already eleements are present just return.
        //        return;


        //    //if the methosd is not exited in the before statement it means there is a null item added already to the parent.So remove it before adding real items
        //    parentItem.Items.Clear();

        //     var parentFullPath = parentItem.Tag.ToString();

        //    #region Folders
        //    var directories = new List<string>();

           
        //    try
        //    {
        //        var dirs = Directory.GetDirectories(parentFullPath);

        //        if (dirs.Length > 0)
        //            directories.AddRange(dirs);

        //    }
        //    catch
        //    {
                
        //    }

        //    directories.ForEach(directoryItemPath => 
        //    {
        //        var directoryItem = new TreeViewItem()
        //        {
        //            Header =GetFileFolderName(directoryItemPath),
        //            Tag = directoryItemPath
        //        };

        //        directoryItem.Items.Add(null);

        //        directoryItem.Expanded += Item_Expanded;

        //        parentItem.Items.Add(directoryItem);
        //    });

        //    #endregion

        //    #region Files
        //    var files = new List<string>();


        //    try
        //    {
        //        var fs = Directory.GetFiles(parentFullPath);

        //        if (fs.Length > 0)
        //            files.AddRange(fs);

        //    }
        //    catch
        //    {

        //    }

        //    files.ForEach(filePath =>
        //    {
        //        var directoryItem = new TreeViewItem()
        //        {
        //            Header = GetFileFolderName(filePath),
        //            Tag = filePath
        //        };

        //        //directoryItem.Items.Add(null); //these 2 are not needed for files because files cannot be expanded.

        //        //directoryItem.Expanded += Item_Expanded;

        //        parentItem.Items.Add(directoryItem);
        //    });

        //    #endregion

        //}

        //public static string GetFileFolderName(string path)
        //{
        //    if (string.IsNullOrEmpty(path))
        //        return path;

        //    path = path.Trim().Replace('/', '\\');

        //    return path.Substring(path.LastIndexOf('\\') + 1);
        //}
    }
}
