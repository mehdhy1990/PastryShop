﻿using Microsoft.AspNetCore.Mvc;

namespace PastryShop.Controllers;

public class ContactController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}