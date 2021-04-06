﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models.Response;
using Infrastructure.Services;
using Infrastructure.Repositories;
using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.Get30HighestGrossing();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieAsync(id);
            return View(movie);
        }

      
        

        //receive Movie inforation from View then submitted
        [HttpPost]
        public IActionResult Create(MovieCreateRequestModel model)
        {
            _movieService.CreateMovie(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Genre(int id)
        {
            var movies = await _movieService.GetMoviesByGenre(id);

            return View("Genres", movies);
        }


    }
}
