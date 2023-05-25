using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace lr26
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string fn = @"g:\123.dotx";
        Word.Application word = new Word.Application();
        Word.Document doc = new Word.Document();

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            doc.Close();
            word.Quit();
            doc = null;
            word = null;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Object missingObj = System.Reflection.Missing.Value;
            Object trueObj = true;
            Object falseObj = false;
            Object templatePathObj = fn;
            doc = word.Documents.Add(ref templatePathObj, ref missingObj, ref missingObj, ref missingObj);
            doc.Activate();
            foreach (Word.FormField f in doc.FormFields)
            {
                switch (f.Name)
                {
                    case "sender":
                        f.Range.Text = sender_txt.Text;
                        break;
                    case "recipient":
                        f.Range.Text = recipient_txt.Text;
                        break;
                    case "postal_code":
                        f.Range.Text = postal_code_txt.Text;
                        break;
                    case "name":
                        f.Range.Text = name_txt.Text;
                        break;
                    case "date":
                        f.Range.Text = date_txt.Text;
                        break;
                    default:
                        break;
                }
            }
            word.Visible = true;
        }
    }
}
