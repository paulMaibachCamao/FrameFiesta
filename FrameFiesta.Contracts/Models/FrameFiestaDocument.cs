﻿namespace FrameFiesta.Contracts.Models
{
    public class FrameFiestaDocument
    {
        public string Id { get; set; } = "Entities";
        public List<BlogPostDb> BlogPosts { get; set; } = new List<BlogPostDb>();
        public List<UserDb> Users { get; set; } = new List<UserDb>();
    }
}