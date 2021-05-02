using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDBCrud.Entities;
using MongoDBCrud.Models;


namespace MongoDBCrud.Controllers
{
    public class AccountController : Controller
    {
        private AccountModel accountModel = new AccountModel();
        public ActionResult Index()
        {
            ViewBag.accounts = accountModel.findAll();
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("Add", new Account());

        }
        [HttpPost]

        public ActionResult Add(Account account)
        {
            accountModel.create(account);
            return RedirectToAction("Index");

        }

        public ActionResult Delete(string id)
        {
            accountModel.delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View("Edit", accountModel.find(id));

        }

        [HttpPost]
        public ActionResult Edit(Account account,FormCollection fc)
        {
            string id = fc["id"];
            var currentAccount = accountModel.find(id);
            currentAccount.Name = account.Name;
            currentAccount.Surname = account.Surname;
            currentAccount.Price = account.Price;
            currentAccount.Status = account.Status;
            accountModel.update(currentAccount);
            return RedirectToAction("Index");
        }


    }
}