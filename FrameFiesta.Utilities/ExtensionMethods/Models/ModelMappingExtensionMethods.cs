using FrameFiesta.Contracts.Models;

namespace FrameFiesta.Utilities.ExtensionMethods.Models
{
    public static class ModelMappingExtensionMethods
    {
        public static User ConvertUserDbToUser(this UserDb userDb)
        {
            return new User
            {
                Id = userDb.Id,
                Name = userDb.Name,
                Email = userDb.Email,
                Comments = userDb.Comments
            };
        }

            public static BlogPostFe ToBlogPostFe(this BlogPostDb blogPostDb, IEnumerable<UserDb> users)
            {
                var commentsFe = blogPostDb.Comments.Select(bc =>
                {
                    var user = users.FirstOrDefault(u => u.Id == bc.UserId);
                    return new CommentFe
                    {
                        Id = bc.CommentId,
                        Text = user?.Comments.FirstOrDefault(uc => uc.ID == bc.CommentId)?.Text,
                        Date = user?.Comments.FirstOrDefault(uc => uc.ID == bc.CommentId)?.CreatedAt ?? default,
                        Name = user?.Name
                    };
                }).ToList();

                return new BlogPostFe
                {
                    Id = blogPostDb.Id,
                    Date = blogPostDb.Date,
                    Description = blogPostDb.Description,
                    Review = blogPostDb.Review,
                    RelatedMotionPicture = blogPostDb.RelatedMotionPicture,
                    Comments = commentsFe
                };
            }


        public static object ConvertToJsonObject(this BlogPostFe blogPost, IEnumerable<UserDb> users)
        {
            var motionPicture = blogPost.RelatedMotionPicture;

            var commentsFe = blogPost.Comments.Select(bc =>
            {
                var user = users.FirstOrDefault(u => u.Name == bc.Name);
                return new CommentFe
                {
                    Id = bc.Id,
                    Text = user?.Comments.FirstOrDefault(uc => uc.ID == bc.Id)?.Text,
                    Date = user?.Comments.FirstOrDefault(uc => uc.ID == bc.Id)?.CreatedAt ?? default,
                    Name = user?.Name
                };
            }).ToList();

            if (motionPicture is Series series)
            {
                return new
                {
                    blogPost.Id,
                    blogPost.Date,
                    blogPost.Description,
                    blogPost.Review,
                    Comments = commentsFe,
                    RelatedMotionPicture = new
                    {
                        series.Title,
                        series.Country,
                        series.Director,
                        series.Actors,
                        series.Rating,
                        series.Image,
                        series.Genres,
                        series.InitialRelease,
                        series.Seasons,
                        series.Episodes,
                        series.AgeRating,
                        series.Budget,
                        Type = "Series"
                    }
                };
            }
            else if (motionPicture is Film film)
            {
                return new
                {
                    blogPost.Id,
                    blogPost.Date,
                    blogPost.Description,
                    blogPost.Review,
                    Comments = commentsFe,
                    RelatedMotionPicture = new
                    {
                        film.Title,
                        film.Country,
                        film.Director,
                        film.Actors,
                        film.Rating,
                        film.Image,
                        film.Genres,
                        film.InitialRelease,
                        film.RunTime,
                        film.AgeRating,
                        film.Budget,
                        Type = "Film"
                    }
                };
            }
            else
            {
                return new
                {
                    blogPost.Id,
                    blogPost.Date,
                    blogPost.Description,
                    blogPost.Review,
                    Comments = commentsFe,
                    RelatedMotionPicture = motionPicture
                };
            }
        }

        public static object ConvertMotionPictureToJsonObject(this BlogPostDb blogPost)
        {
            var motionPicture = blogPost.RelatedMotionPicture;

            if (motionPicture is Series series)
            {
                return new
                {
                    blogPost.Id,
                    blogPost.Date,
                    blogPost.Description,
                    blogPost.Review,
                    blogPost.Comments,
                    RelatedMotionPicture = new
                    {
                        series.Title,
                        series.Country,
                        series.Director,
                        series.Actors,
                        series.Rating,
                        series.Image,
                        series.Genres,
                        series.InitialRelease,
                        series.Seasons,
                        series.Episodes,
                        Type = "Series"
                    }
                };
            }
            else if (motionPicture is Film film)
            {
                return new
                {
                    blogPost.Id,
                    blogPost.Date,
                    blogPost.Description,
                    blogPost.Review,
                    blogPost.Comments,
                    RelatedMotionPicture = new
                    {
                        film.Title,
                        film.Country,
                        film.Director,
                        film.Actors,
                        film.Rating,
                        film.Image,
                        film.Genres,
                        film.InitialRelease,
                        film.RunTime,
                        Type = "Film"
                    }
                };
            }
            else
            {
                return new
                {
                    blogPost.Id,
                    blogPost.Date,
                    blogPost.Description,
                    blogPost.Review,
                    blogPost.Comments,
                    RelatedMotionPicture = motionPicture
                };
            }
        }
    }
}