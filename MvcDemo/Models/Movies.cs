using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcDemo.Models
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2015/12/15 17:01:56
    /// 描述：
    /// </summary>
    public class Movies
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }

    //public class MovieDBContext:DbContext:DbContext
    //{

    //}

}