using Common_Fu.ExeclHelper;
using Entities.DomainModels.Study;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Study
{
    public class StudyInfoView : StudyInfo
    {
        [Title(Title ="知识类型名称")]
        public string? StudyTypeName { get; set; } = null;
        [Title(Title = "知识类型描述")]
        public string? StudyTypeDescribe { get; set; } = null;
    }
}
