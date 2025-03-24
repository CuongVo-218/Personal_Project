using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BanDienThoai
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
            name: "TatCaSanPham",
            url: "tat-ca-san-pham",
            defaults: new { controller = "Site", action = "Product", id = UrlParameter.Optional }
        );

            routes.MapRoute(
                name: "GioHang",
                url: "gio-hang",
                defaults: new { controller = "Giohang", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
            name: "ThanhToan",
            url: "thanh-toan",
            defaults: new { controller = "Giohang", action = "ThanhToan", id = UrlParameter.Optional }
            );
            routes.MapRoute(
             name: "ThanhCong",
             url: "thanh-cong",
             defaults: new { controller = "Giohang", action = "Thanhcong", id = UrlParameter.Optional }
     );
            routes.MapRoute(
            name: "LichSuDonHang",
            url: "lich-su-don-hang",
            defaults: new { controller = "Giohang", action = "LichSuDonHang", id = UrlParameter.Optional }
);
            routes.MapRoute(
                name: "DangNhap",
                url: "dang-nhap",
                defaults: new { controller = "KhachHang", action = "DangNhap", id = UrlParameter.Optional }
            );
            routes.MapRoute(
             name: "DangXuat",
             url: "dang-xuat",
             defaults: new { controller = "KhachHang", action = "DangXuat", id = UrlParameter.Optional }
         );
            routes.MapRoute(
         name: "DangKy",
         url: "dang-ky",
         defaults: new { controller = "KhachHang", action = "DangKy", id = UrlParameter.Optional }
     );     routes.MapRoute(
               name: "TimKiem",
               url: "tim-kiem",
               defaults: new { controller = "TimKiem", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "ChinhSua",
              url: "chinh-sua",
              defaults: new { controller = "KhachHang", action = "ChinhSua", id = UrlParameter.Optional }
          );
           
            routes.MapRoute(
               name: "SiteSlug",
               url: "{slug}",
               defaults: new { controller = "Site", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Site", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
