using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace exportToExcel
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        int pid = 0;
        Excel.Application m_objExcel = null;
        public Form1()
        {
            InitializeComponent();
            m_objExcel = new Excel.Application();

            GetWindowThreadProcessId(new IntPtr(m_objExcel.Hwnd), out pid);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "export.xlsx");
            string filename = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, Guid.NewGuid() + ".xlsx");
            System.IO.File.Copy(path, filename);
            query_table_getdata(filename);
            Debug.Write(sw.ElapsedMilliseconds);
            MessageBox.Show(sw.Elapsed.TotalSeconds.ToString());
        }

        public void query_table_getdata(string sourpath)
        {
            Excel.Workbooks m_objBooks = null;
            Excel.Workbook m_objBook = null;
            Excel.Sheets m_objSheets = null;
            Excel.Worksheet m_objSheet = null;
            Excel.Range m_objRange = null;

            m_objExcel.Visible = true;

            string lsConn = "OLEDB;" + @"Provider=SQLOLEDB.1;Data Source=line;uid=sa;Password=******;Initial Catalog=db_hz;Persist Security Info=False;";
            string lsSQL = "Select * from mf_pss";
            
            m_objBooks = m_objExcel.Workbooks;
            string path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, sourpath);
            m_objBook = m_objBooks.Open(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            m_objSheets = (Excel.Sheets)m_objBook.Worksheets;
            m_objSheet = (Excel.Worksheet)m_objSheets.get_Item(1);
            m_objRange = m_objSheet.get_Range("A2", Type.Missing);

            Excel.Range VSTORange = ((Excel.Range)m_objSheet.Cells[1, 1]);

            Excel.ListObject ListObject = m_objSheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcExternal,
              ((object)lsConn), false, Excel.XlYesNoGuess.xlYes, VSTORange);
            ListObject.QueryTable.CommandText = ((object)lsSQL);
            ListObject.QueryTable.RowNumbers = false;
            ListObject.QueryTable.FillAdjacentFormulas = false;
            ListObject.QueryTable.PreserveFormatting = true;
            ListObject.QueryTable.RefreshOnFileOpen = false;
            ListObject.QueryTable.BackgroundQuery = true;
            ListObject.QueryTable.SavePassword = false;
            ListObject.QueryTable.SaveData = true;
            ListObject.QueryTable.AdjustColumnWidth = true;
            ListObject.QueryTable.RefreshPeriod = 0;
            ListObject.QueryTable.PreserveColumnInfo = true;
            ListObject.QueryTable.Refresh(false);


            m_objBook.Connections[1].Delete();
            m_objBook.Save();
            // m_objBook.Close(false, Type.Missing, Type.Missing);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_objExcel.Quit();
            Process p = Process.GetProcessById(pid);
            p.Kill();
        }
    }
}