using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AP.Service.ViewModels
{
    class AuthorizationViewModel
    {
    }

    #region Group
    public class GroupIndexViewModel
    {
        public IEnumerable<GroupModel> GroupList { get; set; }

        public int PageIndex { get; set; }
        public int DataCount { get; set; }
        public int DataIndex { get; set; }
    }

    public class GroupModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public string Privilege { get; set; }
        public int Level { get; set; }

        public string APNameList { get; set; }
    }

    public class GroupCreateViewModel
    {
        public int GroupId { get; set; }

        [Required]
        [Display(Name = "群組名稱")]
        public string GroupName { get; set; }

        [Display(Name = "描述")]
        public string Description { get; set; }

        public string Privilege { get; set; }

        public int Level { get; set; }

        public SelectList LevelDDL { get; set; }

        public string[] SelectedAP { get; set; }

        public List<SelectListItem> APCheckBoxList { get; set; }
    }

    public class GroupEditViewModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public string Privilege { get; set; }
        public int Level { get; set; }

        public SelectList LevelDDL { get; set; }

        public string[] SelectedAP { get; set; }

        public List<SelectListItem> APCheckBoxList { get; set; }
    }

    public class AuthModel
    {
        public string APName { get; set; }
        public string APNameEn { get; set; }
        public Enum APCode { get; set; }
        public bool HasAuthority { get; set; }
    }
    #endregion

    #region User
    public class UserIndexViewModel
    {
       // public SharedSearchModel<UserSearchModel, tblUsers> SearchModel { get; set; }

        public SelectList GroupDDL { get; set; }

        public PartialNameModel NameModel { get; set; }

        public bool GroupAuth { get; set; }
    }

    public class UserCreateViewModel
    {
       // public tblUsers User { get; set; }

        public SelectList GroupDDL { get; set; }

        [Required]
        [Display(Name = "密碼")]
        [DataType(DataType.Password)]
        public string Pwd { get; set; }

        [Required]
        [Display(Name = "確認密碼")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Pwd", ErrorMessage = "請輸入相同密碼")]
        public string PwdCheck { get; set; }
    }

    public class UserEditViewModel
    {
       // public tblUsers User { get; set; }

        public SelectList GroupDDL { get; set; }

        [Display(Name = "密碼")]
        [DataType(DataType.Password)]
        public string Pwd { get; set; }

        [Display(Name = "確認密碼")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Pwd", ErrorMessage = "請輸入相同密碼")]
        public string PwdCheck { get; set; }
    }

    public class UserSearchModel
    {
        public string Account { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public int GroupId { get; set; }
    }
    #endregion
}