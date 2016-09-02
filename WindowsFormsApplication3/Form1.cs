using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpreadsheetLight;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;

namespace WindowsFormsApplication3
{
    public partial class formMainWindow : Form
    {
        //We'll declare our character arrays when the program is loaded, as they're always the same.
        static char[] chararrayInvalidCharacters = {'\\', '/', ':', '*', '?', '"', '<', '>', '|'};
          static char[] chararrayValidCharacters = {'-', '-', ';', '-', '.', '\'', '(', ')', '-'};

        //As well as our vars that don't need to be changed during runtime.
        static int iMaxCharacters = 150; //The max no. of characters for a line of dialog.
        static string strFileExtensionToFind = ".xwm";
        static string strFileExtensionFinal = ".fuz";

        //We'll define lists as well, seeing as how we can free 'em up. No point in constantly creating them
        //if we only need 'em once. Also, they're easy to free up from memory.
        List<string> listFuzFilePaths = new List<string>();
        List<string> listFuzFileNames = new List<string>();
        List<string> listFuzDialogNames = new List<string>();
        List<string> listRenamePairs = new List<string>();

        public formMainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void CleanupOurLists()
        {
            listFuzFilePaths.Clear();
            listFuzFilePaths.TrimExcess();

            listRenamePairs.Clear();
            listRenamePairs.TrimExcess();

            listFuzDialogNames.Clear();
            listFuzDialogNames.TrimExcess();

            listFuzFileNames.Clear();
            listFuzFileNames.TrimExcess();
        }

        public SLDocument LoadTextFile(SLDocument sldocWorksheet, string strTextFileFullPath)
        {
            sldocWorksheet.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Delimited");

            SLTextImportOptions sltioWorksheetOptions = new SLTextImportOptions();
            sltioWorksheetOptions.Culture = new CultureInfo("en-US");
            SLWorksheetStatistics sldocstatsWorksheetStats = sldocWorksheet.GetWorksheetStatistics();
            int iLastColumnWithData = sldocstatsWorksheetStats.EndColumnIndex;

            for (int iCounter = 0; iCounter < iLastColumnWithData; iCounter++)
            {
                sltioWorksheetOptions.SetColumnFormat(iCounter, SLTextImportColumnFormatValues.Text);
            }

            sldocWorksheet.ImportText(strTextFileFullPath, "A1", sltioWorksheetOptions);

            return sldocWorksheet;
        }

        public SLDocument RemoveUnwantedColumns(SLDocument sldocWorksheet)
        {
            //In Fallout 4's dialogExport.txt, there are 37 columns.
            //We want column 6 "RESPONSE TEXT" and column 35 "FILENAME"
            //The rest can get fucked

            //DeleteColumn() removes the column at the given index, mind.
            //So if we do DeleteColumn(36, 2), it removes columns 36 and 37.

            sldocWorksheet.DeleteColumn(36, 2); 
            sldocWorksheet.DeleteColumn(7, 28);
            sldocWorksheet.DeleteColumn(1, 5);
            return sldocWorksheet;

        }

        public void threadingChangeUIEnableStateTo(bool bEnable)
        {

            Invoke(new MethodInvoker(delegate {


                if (bEnable)
                {
                    buttonOpenDialogExport.Enabled = true;
                    textboxDialogExportFullPath.Enabled = true;
                    buttonProcessDialogExport.Enabled = true;
                    tabcontrolMain.Enabled = true;
                    progressbarProcessing.Style = ProgressBarStyle.Continuous;

                    buttonGetRenamePairs.Enabled = true;
                    buttonProcessFuzFiles.Enabled = true;
                    buttonOpenVoiceFolder.Enabled = true;
                    textboxGetRenamePairs.Enabled = true;
                    textboxGetVoiceFolder.Enabled = true;
                    progressbarProcessingFuzFilenames.Style = ProgressBarStyle.Continuous;
                }

                else
                {
                    buttonOpenDialogExport.Enabled = false;
                    textboxDialogExportFullPath.Enabled = false;
                    buttonProcessDialogExport.Enabled = false;
                    tabcontrolMain.Enabled = false;
                    progressbarProcessing.Style = ProgressBarStyle.Marquee;

                    buttonGetRenamePairs.Enabled = false;
                    buttonProcessFuzFiles.Enabled = false;
                    buttonOpenVoiceFolder.Enabled = false;
                    textboxGetRenamePairs.Enabled = false;
                    textboxGetVoiceFolder.Enabled = false;
                    progressbarProcessingFuzFilenames.Style = ProgressBarStyle.Marquee;
                }


            }));

        }

        public string RemoveRedundantPeriods(string strCell)
        {

            if (strCell.EndsWith("   .fuz"))
            {
                strCell = strCell.Replace("   .fuz", ".fuz");
            }

            if (strCell.EndsWith("  .fuz"))
            {
                strCell = strCell.Replace("  .fuz", ".fuz");
            }

            if (strCell.EndsWith(" .fuz"))
            {
                strCell = strCell.Replace(" .fuz", ".fuz");
            }


            if (strCell.EndsWith("....fuz"))
            {
                strCell = strCell.Replace("....fuz", ".fuz");
            }

            if (strCell.EndsWith("...fuz"))
            {
                strCell = strCell.Replace("...fuz", ".fuz");
            }

            if (strCell.EndsWith("..fuz"))
            {
                strCell = strCell.Replace("..fuz", ".fuz");
            }

            return strCell;
        }

        public SLDocument SanitizeInvalidDialogCharacters(SLDocument sldocWorksheet)
        {
            SLWorksheetStatistics sldocWorksheetStats = sldocWorksheet.GetWorksheetStatistics();
            int iNumberOfCells = sldocWorksheetStats.EndRowIndex;
            int iEmptyStringCounter = 0000;

            for (int iCounter = 2; iCounter <= iNumberOfCells; iCounter++)
            {
                //Begin working on Column A - RESPONSE_TEXT
                string strCurrentCell = sldocWorksheet.GetCellValueAsString("A" + iCounter.ToString());
                string strModifiedCurrentCell;


                if (strCurrentCell.Length > iMaxCharacters)
                {
                    strModifiedCurrentCell = strCurrentCell.Remove(iMaxCharacters - 1);
                }

                else
                {
                    strModifiedCurrentCell = strCurrentCell;
                }


                if (strModifiedCurrentCell.Length > 0)
                {

                    for (int iCharArrayCounter = 0; iCharArrayCounter < chararrayInvalidCharacters.Length; iCharArrayCounter++)
                    {
                        strModifiedCurrentCell = strModifiedCurrentCell.Replace(chararrayInvalidCharacters[iCharArrayCounter], chararrayValidCharacters[iCharArrayCounter]);
                    }

                    strModifiedCurrentCell = "|" + strModifiedCurrentCell;
                    strModifiedCurrentCell = strModifiedCurrentCell + ".fuz";

                    strModifiedCurrentCell = RemoveRedundantPeriods(strModifiedCurrentCell);

                    sldocWorksheet.SetCellValue("A" + iCounter.ToString(), strModifiedCurrentCell);
                    //End
                }

                else
                {
                    iEmptyStringCounter++;

                    strModifiedCurrentCell = "|[Empty_" + iEmptyStringCounter.ToString("000000") + "].fuz";

                    sldocWorksheet.SetCellValue("A" + iCounter.ToString(), strModifiedCurrentCell);
                }


                if (strModifiedCurrentCell == "|.fuz")
                {
                    iEmptyStringCounter++;

                    strModifiedCurrentCell = "|[Empty_" + iEmptyStringCounter.ToString("000000") + "].fuz";

                    sldocWorksheet.SetCellValue("A" + iCounter.ToString(), strModifiedCurrentCell);
                }


                //Begin working on Column B - FILENAME
                //We just want to append the dialog file extension to the cell's string.
                strCurrentCell = sldocWorksheet.GetCellValueAsString("B" + iCounter.ToString());
                strModifiedCurrentCell = strCurrentCell + ".fuz";

                sldocWorksheet.SetCellValue("B" + iCounter.ToString(), strModifiedCurrentCell);
                //End
            }


            return sldocWorksheet;

        }

        public SLDocument SwapColumnAWithColumnB(SLDocument sldocWorksheet)
        {
            sldocWorksheet.InsertColumn(1, 1); //Insert an empty column at the start of the worksheet
            sldocWorksheet.CopyColumn(3, 1); //Copy C to the empty column. AcopyOfC
            sldocWorksheet.DeleteColumn(3, 1); //Delete original C column. So we have: AcopyOfC || BcopyOfA

            return sldocWorksheet;
        }

        public void SaveWorksheetToTextFile(SLDocument sldocWorksheet, string strPath)
        {

            using (TextWriter textwriterModifiedDialogExport = new StreamWriter(strPath + "dialogExport - Rename Pairs.txt"))
            {
                List<string> strListOfRenamePairs = new List<string>();
                SLWorksheetStatistics sldocWorksheetStats = sldocWorksheet.GetWorksheetStatistics();

                for (int iCounter = 2; iCounter < sldocWorksheetStats.EndRowIndex; iCounter++)
                {
                    string strResponseText = sldocWorksheet.GetCellValueAsString("B" + iCounter.ToString());
                    string strFileName = sldocWorksheet.GetCellValueAsString("A" + iCounter.ToString());
                    string strFinalStringLine = strFileName + strResponseText;
                    strListOfRenamePairs.Add(strFinalStringLine);
                }

                foreach (String strLineFromList in strListOfRenamePairs)
                {
                    textwriterModifiedDialogExport.WriteLine(strLineFromList);
                }

            }

        }

        private void buttonOpenDialogExport_Click(object sender, EventArgs e)
        {

            if (dialogOpenDialogExport.ShowDialog() == DialogResult.OK)
            {
                textboxDialogExportFullPath.Text = dialogOpenDialogExport.FileName;
                //MessageBox.Show(dialogOpenDialogExport.FileName);
            }

        }

        private void buttonProcessDialogExport_Click(object sender, EventArgs e)
        {
            string strDialogExportFullPath = textboxDialogExportFullPath.Text;
            string strDialogExportFolderPath = Path.GetDirectoryName(strDialogExportFullPath) + "\\";

            if (File.Exists(strDialogExportFullPath))
            {                
                SLDocument sldocDialogExportWorksheet = new SLDocument();

                //Since we don't want to have the progress bar freeze, we have to push our work to a separate thread
                //as the UI runs on the same thread as the code, by default.
                Task taskLoadTextFileIntoWorksheet = Task.Factory.StartNew(() =>
                    {
                        threadingChangeUIEnableStateTo(false);

                        sldocDialogExportWorksheet = LoadTextFile(sldocDialogExportWorksheet, strDialogExportFullPath);
                        sldocDialogExportWorksheet = RemoveUnwantedColumns(sldocDialogExportWorksheet);
                        sldocDialogExportWorksheet = SanitizeInvalidDialogCharacters(sldocDialogExportWorksheet);
                        sldocDialogExportWorksheet = SwapColumnAWithColumnB(sldocDialogExportWorksheet);

                        //sldocDialogExportWorksheet.SaveAs(strDialogExportFolderPath + "dialogExport - RenamePair.xlsx");
                        SaveWorksheetToTextFile(sldocDialogExportWorksheet, strDialogExportFolderPath);

                        threadingChangeUIEnableStateTo(true);
                    });
            }
            else
            {
                MessageBox.Show("Ain't no file 'ere!  " + strDialogExportFullPath);
            }

        }

        private void buttonGetRenamePairs_Click(object sender, EventArgs e)
        {

            if (dialogOpenRenamePairs.ShowDialog() == DialogResult.OK)
            {
                textboxGetRenamePairs.Text = dialogOpenRenamePairs.FileName;
            }

        }

        private void buttonOpenVoiceFolder_Click(object sender, EventArgs e)
        {
            if (dialogOpenVoiceFolder.ShowDialog() == DialogResult.OK)
            {
                textboxGetVoiceFolder.Text = dialogOpenVoiceFolder.SelectedPath;
            }

        }

        public void DirSearch(string sDir)
        {

            try
            {
                foreach (string strDir in Directory.GetDirectories(sDir))
                {
                    foreach (string strFile in Directory.GetFiles(strDir, "*.fuz"))
                    {
                        listFuzFilePaths.Add(strFile);
                        //MessageBox.Show(strFile);
                    }
                    DirSearch(strDir);
                }
            }

            catch (System.Exception excpt) //In case there's an invalid folder kicking about.
            {
                MessageBox.Show(excpt.Message);
            }
        }

        public void SplitRenamePairsIntoLists()
        {

            for (int iCounter = 0; iCounter < listRenamePairs.Count; iCounter++)
            {
                string strCurrentLine = listRenamePairs[iCounter];
                string[] strarrayFindAndReplace = strCurrentLine.Split('|');

                //MessageBox.Show(strarrayFindAndReplace[0]);
                //MessageBox.Show(strarrayFindAndReplace[1]);

                string strFindFileName = strarrayFindAndReplace[0];
                string strReplaceFileName = strarrayFindAndReplace[1];

                listFuzFileNames.Add(strFindFileName);
                listFuzDialogNames.Add(strReplaceFileName);
                //MessageBox.Show(strReplaceFileName);
            }

        }

        private void buttonProcessFuzFiles_Click(object sender, EventArgs e)
        {
            string strVoiceFolderPath = textboxGetVoiceFolder.Text;
            string strRenamePairListFullPath = textboxGetRenamePairs.Text;

            CleanupOurLists();


            if ( File.Exists(strRenamePairListFullPath)
                && Directory.Exists(strVoiceFolderPath) )
            {

                Task taskProcessFuzFiles = Task.Factory.StartNew(() =>
                    {
                        threadingChangeUIEnableStateTo(false);

                        listRenamePairs = File.ReadAllLines(strRenamePairListFullPath).ToList();
                        DirSearch(strVoiceFolderPath);
                        SplitRenamePairsIntoLists();

                        int iNumberOfFiles = listFuzFilePaths.Count;

                        //FuzFilePaths contains the full paths of the files that are in the subdirectories.
                        //FuzFileNames contains the file names that we want to check for
                        //FuzDialogNames contains the file names we want to replace them with.

                        HashSet<string> hashsetFuzFilePaths = new HashSet<string>(listFuzFilePaths);
                        HashSet<string> hashsetFuzFileNames = new HashSet<string>(listFuzFileNames);
                        HashSet<string> hashsetFuzDialogNames = new HashSet<string>(listFuzDialogNames);

                        //MessageBox.Show("Starting");

                        int iDuplicateNameSuffix = 0;

                        for (int iCounter = 0; iCounter < iNumberOfFiles; iCounter++)
                        {
                            //MessageBox.Show("Started!");

                            string strOriginalFileFullPath = listFuzFilePaths[iCounter];
                            //MessageBox.Show(strOriginalFileFullPath);

                            string strFileName = Path.GetFileName(strOriginalFileFullPath);
                            //MessageBox.Show(strFileName);

                            string strFilePath = Path.GetDirectoryName(strOriginalFileFullPath) + '\\';
                            //MessageBox.Show(strFilePath);

                            if ( hashsetFuzFilePaths.Contains(strOriginalFileFullPath) 
                                && hashsetFuzFileNames.Contains(strFileName) )
                            {
                                //MessageBox.Show("We're in!");

                                int iIndexOfFileName = listFuzFileNames.IndexOf(strFileName);
                                string strNewFileFullPath = strFilePath + listFuzDialogNames[iIndexOfFileName];

                                //MessageBox.Show(strNewFileFullPath);

                                if (File.Exists(strNewFileFullPath) == false)
                                {
                                    try
                                    {
                                        File.Move(strOriginalFileFullPath, strNewFileFullPath);
                                    }
                                    catch (System.Exception theException)
                                    {
                                        MessageBox.Show(strOriginalFileFullPath);
                                        MessageBox.Show(strNewFileFullPath);
                                        MessageBox.Show(theException.Message);
                                    }
                                }

                                else
                                {
                                    try
                                    {
                                        strNewFileFullPath = strNewFileFullPath.Replace(".fuz", "_" + iDuplicateNameSuffix.ToString("000000") + ".fuz");
                                        File.Move(strOriginalFileFullPath, strNewFileFullPath);
                                        iDuplicateNameSuffix++;
                                    }
                                    catch (System.Exception theException)
                                    {
                                        MessageBox.Show(strOriginalFileFullPath);
                                        MessageBox.Show(strNewFileFullPath);
                                        MessageBox.Show(theException.Message);
                                    }
                                }
                            }

                            /*for (int iLineCounter = 0; iLineCounter < iNumberOfFiles; iLineCounter++)
                            {
                                if ( hashsetFuzFileNames.Contains(strOriginalFileFullPath)
                                    && File.Exists(strFilePath + listFuzDialogNames[iLineCounter]) == false )
                                {
                                    try
                                    {
                                        File.Move(strOriginalFileFullPath, strFilePath + listFuzDialogNames[iLineCounter]);
                                        break;
                                    }
                                    catch(System.Exception theException)
                                    {
                                        MessageBox.Show(strOriginalFileFullPath);
                                        MessageBox.Show(strFilePath + listFuzDialogNames[iLineCounter]);
                                        MessageBox.Show(theException.Message);
                                    }
                                    
                                }

                            }*/

                        }


                        threadingChangeUIEnableStateTo(true);
                    });

            }

        }

    }
}
