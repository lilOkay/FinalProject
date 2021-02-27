using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    //static verince mesagesi biedaha newlemek zorunda kalmıyoruyz
    public static class Messages
    {//publicler pascalcase yazılır
        public static string ProductAdded = "ürün eklendi! ";
        public static string ProductNameInvalid = "Ürün ismi geçersiz! ";
        public static string MaintenanceTime="Sistem bakımda";
        public static string ProductListed="Ürünler listelendi";
        public static string ProductCountErrorOfCategoryError="Bir kategoryde enfazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists="Bu isimde başka bir ürün zaten var";
        public static string CategoryLimitExeded="kategori limit aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied="Yetkiniz yok";
        public static string AccessTokenCreated="";
        public static string UserAlreadyExists="";
        public static User PasswordError;
        public static User UserNotFound;
        public static string UserRegistered="";
        public static string SuccessfulLogin="";
    }
}
