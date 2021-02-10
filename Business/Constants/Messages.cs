using Entities.Concrete;
using System;
using System.Collections.Generic;
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
    }
}
