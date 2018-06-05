using HQ.Common;
using HQ.Core.BLL;
using HQ.Core.Enum;
using HQ.Core.MallProvider;
using HQ.Core.MallProvider.Model;
using HQ.Model;
using HQ.PddOpen.Core;
using HQ.PddOpen.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HQ.WinTester
{
    public partial class Form1 : Form
    {
        string clientId = "fabb0d8a6c92489f90aa7d97b646d423";
        string clientSecret = "522d048c337f97b2cf78289ca49326aa23ccf847";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //HotPageData<List<PromotionIdItemEntity>> data = DdkApiWrapper.GetPromotionIdList(clientId, clientSecret, 1, 10);
            //MessageBox.Show(JsonConvert.SerializeObject(data));

            //var result = DdkApi.GetGoodsList(clientId, clientSecret, new GoodsSearchConditionEntity() { sort_type = GoodsSortTypeOptions.综合排序, with_coupon = true,keyword= "瘦身产品" });
            //MessageBox.Show(JsonConvert.SerializeObject(result));

            //var result = DdkApi.GetGoodsDetail(clientId, clientSecret, 1561154663);
            //MessageBox.Show(JsonConvert.SerializeObject(result));

            //var result = DdkApi.GetGoodsTagCatList(clientId, clientSecret);
            //MessageBox.Show(JsonConvert.SerializeObject(result));



            //InitPttGoodsCatIcon();

        }

        private void InitPttGoodsCats()
        {
            List<GoodsCatsModel> catList = GoodsCatsBLL.Instance.GetCats(clientId, clientSecret);
            foreach (GoodsCatsModel cat in catList)
            {
                GoodsCatsBLL.Instance.Add(cat);
            }
            MessageBox.Show("OK!!");
        }

        private void InitPttGoodsCatIcon()
        {
            string catjson = File.ReadAllText(@"D:\WorkFolder\Hot.Haoquan\HQ.WinTester\ddkcats.txt");
            string iconDir = @"D:\WorkFolder\Haoquan_ResSite\resource\images\goodscat\0\";
            Dictionary<int, string> dicIcon = new Dictionary<int, string>();
            string regex = "\"optID\":([^,]+),\"optType\":2,\"optName\":\"[^\"]+\",\"priority\":[^,]+,\"imgUrl\":\"([^\"]+)\\?";
            MatchCollection matchs = Regex.Matches(catjson, regex);
            //foreach (Match match in matchs)
            //{
            //    int optId = Convert.ToInt32(match.Groups[1].Value);
            //    string remotePath = "http:" + match.Groups[2].Value;
            //    string fileName = optId.ToString();
            //    this.SaveImageFromWeb(remotePath, iconDir, fileName);
            //}

            string[] files = Directory.GetFiles(iconDir);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string path = string.Format("http://res.chinaswt.cn/resource/images/goodscat/0/{0}", name);
                string optIdStr = Path.GetFileNameWithoutExtension(file);
                int optId;
                if (int.TryParse(optIdStr, out optId))
                {
                    GoodsCatsModel catInfo = GoodsCatsBLL.Instance.GetModel(optId, (int)HQEnums.PlatformTypeOptions.拼多多);
                    if (catInfo != null)
                    {
                        catInfo.Icon = path;
                        GoodsCatsBLL.Instance.Update(catInfo);
                    }
                }
            }

            MessageBox.Show("OK");
        }

        /// <summary>
        /// 保存web图片到本地
        /// </summary>
        /// <param name="imgUrl">web图片路径</param>
        /// <param name="path">保存路径</param>
        /// <param name="fileName">保存文件名</param>
        /// <returns></returns>
        public string SaveImageFromWeb(string imgUrl, string path, string fileName)
        {
            if (path.Equals(""))
                throw new Exception("未指定保存文件的路径");
            string imgName = imgUrl.ToString().Substring(imgUrl.ToString().LastIndexOf("/") + 1);
            string defaultType = ".jpg";
            string[] imgTypes = new string[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            string imgType = imgUrl.ToString().Substring(imgUrl.ToString().LastIndexOf("."));
            string imgPath = "";
            foreach (string it in imgTypes)
            {
                if (imgType.ToLower().Equals(it))
                    break;
                if (it.Equals(".bmp"))
                    imgType = defaultType;
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(imgUrl);
            request.UserAgent = "Mozilla/6.0 (MSIE 6.0; Windows NT 5.1; Natas.Robot)";
            request.Timeout = 3000;

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();

            if (response.ContentType.ToLower().StartsWith("image/"))
            {
                byte[] arrayByte = new byte[1024];
                int imgLong = (int)response.ContentLength;
                int l = 0;

                if (fileName == "")
                    fileName = imgName;

                FileStream fso = new FileStream(path + fileName + imgType, FileMode.Create);
                while (l < imgLong)
                {
                    int i = stream.Read(arrayByte, 0, 1024);
                    fso.Write(arrayByte, 0, i);
                    l += i;
                }

                fso.Close();
                stream.Close();
                response.Close();
                imgPath = fileName + imgType;
                return Path.Combine(path, imgPath);
            }
            else
            {
                return "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HotPageData<List<HotGoodsModel>> pageData = GoodsProviderFactory.Current.GetGoodsList(new HotGoodsSearchCondition()
            {
                SortField = HotGoodsSortFieldOptions.默认,
                SortType = HotGoodsSortTypeOptions.ASC
            }, out string errMsg);

            MessageBox.Show(JsonConvert.SerializeObject(pageData));


            //HotGoodsModel goodsInfo = GoodsProviderFactory.Current.GetGoodsDetail(1523581237, out string errDetailMsg);
            //MessageBox.Show(JsonConvert.SerializeObject(goodsInfo));

        }
    }
}
