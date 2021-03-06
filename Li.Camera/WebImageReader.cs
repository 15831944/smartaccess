﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace Li.Camera
{
    /// <summary>
    /// 读取Web图片
    /// </summary>
    public class WebImageReader
    {
        public delegate void ReadImageCallBack(Image image,Exception ex);
        public static Image ReadImage(string url,string user=null,string pwd=null)
        {
            WebClient webclient = new WebClient();
            //WebRequest req = WebRequest.Create(url);
            if (!string.IsNullOrWhiteSpace(user)||!string.IsNullOrEmpty(pwd))
            {
                webclient.Credentials = new NetworkCredential(user, pwd);
            }
            var bts= webclient.DownloadData(url);
            MemoryStream ms = new MemoryStream();
            ms.Write(bts, 0, bts.Length);
            /* var resp = req.GetResponse();
             var stream = resp.GetResponseStream();
             MemoryStream ms=new MemoryStream();
             byte[] bts=new byte[1024];
             while (true)
             {
                 int count = stream.Read(bts, 0, 1024);
                 if (count > 0)
                 {
                     ms.Write(bts, 0, count);
                 }
                 else break;
             }*/
            if (ms.Length>0)
            {
                Image image = Image.FromStream(ms);
                Bitmap bitmap = new Bitmap(image.Width, image.Height);
                Graphics g= Graphics.FromImage(bitmap);
                g.DrawImage(image, 0, 0, image.Width, image.Height);
                ms.Dispose();
                g.Dispose();
                image.Dispose();
                return bitmap;
            }
            return null;
        }
        public static void ReadImageAsync(string url, ReadImageCallBack callback, string user = null, string pwd = null)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                {
                    try
                    {
                        Image image = ReadImage(url, user,pwd);
                        callback(image,null);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            callback(null, ex);
                        }
                        catch (Exception)
                        {
                             
                        }
                    }
                }));
        }
    }
}
