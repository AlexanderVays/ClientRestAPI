using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientRestAPI
{
    public partial class restAPIForm : Form
    {
        public restAPIForm()
        {
            InitializeComponent();
        }

        #region UI Event Handler

        private void btnRun_Click(object sender, EventArgs e)
        {
            RestAPI restAPI = new RestAPI();
            restAPI.endPoint = txtRestAPI.Text;
            debugOutput("Rest Client Created");
            string strResponse = restAPI.MakeRequest();
            debugOutput(strResponse);
        }

        private void debugOutput(string strDebugText) 
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                txtResponse.Text = txtResponse.Text + strDebugText + Environment.NewLine;
                txtResponse.SelectionStart = txtResponse.Text.Length;
                txtResponse.ScrollToCaret();  //Scrolls the contents of the control to the current caret position to ensure that the text insertion point, represented by the caret, is always visible on the screen after the ENTER key has been pressed.
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }
        #endregion 
    }
}
