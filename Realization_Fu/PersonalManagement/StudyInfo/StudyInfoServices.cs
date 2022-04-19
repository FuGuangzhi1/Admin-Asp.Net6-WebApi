using Abstract_Fu.PersonalManagement.StudyInfo;
using EFCore_Fu.EFCoreFactroy;

namespace Realization_Fu.PersonalManagement.StudyInfo
{
    public class StudyInfoServices : BaseServices, IStudyInfoInterface
    {
        public StudyInfoServices(IEFCoreFactory iEFCoreFactory) : base(iEFCoreFactory)
        {
        }


    }
}
