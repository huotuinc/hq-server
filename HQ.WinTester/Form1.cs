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
            //HotPageData<List<PromotionIdItemEntity>> data = DdkApiWrapper.GetPromotionIdList(clientId, clientSecret, 1, 10);
            //MessageBox.Show(JsonConvert.SerializeObject(data));

            //var result = DdkApi.GetGoodsList(clientId, clientSecret, new GoodsSearchConditionEntity() { sort_type = GoodsSortTypeOptions.综合排序, with_coupon = true,keyword= "瘦身产品" });
            //MessageBox.Show(JsonConvert.SerializeObject(result));

            var result = DdkApi.GetGoodsDetail(clientId, clientSecret, 1561154663);
            MessageBox.Show(JsonConvert.SerializeObject(result));
        }
    }
}
