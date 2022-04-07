using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment.Controllers
{
    
    public class HomeController : Controller
    {
        QuizWebContext context = new QuizWebContext();
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            return View();
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");


        }
        public ActionResult LoginTeacher()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginTeacher(TblAdmin a)
        {
            
                TblAdmin ad = context.TblAdmins.Where(x => x.AdName == a.AdName && x.AdPassword == a.AdPassword).SingleOrDefault();

                if (ad != null)
                {
                    string adSes = JsonSerializer.Serialize(ad);
                    HttpContext.Session.SetString("admin", adSes);
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ViewBag.msg = "Invalid usename or password";
                }
            
            
            return View();
        }
        public ActionResult LoginStudent()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LoginStudent(TblStudent s)
        {

            
                TblStudent stu = context.TblStudents.Where(x => x.SName == s.SName && x.SPassword == s.SPassword).SingleOrDefault();

                if (stu != null)
                {
                    string stuSes = JsonSerializer.Serialize(stu);
                    HttpContext.Session.SetString("student", stuSes);
                    return RedirectToAction("StudentExam");
                }
                else
                {
                    ViewBag.msg = "Invalid user or Password";
                }
            

            return View();
        }
        public ActionResult StudentExam()
        {
            string takeStudent = HttpContext.Session.GetString("student");
            TblStudent stu = JsonSerializer.Deserialize<TblStudent>(takeStudent);
            if (stu == null)
            {
                return RedirectToAction("LoginStudent");
            }

            return View();
        }

        [HttpPost]
        
        public  ActionResult StudentExam(string room)
        {

            List<TblCategroy> list = context.TblCategroys.ToList();

            foreach (var item in list)
            {
                if (item.CatEncyptedstring == room)
                {

                    TempData["exampid"] = item.CatId;
                    TempData["score"] = 0;
                    TempData.Keep();
                    return RedirectToAction("QuizStart");
                }
                else
                {
                    ViewBag.error = "No Room Found......";
                }
            }


            return View();
        }

        public ActionResult QuizStart()
        {

            if (TempData["i"] == null)
            {

                TempData["i"] = 1;
            }
            try
            {
                string takeStudent = HttpContext.Session.GetString("student");
                TblStudent stu = JsonSerializer.Deserialize<TblStudent>(takeStudent);
                try
                {
                    TblQuestion q = null;
                    int examid = Convert.ToInt32(TempData["exampid"].ToString());
                    
                    TempData["quantityQuestion"] = context.TblQuestions.Where(x => x.QFkCatid == examid).OrderBy(x => x.QuestionId).Count();
                    if (TempData["qid"] == null)
                    {
                        q = context.TblQuestions.First(x => x.QFkCatid == examid);
                        var list = context.TblQuestions.Where(x => x.QFkCatid == examid).OrderBy(x => x.QuestionId).Skip(Convert.ToInt32(TempData["i"].ToString()));
                        if (list.Count() == 0 && Convert.ToInt32( TempData["check"])==0)
                        {
                            TempData["check"] = 1;     
                            TempData.Keep();
                            return View(q);
                        }
                        else if (list.Count() == 0 && Convert.ToInt32(TempData["check"]) == 1)
                        {
                            return RedirectToAction("EndExam");
                        }
                        
                        int qid = list.FirstOrDefault().QuestionId;
                        TempData["i"] = Convert.ToInt32(TempData["i"].ToString()) + 1;
                        TempData["qid"] = qid;
                        TempData["check"] = 0;
                        
                    }
                    else
                    {
                        int qid = Convert.ToInt32(TempData["qid"].ToString());
                        q = context.TblQuestions.Where(x => x.QuestionId == qid && x.QFkCatid == examid).SingleOrDefault();
                        var list = context.TblQuestions.Where(x => x.QFkCatid == examid).OrderBy(x => x.QuestionId).Skip(Convert.ToInt32(TempData["i"].ToString()));
                        if (Convert.ToInt32(TempData["check"].ToString()) == 1)
                        {
                            
                                return RedirectToAction("EndExam");
                            
                        }
                        if (list.Count() == 0)
                        {
                            list = context.TblQuestions.Where(x => x.QFkCatid == examid).OrderBy(x => x.QuestionId).Skip(Convert.ToInt32(TempData["i"].ToString())-1);
                            qid = list.FirstOrDefault().QuestionId;
                            TempData["qid"] = qid;
                            TempData["i"] = Convert.ToInt32(TempData["i"].ToString()) + 1;
                            TempData["check"] = 1;
                            TempData.Keep();
                            return View(q);
                        }
                        qid = list.FirstOrDefault().QuestionId;
                        TempData["qid"] = qid;
                        TempData["i"] = Convert.ToInt32(TempData["i"].ToString()) + 1;

                    }
                    TempData.Keep();
                    return View(q);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    return RedirectToAction("StudentExam");

                }
            }
            catch (Exception)
            {
                return RedirectToAction("LoginStudent");
            }
        }
        [HttpPost]
        public ActionResult QuizStart(TblQuestion q)
        {
            string studentAns = "";
            if (q.Opa != null)
            {
                studentAns = "A";
            }
            else if (q.Opb != null)
            {
                studentAns = "B";
            }
            else if (q.Opc != null)
            {
                studentAns = "C";
            }
            else if (q.Opd != null)
            {
                studentAns = "D";
            }
            if (studentAns.Equals(q.Cop))
            {
                TempData["score"] = Convert.ToInt32(TempData["score"]) + 1;
            }
            TempData.Keep();
            return RedirectToAction("QuizStart");
        }
        public ActionResult EndExam()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            try
            {
                string takeAdmin = HttpContext.Session.GetString("admin");
                TblAdmin ad = JsonSerializer.Deserialize<TblAdmin>(takeAdmin);
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
            
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        [HttpGet]
        public ActionResult Addcategory()
        {
            try
            {
                string takeAdmin = HttpContext.Session.GetString("admin");
                TblAdmin ad = JsonSerializer.Deserialize<TblAdmin>(takeAdmin);
                if (ad == null)
                {
                    return RedirectToAction("Index");
                }

                int adid = ad.AdId;
                List<TblCategroy> list = context.TblCategroys.Where(x => x.CatFkAdid == adid).OrderByDescending(x => x.CatId).ToList();
                ViewData["list"] = list;

                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
            
            
        }
        [HttpPost]
        public ActionResult Addcategory(TblCategroy cat)
        {
            string takeAdmin = HttpContext.Session.GetString("admin");
            TblAdmin ad = JsonSerializer.Deserialize<TblAdmin>(takeAdmin);
            List<TblCategroy> li = context.TblCategroys.OrderByDescending(x => x.CatId).ToList();
            ViewData["list"] = li;

            Random r = new Random();
            TblCategroy c = new TblCategroy();
            c.CatName = cat.CatName;
            c.CatEncyptedstring =cat.CatName.Trim() +"_" + r.Next().ToString();
            c.CatFkAdid = Convert.ToInt32(ad.AdId.ToString());
            context.TblCategroys.Add(c);
            context.SaveChanges();
            return RedirectToAction("Addcategory");
        }



        [HttpGet]
        public ActionResult Addquestion()
        {
            try
            {
                string takeAdmin = HttpContext.Session.GetString("admin");
                TblAdmin ad = JsonSerializer.Deserialize<TblAdmin>(takeAdmin);
                int sid = ad.AdId;
                List<TblCategroy> li = context.TblCategroys.Where(x => x.CatFkAdid == sid).ToList();
                ViewBag.list = new SelectList(li, "CatId", "CatName");

                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
            ////string takeAdmin = HttpContext.Session.GetString("admin");
            ////TblAdmin ad = JsonSerializer.Deserialize<TblAdmin>(takeAdmin);

            //int sid = ad.AdId;           
            //List<TblCategroy> li = context.TblCategroys.Where(x => x.CatFkAdid == sid).ToList();
            //ViewBag.list = new SelectList(li, "CatId", "CatName");

            //return View();
        }


        [HttpPost]

        public ActionResult Addquestion(TblQuestion q)
        {
            try
            {
                string takeAdmin = HttpContext.Session.GetString("admin");
                TblAdmin ad = JsonSerializer.Deserialize<TblAdmin>(takeAdmin);
                int sid = ad.AdId;
                List<TblCategroy> li = context.TblCategroys.Where(x => x.CatFkAdid == sid).ToList();
                ViewBag.list = new SelectList(li, "CatId", "CatName");

                TblQuestion QA = new TblQuestion();
                QA.QText = q.QText;
                QA.Opa = q.Opa;
                QA.Opb = q.Opb;
                QA.Opc = q.Opc;
                QA.Opd = q.Opd;
                QA.Cop = q.Cop.ToUpper();
                QA.QFkCatid = q.QFkCatid;
                context.TblQuestions.Add(QA);
                context.SaveChanges();
                TempData["msg"] = "Question added successfully....";
                TempData.Keep();
                return RedirectToAction("Addquestion");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
            //string takeAdmin = HttpContext.Session.GetString("admin");
            //TblAdmin ad = JsonSerializer.Deserialize<TblAdmin>(takeAdmin);
            //int sid = ad.AdId;
            //List<TblCategroy> li = context.TblCategroys.Where(x => x.CatFkAdid == sid).ToList();
            //ViewBag.list = new SelectList(li, "CatId", "CatName");

            //TblQuestion QA = new TblQuestion();
            //QA.QText = q.QText;
            //QA.Opa = q.Opa;
            //QA.Opb = q.Opb;
            //QA.Opc = q.Opc;
            //QA.Opd = q.Opd;
            //QA.Cop = q.Cop.ToUpper();
            //QA.QFkCatid = q.QFkCatid;
            //context.TblQuestions.Add(QA);
            //context.SaveChanges();
            //TempData["msg"] = "Question added successfully....";
            //TempData.Keep();
            //return RedirectToAction("Addquestion");


        }



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
