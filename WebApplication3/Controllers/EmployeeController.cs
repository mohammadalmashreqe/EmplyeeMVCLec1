using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class EmployeeController : Controller
    {
       public static  List<Models.Employee> EmpList = new List<Models.Employee>();
        // GET: Employee
        public ActionResult Index()
        {

           
         
            return View(EmpList);
        }
        public ActionResult Create ()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Employee e)
        {
            EmpList.Add(e);
           return  RedirectToAction("Index");
        }
        public ActionResult Details(int id )
        {
            Models.Employee e1 = EmpList.Where(e => e.ID == id).FirstOrDefault();
                                

            return View(e1);
        }
        public ActionResult Edit (int id )
        {
            Models.Employee e1 = EmpList.Where(e => e.ID == id).FirstOrDefault();


            return View(e1);

        }
        [HttpPost]
        public ActionResult Edit(Models.Employee st)
        {
            int index = -1; 
            for(int i=0; i<EmpList.Count;i++)
            {
                if (EmpList[i].ID == st.ID)
                    index = i;
            }

            if(index!=-1)
            {
                EmpList[index] = st;
            }
            return RedirectToAction("Index");
        }
    }
}