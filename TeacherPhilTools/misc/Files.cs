using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // We need this if we are going to use files!
using System.Windows.Documents;

namespace TeacherPhilTools
{
    public class Files
    {
        public string OPENFILEDIALOGERROR = "No file has been selected";
        public Files()
        {
            // blank constructor
        }

        /*
         * Function: OpenFileBrowser()
         * Argument(s): [optional] Filter settings
         * Author: Phillip Donald
         * Contact: donaldp@milsen.vic.edu.au
         * Last Editied: 27/11/2023
         * Purpose: Use open dialog to return a path
         */

        public string OpenFileBrowser(string strFilter = "Text files (*.txt)|*.txt|All files (*.*)|*.*")
        {
            // https://wpf-tutorial.com/dialogs/the-openfiledialog/
            string strRetVal = "error"; // if this value is returned, an error has occured!
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = strFilter;
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
            {
                // if it is true we will return the file name
                strRetVal = openFileDialog.FileName;
            }
            else
            {
                strRetVal = OPENFILEDIALOGERROR;
            }

            return strRetVal;
        }

        /*
			Function: SaveRTFLogFileBrowser()
			Argument(s): Path to file as string
			Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 31/05/2021
			Purpose: Use save dialog to figure out path for saving a Rich Text Format log
			*/
        public string SaveRTFLogFileBrowser(string strFileName)
        {
            // https://www.wpf-tutorial.com/dialogs/the-savefiledialog/

            string strRetVal = "error"; // if this value is returned, an error has occured!
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // configure the Save File Dialog
            saveFileDialog.Filter = "RTF file (*.rtf)|*.rtf";
            saveFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            saveFileDialog.AddExtension = true;
            saveFileDialog.Title = "Save Log As";
            saveFileDialog.FileName = strFileName;

            if (saveFileDialog.ShowDialog() == true)
            {
                strRetVal = saveFileDialog.FileName;
            }

            return strRetVal;
        }

        /*
			Function: SaveRTFLog()
			Argument(s): txtContent is all of the text in the RichTextBox, strFile is the file path
			Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 31/05/2021
			Purpose: Saves the log
			*/
        //public void SaveRTFLog(TextRange txtContent, string strFile)
        //{
        //    // http://umaranis.com/2010/11/29/save-and-load-richtextbox-content-in-wpf/
        //    FileStream fiStream = new FileStream(strFile, FileMode.Create);
        //    txtContent.Save(fiStream, System.Windows.Data);
        //    fiStream.Close();
        //}

        //public void AppendToTextFile(string strFile, string strAppendText)
        //{
        //    try
        //    {
        //        if (!File.Exists(strFile))
        //        {
        //            // If the file doesn't exist, we'll make a blank one
        //            using (StreamWriter fileStr = File.CreateText(strFile))
        //            {
        //                // Writing a blank text file
        //                string strLineOne = "";
        //                fileStr.Write(strLineOne);
        //            }
        //        }

        //        // This block of code will append (add to) the file
        //        using (StreamWriter swFile = File.AppendText(strFile))
        //        {
        //            swFile.WriteLine(strAppendText);
        //        }
        //    }
        //    catch (Exception excpFile)
        //    {
        //        Console.WriteLine(excpFile.ToString());
        //    }
        //}
    }
}
