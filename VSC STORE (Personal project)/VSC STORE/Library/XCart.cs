﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BanDienThoai
{
    public class XCart
    {
        public List<CartItem> AddCart(CartItem cartitem,int productid)
        {
           
            List<CartItem> listcart;
            if (System.Web.HttpContext.Current.Session["MyCart"].Equals(""))
            {
                listcart = new List<CartItem>();
                listcart.Add(cartitem);
                System.Web.HttpContext.Current.Session["MyCart"] = listcart;
            }
            else
            {
               listcart = (List<CartItem>)System.Web.HttpContext.Current.Session["MyCart"];
                if (listcart.Where(m => m.ProductId == productid).Count() != 0)
                {
                    int vt = 0;
                    foreach (var item in listcart)
                    {
                        if (item.ProductId == productid)
                        {
                            listcart[vt].Qty += 1;
                            listcart[vt].Amount = (listcart[vt].Qty * listcart[vt].Price);
                        }
                        vt++;
                    }
                    System.Web.HttpContext.Current.Session["MyCart"] = listcart;

                }
                else
                {
                    listcart.Add(cartitem);
                    System.Web.HttpContext.Current.Session["MyCart"] = listcart;
                }

            }
            return listcart;
        }
        public void UpdateCart(string[] arrqty)
        {

            List<CartItem> listcart = this.getCart();
            int vt = 0;
            foreach (CartItem cartitem in listcart)
            {

                listcart[vt].Qty = int.Parse(arrqty[vt]);
                listcart[vt].Amount = (listcart[vt].Qty * listcart[vt].Price);
                vt++;
            }

            System.Web.HttpContext.Current.Session["MyCart"] = listcart;
        }
        public void DelCart(int? productid = null)
        {
            if (productid != null)
            {
                if (!System.Web.HttpContext.Current.Session["MyCart"].Equals(""))
                {
                    List<CartItem> listcart = (List<CartItem>)System.Web.HttpContext.Current.Session["MyCart"];
                    int vt = 0;
                    foreach (var item in listcart)
                    {
                        if (item.ProductId == productid)
                        {
                            listcart.RemoveAt(vt);
                            break;
                        }
                        vt++;
                    }
                    System.Web.HttpContext.Current.Session["MyCart"] = listcart;
                }
            }
            else
            {
                System.Web.HttpContext.Current.Session["MyCart"] = "";
            }

        }
        public List<CartItem> getCart()
        {
            if (System.Web.HttpContext.Current.Session["MyCart"].Equals(""))
            {
                return null;
            }
                return  (List<CartItem>)System.Web.HttpContext.Current.Session["MyCart"];
        }
    }
}