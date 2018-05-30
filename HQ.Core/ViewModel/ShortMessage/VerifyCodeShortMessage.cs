using HQ.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LM.Core.Model.ShortMessage
{
    [ShortMessageFit(FitId = HQEnums.SmsSceneOptions.验证码)]
    public class VerifyCodeShortMessage : ShortMessageBase
    {
        [ShortMessageProperty(Desc = "验证码")]
        public string Verifycode { get; set; }

        public override HQEnums.SmsSceneOptions GetFitedScene()
        {
            return HQEnums.SmsSceneOptions.验证码;
        }
    }
}
