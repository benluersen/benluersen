using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceBlinks.Models.DAO
{
    public interface IStudentProfileBuilderDAO
    {
        ProfileViewModel GetProfile(int id, bool usingUserId = false);
        List<Tech> GetProfileTechList(int id);
        List<Portfolio> GetPortfolioList(int id);
        List<CareerExperience> GetCareerExperienceList(int id);
        List<Academics> GetAcademics(int id);
        Address GetAddress(int id);
        Portfolio GetPortfolio(int id);
        CareerExperience GetCareerExperience(int id);
        Academics GetAcademic(int id);

        List<string> GetDegreeList();
        List<int> GetCohortNumList();
        List<string> GetIndustryList();
        List<string> GetTechList();

        List<ProfileViewModel> GetProfileList(Security.BusinessLogic.Authorization auth);
        List<StudentPreviewModel> GetRosterPreviews(bool onlySearchable);
        List<StudentPreviewModel> GetSearchedProfileEmployer(Search search);
        List<StudentPreviewModel> GetSearchedProfileStudentStaff(Search search);

        int AddAddress(RegisterViewModel address);
        int AddCareer(CareerExperience exp);
        int AddPortfolio(Portfolio portfolio);
        int AddTech(Tech tech);
        int AddAcademics(Academics academics);
        int AddTechPortfolioLink(int techId, int portfolioId);
        int CreateProfile(int userId, int cohort = -1);

        void UpdatePortfolioProject(Portfolio portfolio);
        void UpdateAcademics(Academics academics);
        void UpdateProfile(ProfileViewModel vm);
        void UpdateCareerExperience(CareerExperience careerExperience);

        void DeletePortfolioProject(int portfolioId);
        void DeleteAcademicItem(int academicsId);
        void DeleteCareerExperience(int careerId);
        void DeleteUser(int userId);
    }
}
