using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsComparision
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnableObject(ref btnGetFiles, false);
        }
        public bool CompareFiles(string file1FullPath, string file2FullPath)
        {
            if (!File.Exists(file1FullPath) | !File.Exists(file2FullPath))
                // One or both of the files does not exist.
                return false;

            if (file1FullPath == file2FullPath)
                // fileFullPath1 and fileFullPath2 points to the same file...
                return true;

            try
            {
                string file1Hash = hashFile(file1FullPath);
                string file2Hash = hashFile(file2FullPath);

                if (file1Hash == file2Hash)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private string hashFile(string filepath)
        {
            using (System.IO.FileStream reader = new System.IO.FileStream(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                using (System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider())
                {
                    byte[] hash = md5.ComputeHash(reader);
                    return System.Text.Encoding.Unicode.GetString(hash);
                }
            }
        }

        private void btnDirectoryOne_Click(object sender, EventArgs e)
        {
            RetrieveDirectory(ref txtDirectoryOne);
            EnableObject(ref btnGetFiles, !(txtDirectoryOne.Text=="" & txtDirectoryTwo.Text ==""));
        }

        private void btnDirectoryTwo_Click(object sender, EventArgs e)
        {
            RetrieveDirectory(ref txtDirectoryTwo);
            EnableObject(ref btnGetFiles, !(txtDirectoryOne.Text == "" & txtDirectoryTwo.Text == ""));
        }

        private void EnableObject(ref Button btn, bool enabled)
        {
            btn.Enabled = enabled;
        }

        private void SetListBoxes(ref ListBox lb, string[] files)
        {
            int i;
            for (i = 0; i < files.Length; i++)
            {
                lb.Items.Add(files[i]);
            }
        }

        private void RetrieveDirectory(ref TextBox txt)
        {
            txt.Text = "";
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txt.Text = fbd.SelectedPath;
                }
            }
        }

        private void ClearFileList(ref ListBox lst)
        {
            lst.Items.Clear();
        }

        private void RetrieveFiles(ref string[] files, string fpath)
        {
            files = Directory.GetFiles(fpath, "*.*", SearchOption.AllDirectories);
        }

        private string[] RetrieveFiles(string fpath)
        {
            return Directory.GetFiles(fpath, "*.*", SearchOption.AllDirectories);
        }

        private void btnGetFiles_Click(object sender, EventArgs e)
        {
            SetListBoxes(ref lbDirectoryOne, RetrieveFiles(txtDirectoryOne.Text));
            SetListBoxes(ref lbDirectoryTwo, RetrieveFiles(txtDirectoryTwo.Text));
        }

        private void txtDirectoryOne_TextChanged(object sender, EventArgs e)
        {
            EnableObject(ref btnGetFiles, !(txtDirectoryOne.Text == "" & txtDirectoryTwo.Text == ""));
            if (txtDirectoryOne.Text == "") { ClearFileList(ref lbDirectoryOne); }
            if (txtDirectoryTwo.Text == "") { ClearFileList(ref lbDirectoryTwo); }
        }

        private void txtDirectoryTwo_TextChanged(object sender, EventArgs e)
        {
            EnableObject(ref btnGetFiles, !(txtDirectoryOne.Text == "" & txtDirectoryTwo.Text == ""));
            if(txtDirectoryOne.Text == ""){ ClearFileList(ref lbDirectoryOne); }
            if (txtDirectoryTwo.Text == "") { ClearFileList(ref lbDirectoryTwo); }
            

        }
    }
}
