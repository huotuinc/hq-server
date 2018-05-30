using HQ.Common;
using HQ.PddOpen.Core;
using HQ.PddOpen.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HQ.WinTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string clientId = "fabb0d8a6c92489f90aa7d97b646d423";
            string clientSecret = "522d048c337f97b2cf78289ca49326aa23ccf847";
            HotPageData<List<PromotionIdItemEntity>> data = DdkApiWrapper.GetPromotionIdList(clientId, clientSecret, 1, 10);
            MessageBox.Show(JsonConvert.SerializeObject(data));
        }
    }
}
