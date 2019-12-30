using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CRM_MVC.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using Newtonsoft.Json;

namespace MVCDemo.Controllers
{
    public class DefaultController : Controller
    {

        //显示学生信息
        public ActionResult Show(string name)
        {
            //string json = APIClient.GetApiResult("get","/Userinfo/Sql");
            //List<Student> list = JsonConvert.DeserializeObject<List<Student>>(json);
            string url = "";
            
            if (name!=null)
            {
               url = "http://localhost:54296/DemApi/Sql?name="+name;
            }
            else
            {
                url = "http://localhost:54296/DemApi/Sql";
            } 
            HttpClient http = new HttpClient();
            HttpResponseMessage ss = http.GetAsync(url).Result;
            string stu = ss.Content.ReadAsStringAsync().Result;
            List<Student> lisq = JsonConvert.DeserializeObject<List<Student>>(stu);
            return View(lisq);
        }






        //删除学生
        public void  Del(int id)
        {
          string json =  APIClient.GetApiResult("get", "DemApi/DeleteId?id=" + id);
            int i = Convert.ToInt32(json);
            if (i>0)
            {
                 //Content("<script>alert('删除成功');location.href='/Default/Show'</script>","text/html");
                Response.WriteAsync("<script>alert('删除成功');location.href='/Default/Show'</script>");
            }
        }

        //添加学生
        public ActionResult  Add()
        {
            return View();
        }
        [HttpPost]
        public void Add(Student s)
        {
            string json = APIClient.GetApiResult("post", "DemApi/Addstu",s);
            int i = Convert.ToInt32(json);
            if (i > 0)
            {
                Response.WriteAsync("<script>alert('添加成功');location.href='/Default/Show'</script>");
            }
        }



        //反填学生
        public ActionResult Selone(int id)
         {
            string json = APIClient.GetApiResult("get", "DemApi/Selone?id="+id);
            List<Student> list = JsonConvert.DeserializeObject<List<Student>>(json);
            ViewBag.list = list;
            return View(ViewBag.list);
        }

        public void Selonet(Mxmx table)
        {
            string json = APIClient.GetApiResult("put", "DemApi/UpdatesEMp", table);
            if (json==null)
            {
                Response.WriteAsync("<script>alert('修改失败');location.href='/Default/Show'</script>");

            }
            else
            {
                Response.WriteAsync("<script>alert('修改成功');location.href='/Default/Show'</script>");
            }
        }



    }
}