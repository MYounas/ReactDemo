using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactDemo.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ReactDemo.Controllers
{
    public class HomeController : Controller
    {
        private static IList<CommentModel> _comments;
        // GET: /<controller>/

        static HomeController()
        {
            _comments = new List<CommentModel>
            {
                new CommentModel
                {
                    Id=1,
                    Author="Younas",
                    Text="Aslam u alaikm"
                },
                new CommentModel
                {
                    Id=2,
                    Author="Yousaf",
                    Text="wa alaikm slam"
                },
                new CommentModel
                {
                    Id=3,
                    Author="Adnan",
                    Text="Khuda Hafiz"
                }
            };
        }

        public IActionResult Index()
        {
            return View(_comments);
        }

        [Route("comments")]
        [ResponseCache(Location =ResponseCacheLocation.None,NoStore =true)]
        public ActionResult Comments()
        {
            return Json(_comments);
        }

        [Route("comments/new")]
        [HttpPost]
        public ActionResult AddComment(CommentModel comment)
        {
            comment.Id = _comments.Count + 1;
            _comments.Add(comment);
            return Content("Success :)");
        }

    }
}
