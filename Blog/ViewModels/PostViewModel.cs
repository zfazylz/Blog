﻿using Microsoft.AspNetCore.Http;

namespace Blog.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public IFormFile Image { get; set; } = null;
    }
}