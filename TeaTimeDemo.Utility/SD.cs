using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaTimeDemo.Utility
{
    /// <summary>
    /// 在 ASP.NET Core MVC 應用程序中，SD 類的定位是作為一個靜態的輔助類別，用於存儲應用程序中使用的常量值。
    /// 這種類別通常被稱為“Static Details”或“Static Data”，用來集中管理常量，使代碼更易於維護和理解。
    /// </summary>
    public static class SD
    {
        public const string Role_Customer = "Customer";
        public const string Role_Employee = "Employee";
        public const string Role_Manager = "Manager";
        public const string Role_Admin = "Admin";

        //訂單狀態
        public const string StatusPending = "Pending"; //等待店家確認訂單
        public const string StatusApproved = "Approved"; //店家已確認訂單
        public const string StatusInProcess = "InProcess"; //店家準備中
        public const string StatusCancelled = "Cancelled"; //店家或顧客取消訂單
        public const string StatusReady = "Ready"; //店家準備完成
        public const string StatusCompleted = "Completed"; //已完成



    }
}
