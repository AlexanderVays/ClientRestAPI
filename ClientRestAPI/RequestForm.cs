using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
            txtResponse.Text = "";
            debugOutput("Rest Web Client Created");
            string strResponse = restAPI.MakeWebRequest();
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

        private void btnLocal_Click(object sender, EventArgs e)
        {
            RestAPI restAPI = new RestAPI();
            debugOutput("Rest Local Client Created");
            //string strResponse = restAPI.MakeLocalRequest();
            debugOutput("This feature not yet implemented.");
        }

        private void comboBoxMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBoxMethod.SelectedIndex;
            switch (selectedIndex)
            {
                case 0:
                    RestAPI.httpMethod = HttpVerb.GET;
                    break;
                case 1:
                    RestAPI.httpMethod = HttpVerb.POST;
                    break;
                case 2:
                    RestAPI.httpMethod = HttpVerb.PUT;
                    break;
                case 3:
                    RestAPI.httpMethod = HttpVerb.DELETE;
                    break;
                default:
                    break;
            }
        }

        private void comboBoxAccept_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex2 = comboBoxAccept.SelectedIndex;
            switch (selectedIndex2)
            {
                case 0:
                    RestAPI.responseFormat = ResponseFormat.HTML;
                    break;
                case 1:
                    RestAPI.responseFormat = ResponseFormat.JSON;
                    break;
                case 2:
                    RestAPI.responseFormat = ResponseFormat.XML;
                    break;
                default:
                    break;
            }
        }
    }
}
