using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using System.Xaml;

namespace TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IntegrationUtilities.CopyProjectFolderStructure();
        }
    }


    public static class IntegrationUtilities
    {

        public static void CopyProjectFolderStructure()
        {
            // Get all project files from dir
            List<string> projectPaths = new List<string>();

            // Project directory
            var fileDir = System.AppDomain.CurrentDomain.BaseDirectory;

            var repoRoot = GetRepoRootDir(fileDir);
            var projects = GetProjectData(repoRoot);
        }

        public static string GetProjectData(string repoDirectory)
        {
            var projFiles = Directory.GetFiles(repoDirectory, "*.*", SearchOption.AllDirectories)
            .Where(s => "csproj" == (System.IO.Path.GetExtension(s)));
            foreach(var proj in projFiles)
            {
                // Create a new project data object
            }
        }

        public static string GetRepoRootDir(string directory)
        {
            var returnStr = string.Empty;
            // Incrementally move up, check if the parent node contains the .git folder

            var files = Directory.GetDirectories(directory).Where(s => s.Contains(".git")).ToList();
            if(files == null | files.Count == 0)
            {
                string newDir;
                try
                {
                    var dirPieces = directory.Split('/').ToList();
                    dirPieces.Reverse();
                    dirPieces.RemoveAt(0);
                    dirPieces.Reverse();
                    newDir = string.Join("/", dirPieces);
                }
                catch(Exception e) { return string.Empty; }
                if(newDir == null | newDir == string.Empty) { return string.Empty; }
                else { GetRepoRootDir(newDir); }
            }
            else
            {
                //This is the topmost directory in the git repo.
                return directory;
            }

            return returnStr;
        }

    }

    public class COREProject
    {
        private string _projectName = "Unknown";
        private List<string> _projectContents = new List<string>();

        public COREProject(string projectPath)
        {
            // Parse csproj xml file for related files
            XML

        }
    }
}
